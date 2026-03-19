using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using FatturaElettronica.Defaults;
using FatturaElettronica.Extensions;
using FatturaElettronica.Ordinaria;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Extensions
{
    [TestClass]
    public class SignedFileExtensionsTest
    {

        [TestMethod]
        public void ReadXMLSigned()
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            f.ReadXmlSigned("Samples/IT02182030391_31.xml.p7m");
            Assert.AreEqual("31", f.FatturaElettronicaHeader.DatiTrasmissione.ProgressivoInvio);
        }

        [TestMethod]
        [DataRow(false)]
        [DataRow(true)]
        public void ReadXMLSigned_ShouldThrowExceptionOnTamperedDocuments(bool performValidation)
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            var exception = Assert.ThrowsException<SignatureException>(() => f.ReadXmlSigned("Samples/IT02182030391_31_tampered.xml.p7m", performValidation));
        }


        [TestMethod]
        public void ReadXMLSignedBase64()
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            f.ReadXmlSignedBase64("Samples/IT02182030391_31.Base64.xml.p7m");
            Assert.AreEqual("31", f.FatturaElettronicaHeader.DatiTrasmissione.ProgressivoInvio);
        }

        [TestMethod]
        public void ReadXMLSignedFallbacksToBase64Attempt()
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            f.ReadXmlSigned("Samples/IT02182030391_31.Base64.xml.p7m");
            Assert.AreEqual("31", f.FatturaElettronicaHeader.DatiTrasmissione.ProgressivoInvio);
        }

        [TestMethod]
        public void ReadXMLSignedValidateSignatureDisabled()
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            f.ReadXmlSigned("Samples/IT02182030391_31.xml.p7m", validateSignature: false);
            Assert.AreEqual("31", f.FatturaElettronicaHeader.DatiTrasmissione.ProgressivoInvio);
        }

        [TestMethod]
        public void ReadXMLSignedBase64ValidateSignatureDisabled()
        {

            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            f.ReadXmlSignedBase64("Samples/IT02182030391_31.Base64.xml.p7m", validateSignature: false);
            Assert.AreEqual("31", f.FatturaElettronicaHeader.DatiTrasmissione.ProgressivoInvio);
        }

        [TestMethod]
        public void ReadXMLSignedThrowsOnNonSignedFile()
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            Assert.ThrowsException<SignatureException>(() => f.ReadXmlSigned("Samples/IT02182030391_32.xml"));
        }

        [TestMethod]
        public void ReadXMLSignedBase64ThrowsOnNonSignedFile()
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            Assert.ThrowsException<FormatException>(() => f.ReadXmlSignedBase64("Samples/IT02182030391_32.xml"));
        }

        [TestMethod]
        public void ReadXMLSignedStream()
        {
            var f = new FatturaOrdinaria();
            using (var inputStream = new FileStream("Samples/IT02182030391_31.xml.p7m", FileMode.Open, FileAccess.Read))
            {
                f.ReadXmlSigned(inputStream);
            }

            Assert.AreEqual("31", f.FatturaElettronicaHeader.DatiTrasmissione.ProgressivoInvio);
        }

        [TestMethod]
        public void WriteXmlSigned()
        {
            if (File.Exists("Samples/IT02182030391_32.xml.p7m"))
                File.Delete("Samples/IT02182030391_32.xml.p7m");
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            f.WriteXmlSigned("Samples/idsrv3test.pfx", "idsrv3test", "Samples/IT02182030391_32.xml.p7m");
            Assert.IsTrue(File.Exists("Samples/IT02182030391_32.xml.p7m"));
        }

        [TestMethod]
        public void WriteXmlSignedThrowsOnMissingPfxFile()
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            Assert.ThrowsException<SignatureException>(() =>
                f.WriteXmlSigned("Samples/notreally.pfx", "idsrv3test", "Samples/IT02182030391_32.xml.p7m"));
        }

        [TestMethod]
        public void ExtractCmsContent_ProducesSameResultAsSignedCms()
        {
            var p7mBytes = File.ReadAllBytes("Samples/IT02182030391_31.xml.p7m");

            using var expected = SignedFileExtensions.ParseSignature(
                new MemoryStream(p7mBytes), false);
            using var actual = SignedFileExtensions.ExtractCmsContent(p7mBytes);

            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
        }

        [TestMethod]
        public void ReadXmlSigned_FallbackAsn1_WhenDecodeFailsAndValidationDisabled()
        {
            var corruptedP7m = CreateP7mWithCorruptedCertificate();

            var f = new FatturaOrdinaria();
            f.ReadXmlSigned(new MemoryStream(corruptedP7m), validateSignature: false);

            Assert.AreEqual("31", f.FatturaElettronicaHeader.DatiTrasmissione.ProgressivoInvio);
        }

        [TestMethod]
        public void ReadXmlSigned_ThrowsSignatureException_WhenDecodeFailsAndValidationEnabled()
        {
            var corruptedP7m = CreateP7mWithCorruptedCertificate();

            var f = new FatturaOrdinaria();
            Assert.ThrowsException<SignatureException>(() =>
                f.ReadXmlSigned(new MemoryStream(corruptedP7m), validateSignature: true));
        }

        [TestMethod]
        public void CreateInstanceFromXml_FallbackAsn1_WhenDecodeFailsAndValidationDisabled()
        {
            var corruptedP7m = CreateP7mWithCorruptedCertificate();

            var fattura = FatturaBase.CreateInstanceFromXml(
                new MemoryStream(corruptedP7m), validateSignature: false);

            Assert.IsNotNull(fattura);
            Assert.IsInstanceOfType(fattura, typeof(FatturaOrdinaria));
        }

        /// <summary>
        /// Simulates a P7M with UniversalString (tag 0x1C) in the certificate area,
        /// reproducing the issue from GitHub #442. The XML content is preserved intact
        /// so the ASN.1 fallback can still extract it.
        /// </summary>
        private static byte[] CreateP7mWithCorruptedCertificate()
        {
            var original = File.ReadAllBytes("Samples/IT02182030391_31.xml.p7m");
            var modified = (byte[])original.Clone();

            // Extract the XML content to find where it ends in the raw bytes
            using var content = SignedFileExtensions.ExtractCmsContent(original);
            var xmlBytes = content.ToArray();

            // Find the last occurrence of the XML content in the P7M
            var xmlEndPos = FindLastIndex(modified, xmlBytes) + xmlBytes.Length;

            // After the XML content, find a SEQUENCE tag (0x30) in the certificate
            // area and replace it with UniversalString (0x1C) to simulate #442
            for (var i = xmlEndPos; i < modified.Length; i++)
            {
                if (modified[i] != 0x30) continue;
                modified[i] = 0x1C;
                break;
            }

            return modified;
        }

        private static int FindLastIndex(byte[] haystack, byte[] needle)
        {
            for (var i = haystack.Length - needle.Length; i >= 0; i--)
            {
                if (haystack.Skip(i).Take(needle.Length).SequenceEqual(needle))
                    return i;
            }

            return -1;
        }
    }
}