using FatturaElettronica;
using FatturaElettronica.Defaults;
using FatturaElettronica.Ordinaria;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ordinaria.Tests
{
    [TestClass]
    public class FatturaCreateInstance
    {
        FatturaBase challenge;

        [TestMethod]
        public void CreatePubblicaAmministrazioneInstance()
        {
            challenge = FatturaOrdinaria.CreateInstance(Instance.PubblicaAmministrazione);
            Assert.AreEqual(FormatoTrasmissione.PubblicaAmministrazione, ((FatturaOrdinaria)challenge).FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
        }
        [TestMethod]
        public void CreatePrivatiInstance()
        {
            challenge = FatturaOrdinaria.CreateInstance(Instance.Privati);
            Assert.AreEqual(FormatoTrasmissione.Privati, ((FatturaOrdinaria)challenge).FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
            Assert.AreEqual("0000000", ((FatturaOrdinaria)challenge).FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario);
        }
    }
}
