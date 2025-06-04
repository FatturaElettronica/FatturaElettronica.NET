using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace FatturaElettronica.Extensions
{
    public static class SignedFileExtensions
    {

        /// <summary>
        /// This method will Read the Signed XML whether it is Base64Encoded or plain
        /// </summary>
        /// <param name="fattura"></param>
        /// <param name="filePath"></param>
        /// <param name="validateSignature"></param>
        /// <exception cref="SignatureException">If there is an error validating invoice signature</exception>
        /// <exception cref="FormatException">If it is dealing with a Base64 input and it fails to decode it</exception>"
        public static void ReadXmlSigned(this FatturaBase fattura, string filePath, bool validateSignature = true)
        {
            using var inputStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var contentStream = PreprocessStreamEncoding(inputStream);
            ReadXmlSigned(fattura, contentStream, validateSignature);

        }

        public static void ReadXmlSignedBase64(this FatturaBase fattura, string filePath, bool validateSignature = true)
        {
            ReadXmlSigned(fattura, new MemoryStream(Convert.FromBase64String(File.ReadAllText(filePath))),
                validateSignature);
        }

        /// <summary>
        /// This helper performs preliminary checks to determine if content is likely to be Base64 encoded and if it is it attempts to Decode it and returns.
        /// </summary>
        /// <param name="fileContents">The Stream to be processed</param>
        /// <returns>If the input stream was Base encoded and was successfully decoded it returns a new Stream containing the decoded data. 
        ///Else it rewinds and returns the original stream</returns>
        ///<exception cref="FormatException">Although unlikely, if provided with an invalid base encoded Stream that still got through the length check and regex it will throw a FormatException</exception>
        private static Stream PreprocessStreamEncoding(Stream fileContents)
        {
            //Using the full constructor to prevent stream collection
            using var reader = new StreamReader(fileContents, System.Text.Encoding.UTF8, true, 1024, true);
            var content = reader.ReadToEnd();
            //The length check is a bit faster separate instead of inserted in the regex match
            if (content.Length % 4 != 0 || !Regex.IsMatch(content, "^[A-Za-z0-9+/]*([AQgw]==|[AEIMQUYcgkosw048]=)?$"))
            {
                //Unlikely to be B64,we rewind the stream for convenience
                fileContents.Position = 0;
                return fileContents;
            }
            //Returning a B64Decoded Stream
            return new MemoryStream(Convert.FromBase64String(content));
        }

        public static void ReadXmlSigned(this FatturaBase fattura, Stream stream, bool validateSignature = true)
        {
            using var parsed = ParseSignature(stream, validateSignature);
            fattura.ReadXml(parsed);
        }

        /// <summary>
        /// Retrieves the Fattura XML as a Stream from an input Signed content Stream. 
        /// It should be invoked on Signed content that is not base encoded, and supports signature validation
        /// </summary>
        /// <param name="stream">A Signed Content stream</param>
        /// <param name="validateSignature">If we should validate the content matches the signature</param>
        /// <returns>A Stream that can be Read into a Fattura object</returns>
        /// <exception cref="SignatureException">If ValidateSignature is true and the content doesn't match the signature</exception>
        /// <exception cref="CryptographicException">If the stream is encoded or there is an error Decoding the signature and ValidateSignature is false</exception>
        public static MemoryStream ParseSignature(Stream stream, bool validateSignature)
        {
            var fileContent = ReadAllBytes(stream);
            var content = new ContentInfo(fileContent);
            var signedFile = new SignedCms(SubjectIdentifierType.IssuerAndSerialNumber, content, false);

            try
            {
                if (validateSignature)
                {
                    signedFile.Decode(fileContent);
                    signedFile.CheckSignature(true);
                }
            }
            catch (CryptographicException ce) when (validateSignature)
            {
                throw new SignatureException(Resources.ErrorMessages.SignatureException, ce);
            }

            var memoryStream = new MemoryStream();
            memoryStream.Write(signedFile.ContentInfo.Content, 0, signedFile.ContentInfo.Content.Length);
            return memoryStream;

            static byte[] ReadAllBytes(Stream stream)
            {
                if (stream is MemoryStream mem)
                    return mem.ToArray();

                using var ms = new MemoryStream();
                var buffer = new byte[8192];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, bytesRead);

                return ms.ToArray();
            }
        }

        public static void WriteXmlSigned(this FatturaBase fattura, string pfxFile, string pfxPassword, string p7mFilePath)
        {
            if (!File.Exists(pfxFile))
                throw new SignatureException(Resources.ErrorMessages.PfxIsMissing);

            var cert = new X509Certificate2(pfxFile, pfxPassword);
            WriteXmlSigned(fattura, cert, p7mFilePath);
        }

        public static void WriteXmlSigned(this FatturaBase fattura, X509Certificate2 cert, string p7mFilePath)
        {
            var tempFile = Path.GetTempFileName();

            if (!p7mFilePath.ToLowerInvariant().EndsWith(".p7m"))
                p7mFilePath += ".p7m";

            try
            {
                fattura.WriteXml(tempFile);

                var content = new ContentInfo(new("1.2.840.113549.1.7.1", "PKCS 7 Data"),
                    File.ReadAllBytes(tempFile));
                var signedCms = new SignedCms(SubjectIdentifierType.IssuerAndSerialNumber, content, false);
                var signer = new CmsSigner(cert)
                {
                    IncludeOption = X509IncludeOption.EndCertOnly,
                    DigestAlgorithm = new("2.16.840.1.101.3.4.2.1", "SHA256")
                };
                signer.SignedAttributes.Add(new Pkcs9SigningTime(DateTime.Now));
                //PKCS7 format
                signedCms.ComputeSignature(signer, false);

                var signature = signedCms.Encode();
                File.WriteAllBytes(p7mFilePath, signature);
            }
            catch (Exception)
            {
                throw new SignatureException(Resources.ErrorMessages.FirmaException);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }
    }
}