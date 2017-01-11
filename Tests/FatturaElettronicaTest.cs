using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using FatturaElettronica.Impostazioni;
using System;

namespace Tests
{
    [TestClass]
    public class FatturaElettronicaTest
    {
        [TestMethod]
        public void CreateInstancePubblicaAmministrazione()
        {
            var f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.PubblicaAmministrazione);
            Assert.AreEqual(FormatoTrasmissione.PubblicaAmministrazione, f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
        }
        [TestMethod]
        public void CreateInstancePrivati()
        {
            var f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.Privati);
            Assert.AreEqual(FormatoTrasmissione.Privati, f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
            Assert.AreEqual(new string('0', 7), f.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario);
        }

        [TestMethod]
        public void SerializePrivatiHeader()
        {

            var result = SerializeAndGetBackVersionAndNamespace(
                FatturaElettronica.FatturaElettronica.CreateInstance(Instance.Privati));
            Assert.AreEqual(FormatoTrasmissione.Privati, result.Item1);
            Assert.AreEqual(RootElement.NameSpace, result.Item2);

        }

        [TestMethod]
        public void SerializePubblicaAmministrazioneHeader()
        {
            var result = SerializeAndGetBackVersionAndNamespace(
                FatturaElettronica.FatturaElettronica.CreateInstance(Instance.PubblicaAmministrazione));
            Assert.AreEqual(FormatoTrasmissione.PubblicaAmministrazione, result.Item1);
            Assert.AreEqual(RootElement.NameSpace, result.Item2);

        }
        [TestMethod]
        public void ValidateFormatoTrasmissione()
        {
            var f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.Privati);
            f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione = "test";
            Assert.IsTrue(f.Error.Contains("FormatoTrasmissione"));
            Assert.IsTrue(f.Error.Contains(FormatoTrasmissione.Privati));
            f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione =FormatoTrasmissione.Privati;
            Assert.IsFalse(f.Error.Contains("FormatoTrasmissione"));

            var f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.PubblicaAmministrazione);
            f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione = "test";
            Assert.IsTrue(f.Error.Contains("FormatoTrasmissione"));
            Assert.IsTrue(f.Error.Contains(FormatoTrasmissione.PubblicaAmministrazione));
            f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione =FormatoTrasmissione.PubblicaAmministrazione;
            Assert.IsFalse(f.Error.Contains("FormatoTrasmissione"));
        }

        private Tuple<string, string> SerializeAndGetBackVersionAndNamespace(FatturaElettronica.FatturaElettronica f)
        {
            using (var w = XmlWriter.Create("test", new XmlWriterSettings { Indent = true }))
            {
                f.WriteXml(w);
            }

            var version = string.Empty;
            var xmlns = string.Empty;
            using (var r = XmlReader.Create("test"))
            {
               while (r.Read())
                {
                    if (r.NodeType == XmlNodeType.Element)
                    {
                        if (r.Prefix == RootElement.Prefix && r.LocalName == RootElement.LocalName)
                        {
                            version = r.GetAttribute("versione");
                            xmlns = r.NamespaceURI;
                            break;
                        }
                    }
                }
            }
            return new Tuple<string, string>(version, xmlns);
        }
    }
}
