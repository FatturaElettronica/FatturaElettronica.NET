using FatturaElettronica.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test
{
    [TestClass]
    public class IdFiscaleIva
    {
        [TestMethod]
        public void ToStringOverride()
        {
            var idFiscale = new IdFiscaleIVA {IdCodice = "123", IdPaese = "IT"};
            Assert.AreEqual("IT123", idFiscale.ToString());
            idFiscale = new IdFiscaleIVA {IdPaese = "IT"};
            Assert.AreEqual("IT", idFiscale.ToString());
            idFiscale = new IdFiscaleIVA {IdCodice = "123"};
            Assert.AreEqual("123", idFiscale.ToString());
            idFiscale = new IdFiscaleIVA();
            Assert.AreEqual(string.Empty, idFiscale.ToString());
        }
        
    }
}