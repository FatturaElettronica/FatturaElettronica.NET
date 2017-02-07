using FluentValidation.TestHelper;
using FatturaElettronica.FatturaElettronicaHeader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiGeneraliDocumentoValidator: BaseClass<DatiGeneraliDocumento, FatturaElettronica.Validators.DatiGeneraliDocumentoValidator>
    {
        public void TipoDocumentoCannotBeEmpty()
        {
            challenge.TipoDocumento = null;
            validator.ShouldHaveValidationErrorFor(x => x.TipoDocumento, challenge);
            challenge.TipoDocumento = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.TipoDocumento, challenge);
        }
        [TestMethod]
        public void TipoDocumentoCanOnlyAcceptDomainValues()
        {
            challenge.TipoDocumento = "TD07";
            validator.ShouldHaveValidationErrorFor(x => x.TipoDocumento, challenge);
            challenge.TipoDocumento = "TD01";
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoDocumento, challenge);
            challenge.TipoDocumento = "TD06";
            validator.ShouldNotHaveValidationErrorFor(x => x.TipoDocumento, challenge);
        }
    }
}
