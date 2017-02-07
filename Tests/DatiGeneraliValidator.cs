using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiGeneraliValidator: BaseClass<DatiGenerali, FatturaElettronica.Validators.DatiGeneraliValidator>
    {
        [TestMethod]
        public void DatiGeneraliDocumentoHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiGeneraliDocumento, typeof(FatturaElettronica.Validators.DatiGeneraliDocumentoValidator));
        }
    }
}
