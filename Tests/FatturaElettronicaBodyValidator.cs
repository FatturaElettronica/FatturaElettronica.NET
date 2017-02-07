using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody;

namespace Tests
{
    [TestClass]
    public class FatturaElettronicaBodyValidator: BaseClass<FatturaElettronicaBody, FatturaElettronica.Validators.FatturaElettronicaBodyValidator>
    {
        [TestMethod]
        public void DatiGeneraliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiGenerali, typeof(FatturaElettronica.Validators.DatiGeneraliValidator));
        }
    }
}
