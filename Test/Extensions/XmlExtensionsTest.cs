using System.IO;
using System.Xml;
using FatturaElettronica.Defaults;
using FatturaElettronica.Extensions;
using FatturaElettronica.Ordinaria;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Extensions
{
    [TestClass]
    public class XmlExtensionsTest
    {
        [TestMethod]
        public void ReadXMLFile()
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            f.ReadXml("Samples/IT02182030391_32.xml");
            Assert.AreEqual("32", f.FatturaElettronicaHeader.DatiTrasmissione.ProgressivoInvio);
        }

        [TestMethod]
        public void ReadXMLStream()
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            f.ReadXml(File.OpenRead("Samples/IT02182030391_32.xml"));
            Assert.AreEqual("32", f.FatturaElettronicaHeader.DatiTrasmissione.ProgressivoInvio);
        }

        [TestMethod]
        public void WriteXML()
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            f.FatturaElettronicaHeader.DatiTrasmissione.ProgressivoInvio = "99";

            var outFile = Path.GetTempFileName();
            f.WriteXml(outFile);

            var challenge = FatturaOrdinaria.CreateInstance(Instance.Privati);
            using (var r = XmlReader.Create(outFile,
                new() {IgnoreWhitespace = true, IgnoreComments = true}))
            {
                challenge.ReadXml(r);
            }

            Assert.AreEqual("99", f.FatturaElettronicaHeader.DatiTrasmissione.ProgressivoInvio);
        }
    }
}