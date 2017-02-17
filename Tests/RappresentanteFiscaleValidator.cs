using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaHeader.RappresentanteFiscale;
using FluentValidation.TestHelper;

namespace Tests
{
    [TestClass]
    public class RappresentanteFiscaleValidator : 
        BaseClass<RappresentanteFiscale, FatturaElettronica.Validators.RappresentanteFiscaleValidator>
    {
        [TestMethod]
        public void DatiAnagraficiHasDelegateChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiAnagrafici, typeof(FatturaElettronica.Validators.DatiAnagraficiRappresentanteFiscaleValidator));
        }
    }
}
