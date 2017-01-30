using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;
using FatturaElettronica.FatturaElettronicaHeader.RappresentanteFiscale;

namespace Tests
{
    [TestClass]
    public class RappresentanteFiscaleValidator : BaseClass<RappresentanteFiscale, FatturaElettronica.Validators.RappresentanteFiscaleValidator>
    {
        [TestMethod]
        public void DatiAnagraficiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiAnagrafici, typeof(FatturaElettronica.Validators.DatiAnagraficiValidator));
        }
    }
}
