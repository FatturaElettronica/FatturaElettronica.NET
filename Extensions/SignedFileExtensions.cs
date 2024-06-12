using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;

namespace FatturaElettronica.Extensions
{
    public static class SignedFileExtensions
    {
        public static void ReadXmlSigned(this FatturaBase fattura, string filePath, bool validateSignature = true)
        {
            try
            {
                // Most times input will be a plain (non-Base64-encoded) file.
                using var inputStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                ReadXmlSigned(fattura, inputStream, validateSignature);
            }
            catch (CryptographicException)
            {
                ReadXmlSignedBase64(fattura, filePath, validateSignature);
            }
        }

        public static void ReadXmlSignedBase64(this FatturaBase fattura, string filePath, bool validateSignature = true)
        {
            ReadXmlSigned(fattura, new MemoryStream(Convert.FromBase64String(File.ReadAllText(filePath))),
                validateSignature);
        }


        public static void ReadXmlSigned(this FatturaBase fattura, Stream stream, bool validateSignature = true)
        {
            using var parsed = ParseSignature(stream, validateSignature);
            fattura.ReadXml(parsed);
        }

        public static MemoryStream ParseSignature(Stream stream, bool validateSignature)
        {
            var fileContent = ReadAllBytes(stream);
            var content = new ContentInfo(fileContent);
            var signedFile = new SignedCms(SubjectIdentifierType.IssuerAndSerialNumber, content, false);
            signedFile.Decode(fileContent);

            if (validateSignature)
            {
                try
                {
                    signedFile.CheckSignature(true);
                }
                catch (CryptographicException ce)
                {
                    throw new SignatureException(Resources.ErrorMessages.SignatureException, ce);
                }
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