using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;
using FatturaElettronica.Defaults;
using System;
using FatturaElettronica;
using Newtonsoft.Json;
using FatturaElettronica.Ordinaria;

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

            var challenge = FatturaOrdinaria.CreateInstance(Instance.Privati);
            challenge.FromJson(new JsonTextReader(new StringReader(json)));
            Assert.IsTrue(challenge.Validate().IsValid);
        }
        [TestMethod]
        public void NomeCognomeIsIgnored()
        {
            FatturaOrdinaria f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            var anagrafica = f.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica;

            anagrafica.Nome = "nome";
            var json = f.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica.ToJson();

            Assert.AreEqual("nome", anagrafica.CognomeNome);
            Assert.IsFalse(json.Contains("CognomeNome"));
        }
        private FatturaOrdinaria Deserialize(string fileName)
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            using (var r = XmlReader.Create(fileName, new XmlReaderSettings { IgnoreWhitespace = true }))
            {
                f.ReadXml(r);
            }
            return f;
        }

    }
}
