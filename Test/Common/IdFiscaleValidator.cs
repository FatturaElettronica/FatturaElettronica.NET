using FatturaElettronica.Common;
using FatturaElettronica.Tabelle;
using FatturaElettronica.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Common
{
    [TestClass]
    public class IdFiscaleValidator
        : BaseClass<IdFiscaleIVA, IdFiscaleIVAValidator>
    {
        [TestMethod]
        public void IdPaeseIsRequired()
        {
            AssertRequired(x => x.IdPaese);
        }

        [TestMethod]
        public void IdPaeseOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<IdPaese>(x => x.IdPaese);
        }

        [TestMethod]
        public void IdCodiceIsRequired()
        {
            AssertRequired(x => x.IdCodice);
        }

        [TestMethod]
        public void IdCodiceMinMaxLength()
        {
            AssertMinMaxLength(x => x.IdCodice, 1, 28);
        }

        [TestMethod]
        public void IdFiscaleToString()
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