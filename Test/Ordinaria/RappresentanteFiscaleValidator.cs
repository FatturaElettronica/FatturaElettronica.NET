using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.RappresentanteFiscale;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class RappresentanteFiscaleValidator :
        BaseClass<RappresentanteFiscale, FatturaElettronica.Validators.RappresentanteFiscaleValidator>
    {
        [TestMethod]
        public void DatiAnagraficiHasDelegateChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.DatiAnagrafici,
                typeof(Validators.DatiAnagraficiRappresentanteFiscaleValidator));
        }
    }
}