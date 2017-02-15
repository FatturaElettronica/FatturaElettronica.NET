using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public abstract class BaseRappresentanteFiscaleValidator<TClass, TValidator> 
        : BaseClass<TClass, TValidator>
        where TClass : FatturaElettronica.Common.RappresentanteFiscale
        where TValidator : IValidator<TClass>
    {
        [TestMethod]
        public void DatiAnagraficiHasDelegateChildValidator()
        {
            validator.ShouldHaveDelegatePropertyChildValidator(x => x.DatiAnagrafici, typeof(FatturaElettronica.Validators.DatiAnagraficiValidator));

        }
        [TestMethod]
        public void ValidationIsPerformedWhenNotEmpty()
        {
            challenge.DatiAnagrafici.Anagrafica.Cognome = "cognome";
            var r = validator.Validate(challenge);
            Assert.IsFalse(r.IsValid);
        }

        [TestMethod]
        public void IsValidWhenEmptyBecauseOptional()
        {
            var r = validator.Validate(challenge);
            Assert.IsTrue(r.IsValid);
        }
    }
}
