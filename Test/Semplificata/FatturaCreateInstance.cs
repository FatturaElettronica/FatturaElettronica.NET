namespace Semplificata.Tests
{
    using FatturaElettronica;
    using FatturaElettronica.Defaults;
    using FatturaElettronica.Semplificata;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FatturaSemplificataCreateInstance
    {
        FatturaSemplificata challenge;

        [TestMethod]
        public void CreateSemplificataInstance()
        {
            challenge = FatturaSemplificata.CreateInstance(Instance.Semplificata);

            Assert.AreEqual(FormatoTrasmissione.Semplificata, challenge.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
            Assert.AreEqual("0000000", challenge.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario);
        }
    }
}
