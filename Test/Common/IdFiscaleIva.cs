using FatturaElettronica.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Common
{
    [TestClass]
    public class IdFiscaleIva
    {
        [TestMethod]
        public void ToStringOverride()
        {
            var idFiscale = new IdFiscaleIVA {IdCodice = "123", IdPaese = "IT"};
            Assert.AreEqual("IT123", idFiscale.ToString());
            idFiscale = new() {IdPaese = "IT"};
            Assert.AreEqual("IT", idFiscale.ToString());
            idFiscale = new() {IdCodice = "123"};
            Assert.AreEqual("123", idFiscale.ToString());
            idFiscale = new();
            Assert.AreEqual(string.Empty, idFiscale.ToString());
        }
    }
}