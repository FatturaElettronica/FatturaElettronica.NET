using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public abstract class BaseDatiAnagraficiValidator<TClass, TValidator> 
        : BaseClass<TClass, TValidator>
        where TClass : FatturaElettronica.Common.DatiAnagrafici
        where TValidator : IValidator<TClass>
    {
        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.IdFiscaleIVA, typeof(FatturaElettronica.Validators.IdFiscaleIVAValidator));
        }
        [TestMethod]
        public void CodiceFiscaleIsOptional()
        {
            AssertOptional(x => x.CodiceFiscale);
        }
        [TestMethod]
        public void CodiceFiscaleMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodiceFiscale, 11, 16);
        }
        [TestMethod]
        public void AnagraficaHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Anagrafica, typeof(FatturaElettronica.Validators.AnagraficaValidator));
        }
    }
}
