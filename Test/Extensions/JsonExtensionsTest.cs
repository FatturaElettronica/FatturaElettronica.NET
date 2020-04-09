using FatturaElettronica.Defaults;
using FatturaElettronica.Extensions;
using FatturaElettronica.Ordinaria;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Extensions
{
    [TestClass]
    public class JsonExtensionsTest
    {
        [TestMethod]
        public void FromJson()
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            f.ReadXml("Samples/IT02182030391_32.xml");
            Assert.AreEqual("32", f.FatturaElettronicaHeader.DatiTrasmissione.ProgressivoInvio);

            var json = f.ToJson();
            var challenge = FatturaOrdinaria.CreateInstance(Instance.Privati);
            challenge.FromJson(json);
            Assert.AreEqual("32", challenge.FatturaElettronicaHeader.DatiTrasmissione.ProgressivoInvio);
        }
    }
}