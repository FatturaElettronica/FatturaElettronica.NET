using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiAnagraficiValidator : BaseTestClass<FatturaElettronica.Common.DatiAnagrafici, FatturaElettronica.Validators.DatiAnagraficiValidator>
    {
        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.IdFiscaleIVA, typeof(FatturaElettronica.Validators.IdFiscaleIVAValidator));
        }
        [TestMethod]
        public void CodiceFiscaleMinMaxLength()
        {
            challenge.CodiceFiscale = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceFiscale, challenge);
            challenge.CodiceFiscale = new string('x', 10);
            validator.ShouldHaveValidationErrorFor(x => x.CodiceFiscale, challenge);
            challenge.CodiceFiscale = new string('x', 17);
            validator.ShouldHaveValidationErrorFor(x => x.CodiceFiscale, challenge);
            challenge.CodiceFiscale = new string('x', 11);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceFiscale, challenge);
            challenge.CodiceFiscale = new string('x', 16);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceFiscale, challenge);
        }
        [TestMethod]
        public void AnagraficaHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Anagrafica, typeof(FatturaElettronica.Validators.AnagraficaValidator));
        }
    }
}
