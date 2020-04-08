using FatturaElettronica.Defaults;
using FatturaElettronica.Ordinaria;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class FatturaCreateInstance
    {
        FatturaBase _challenge;

        [TestMethod]
        public void CreatePubblicaAmministrazioneInstance()
        {
            _challenge = FatturaOrdinaria.CreateInstance(Instance.PubblicaAmministrazione);
            Assert.AreEqual(FormatoTrasmissione.PubblicaAmministrazione,
                ((FatturaOrdinaria) _challenge).FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
        }

        [TestMethod]
        public void CreatePrivatiInstance()
        {
            _challenge = FatturaOrdinaria.CreateInstance(Instance.Privati);
            Assert.AreEqual(FormatoTrasmissione.Privati,
                ((FatturaOrdinaria) _challenge).FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
            Assert.AreEqual("0000000",
                ((FatturaOrdinaria) _challenge).FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario);
        }
    }
}