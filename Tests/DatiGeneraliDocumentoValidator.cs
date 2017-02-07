using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Validators;

namespace Tests
{
    [TestClass]
    public class DatiGeneraliDocumentoValidator: BaseClass<DatiGeneraliDocumento, FatturaElettronica.Validators.DatiGeneraliDocumentoValidator>
    {
        [TestMethod]
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
        [TestMethod]
        public void DivisaCannotBeEmpty()
        {
            challenge.Divisa = null;
            validator.ShouldHaveValidationErrorFor(x => x.Divisa, challenge);
            challenge.Divisa = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.Divisa, challenge);
        }
        [TestMethod]
        public void DivisaCanOnlyAcceptDomainValues()
        {
            challenge.Divisa = "notreally";
            validator.ShouldHaveValidationErrorFor(x => x.Divisa, challenge);
            challenge.Divisa = "EUR";
            validator.ShouldNotHaveValidationErrorFor(x => x.Divisa, challenge);
            challenge.Divisa = "XXX";
            validator.ShouldNotHaveValidationErrorFor(x => x.Divisa, challenge);
        }
        [TestMethod]
        public void NumeroCannotBeEmpty()
        {
            challenge.Numero = null;
            validator.ShouldHaveValidationErrorFor(x => x.Numero, challenge);
            challenge.Numero = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.Numero, challenge);
        }
        [TestMethod]
        public void NumeroMinMaxLength()
        {
            challenge.Numero = new string('1', 21);
            validator.ShouldHaveValidationErrorFor(x => x.Numero, challenge);
            challenge.Numero = new string('1', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.Numero, challenge);
            challenge.Numero = new string('1', 20);
            validator.ShouldNotHaveValidationErrorFor(x => x.Numero, challenge);
        }
        [TestMethod]
        public void NumeroDeveAvereUnCarattereNumerico()
        {
            challenge.Numero = "hello";
            validator.ShouldHaveValidationErrorFor(x => x.Numero, challenge);
            challenge.Numero = "hello1";
            validator.ShouldNotHaveValidationErrorFor(x => x.Numero, challenge);
        }
        [TestMethod]
        public void DatiRitenutaHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiRitenuta, typeof(FatturaElettronica.Validators.DatiRitenutaValidator));
        }
    }
}
