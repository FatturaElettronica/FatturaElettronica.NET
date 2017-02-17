using FluentValidation;
using FluentValidation.TestHelper;
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
            validator.ShouldHaveChildValidator(x => x.DatiAnagrafici, typeof(FatturaElettronica.Validators.DatiAnagraficiRappresentanteFiscaleValidator));
        }
    }
}
