using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;
using FatturaElettronica.Impostazioni;
using System;
using FatturaElettronica;
using Newtonsoft.Json;

namespace Tests
{
    [TestClass]
    public class JSONDeSerialize
    {
        [TestMethod]
        public void DeserializeAndThenSerializeOfficialPRSample()
        {
            var f = Deserialize("Samples/IT01234567890_FPR02.xml");
            Assert.IsTrue(f.Validate().IsValid);

            var json = f.ToJson();

            var challenge = Fattura.CreateInstance(Instance.Privati);
            challenge.FromJson(new JsonTextReader(new StringReader(json)));
            Assert.IsTrue(challenge.Validate().IsValid);
        }
        [TestMethod]
        public void NomeCognomeIsIgnored()
        {
            var f = Fattura.CreateInstance(Instance.Privati);
            var anagrafica = f.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica;

            anagrafica.Nome = "nome";
            var json = f.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica.ToJson();

            Assert.AreEqual("nome", anagrafica.CognomeNome);
            Assert.IsFalse(json.Contains("CognomeNome"));
        }
        private Fattura Deserialize(string fileName)
        {
            var f = Fattura.CreateInstance(Instance.Privati);
            var s = new XmlReaderSettings { IgnoreWhitespace = true };
            using (var r = XmlReader.Create(fileName, new XmlReaderSettings { IgnoreWhitespace = true }))
            {
                f.ReadXml(r);
            }
            return f;
        }

    }
}
