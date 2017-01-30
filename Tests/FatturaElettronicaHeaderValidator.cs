using FluentValidation.TestHelper;
using FatturaElettronica.FatturaElettronicaHeader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FatturaElettronicaHeaderValidator: BaseClass<FatturaElettronicaHeader, FatturaElettronica.Validators.FatturaElettronicaHeaderValidator>
    {
        [TestMethod]
        public void DatiTramissioneHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiTrasmissione, typeof(FatturaElettronica.Validators.DatiTrasmissioneValidator));
        }
        [TestMethod]
        public void CedentePrestatoreHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CedentePrestatore, typeof(FatturaElettronica.Validators.CedentePrestatoreValidator));
        }
        [TestMethod]
        public void RappresentanteFiscaleHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.Rappresentante, typeof(FatturaElettronica.Validators.RappresentanteFiscaleValidator));
        }
        [TestMethod]
        public void CessionarioCommittenteHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CessionarioCommittente, typeof(FatturaElettronica.Validators.CessionarioCommittenteValidator));
        }
    }
}
