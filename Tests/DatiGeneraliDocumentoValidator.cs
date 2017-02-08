using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Validators;
using System.Linq;

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
        [TestMethod]
        public void DatiBolloHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiBollo, typeof(FatturaElettronica.Validators.DatiBolloValidator));
        }
        [TestMethod]
        public void DatiCassaPrevidenzialeHasCollectionValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiCassaPrevidenziale, typeof(FatturaElettronica.Validators.DatiCassaPrevidenzialeValidator));
        }
        [TestMethod]
        public void ScontoMaggiorazioneHasCollectionValidator()
        {
            validator.ShouldHaveChildValidator(x => x.ScontoMaggiorazione, typeof(FatturaElettronica.Validators.ScontoMaggiorazioneValidator));
        }
        [TestMethod]
        public void DatiRitenutaRequiredWhenDatiCassaPrevidenzialeNotEmpty()
        {
            challenge.DatiCassaPrevidenziale.Add(new DatiCassaPrevidenziale { Ritenuta = "SI" });
            var r = validator.Validate(challenge);
            Assert.IsFalse(r.IsValid);

            //For some reason this does not work (because DatiCassaPrevidenziale is a collection)
            // TODO consider implementing an extension method for this
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiCassaPrevidenziale"));

            challenge.DatiCassaPrevidenziale.Clear();
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiCassaPrevidenziale"));
        }
        [TestMethod]
        public void CausaleHasCollectionValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Causale, typeof(FatturaElettronica.Validators.StringLengthValidator));
        }
        [TestMethod]
        public void Art73CanBeEmpty()
        {
            challenge.Art73 = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Art73, challenge);
            challenge.Art73 = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.Art73, challenge);
        }
        [TestMethod]
        public void Art73CanOnlyAcceptSIValue()
        {
            challenge.Art73 = "NO";
            validator.ShouldHaveValidationErrorFor(x => x.Art73, challenge);
            challenge.Art73 = "SI";
            validator.ShouldNotHaveValidationErrorFor(x => x.Art73, challenge);
        }
    }
}
