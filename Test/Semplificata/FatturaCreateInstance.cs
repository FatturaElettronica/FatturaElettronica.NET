using FatturaElettronica.Defaults;
using FatturaElettronica.Ordinaria;
using FatturaElettronica.Semplificata;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Semplificata.Tests
{
    [TestClass]
    public class FatturaSemplificataCreateInstance
    {
        FatturaSemplificata challenge;

        [TestMethod]
        public void CreateSemplificataInstance()
        {
            challenge = FatturaSemplificata.CreateInstance();
            Assert.AreEqual(FormatoTrasmissione.Semplificata, challenge.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
            Assert.AreEqual("0000000", challenge.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario);
        }
    }
}
