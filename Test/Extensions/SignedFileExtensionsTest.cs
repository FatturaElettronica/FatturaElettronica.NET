using System;
using System.IO;
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
    }
}