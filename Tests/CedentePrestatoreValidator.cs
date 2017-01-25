using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;

namespace Tests
{
    [TestClass]
    public class CedentePrestatoreValidator : BaseTestClass<CedentePrestatore, FatturaElettronica.Validators.CedentePrestatoreValidator>
    {
        [TestMethod]
        public void DatiAnagraficiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiAnagrafici, typeof(FatturaElettronica.Validators.DatiAnagraficiValidator));
        }
        [TestMethod]
        public void SedeHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Sede, typeof(FatturaElettronica.Validators.SedeValidator));
        }
    }
}
