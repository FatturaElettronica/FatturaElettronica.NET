using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.RappresentanteFiscale;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class RappresentanteFiscaleValidator :
         BaseClass<RappresentanteFiscale, FatturaElettronica.Validators.RappresentanteFiscaleValidator>
    {
        [TestMethod]
        [System.Obsolete]
        public void DatiAnagraficiHasDelegateChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiAnagrafici, typeof(FatturaElettronica.Validators.DatiAnagraficiRappresentanteFiscaleValidator));
        }
    }
}
