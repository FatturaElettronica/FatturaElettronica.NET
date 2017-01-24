using FluentValidation.TestHelper;
using FatturaElettronica.FatturaElettronicaHeader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FatturaElettronicaHeaderValidator: BaseTestClass<FatturaElettronicaHeader, FatturaElettronica.Validators.FatturaElettronicaHeaderValidator>
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
    }
}
