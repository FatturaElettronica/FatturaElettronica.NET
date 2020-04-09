using FatturaElettronica.Defaults;
using FatturaElettronica.Semplificata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Semplificata
{
    [TestClass]
    public class FatturaSemplificataCreateInstance
    {
        FatturaSemplificata _challenge;

        [TestMethod]
        public void CreateSemplificataInstance()
        {
            _challenge = FatturaSemplificata.CreateInstance(Instance.Semplificata);

            Assert.AreEqual(FormatoTrasmissione.Semplificata,
                _challenge.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
            Assert.AreEqual("0000000", _challenge.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario);
        }
    }
}