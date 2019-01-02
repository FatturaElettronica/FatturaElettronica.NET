using FatturaElettronica.Defaults;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FatturaCreateInstance
    {
        FatturaElettronica.Fattura challenge;

        [TestMethod]
        public void CreatePubblicaAmministrazioneInstance()
        {
            challenge = FatturaElettronica.Fattura.CreateInstance(Instance.PubblicaAmministrazione);
            Assert.AreEqual(FormatoTrasmissione.PubblicaAmministrazione, challenge.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
        }
        [TestMethod]
        public void CreatePrivatiInstance()
        {
            challenge = FatturaElettronica.Fattura.CreateInstance(Instance.Privati);
            Assert.AreEqual(FormatoTrasmissione.Privati, challenge.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
            Assert.AreEqual("0000000", challenge.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario);
        }
    }
}
