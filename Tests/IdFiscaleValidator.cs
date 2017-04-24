using FatturaElettronica.Common;
using FatturaElettronica.Tabelle;
using FatturaElettronica.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
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
    }
}
