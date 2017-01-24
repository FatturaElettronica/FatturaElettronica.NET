using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Common;

namespace Tests
{
    [TestClass]
    public class DatiAnagraficiValidator : BaseTestClass<DatiAnagrafici, FatturaElettronica.Validators.DatiAnagraficiValidator>
    {
        [TestMethod]
        public void AnagraficaHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Anagrafica, typeof(FatturaElettronica.Validators.AnagraficaValidator));
        }
    }
}
