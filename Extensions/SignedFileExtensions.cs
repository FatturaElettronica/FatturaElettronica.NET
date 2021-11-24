using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.X509.Store;

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
            catch (CmsException)
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
            var signedFile = new CmsSignedData(stream);
            if (validateSignature)
            {
                var certStore = signedFile.GetCertificates("Collection");
                var certs = certStore.GetMatches(new X509CertStoreSelector());
                var signerStore = signedFile.GetSignerInfos();
                var signers = signerStore.GetSigners();

                foreach (var tempCertification in certs)
                {
                    var certification = tempCertification as Org.BouncyCastle.X509.X509Certificate;

                    foreach (var tempSigner in signers)
                    {
                        var signer = tempSigner as SignerInformation;
                        if (!signer.Verify(certification.GetPublicKey()))
                        {
                            throw new SignatureException(Resources.ErrorMessages.SignatureException);
                        }
                    }
                }
            }

            var memoryStream = new MemoryStream();
            signedFile.SignedContent.Write(memoryStream);
            return memoryStream;
        }

        public static void WriteXmlSigned(this FatturaBase fattura, string pfxFile, string pfxPassword,
            string p7mFilePath)
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
                try
                {
                    //PKCS7 format
                    signedCms.ComputeSignature(signer, false);
                }
                catch (CryptographicException cex)
                {
                    //To evaluate for the future https://stackoverflow.com/a/52897100

                    /*
                    // Try re-importing the private key into a better CSP:
                    using (RSA tmpRsa = RSA.Create())
                    {
                        tmpRsa.ImportParameters(cert.GetRSAPrivateKey().ExportParameters(true));

                        using (X509Certificate2 tmpCertNoKey = new X509Certificate2(cert.RawData))
                        using (X509Certificate2 tmpCert = tmpCertNoKey.CopyWithPrivateKey(tmpRsa))
                        {
                            signer.Certificate = tmpCert;
                            signedCms.ComputeSignature(signer, false);
                        }
                    }*/

                    throw cex;
                }

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