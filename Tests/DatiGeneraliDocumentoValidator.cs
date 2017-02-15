using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Validators;
using System.Linq;
using FatturaElettronica.Tabelle;

namespace Tests
{
    [TestClass]
    public class DatiGeneraliDocumentoValidator
        : BaseClass<DatiGeneraliDocumento, FatturaElettronica.Validators.DatiGeneraliDocumentoValidator>
    {
        [TestMethod]
        public void TipoDocumentoIsRequired()
        {
            AssertRequired(x => x.TipoDocumento);
        }
        [TestMethod]
        public void TipoDocumentoOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<TipoDocumento>(x => x.TipoDocumento);
        }
        [TestMethod]
        public void DivisaIsRequired()
        {
            AssertRequired(x => x.Divisa);
        }
        [TestMethod]
        public void DivisaOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<Divisa>(x => x.Divisa);
        }
        [TestMethod]
        public void NumeroIsRequired()
        {
            AssertRequired(x => x.Numero);
        }
        [TestMethod]
        public void NumeroMinMaxLength()
        {
            AssertMinMaxLength(x => x.Numero, 1, 20, filler:'1');
        }
        [TestMethod]
        public void NumeroMustHaveAtLeatOneNumericChar()
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

            Assert.AreEqual("00415", r.Errors.FirstOrDefault(x => x.PropertyName == "DatiCassaPrevidenziale").ErrorCode);

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
        public void Art73IsOptional()
        {
            AssertOptional(x => x.Art73);
        }
        [TestMethod]
        public void Art73OnlyAcceptsSIValue()
        {
            AssertOnlyAcceptsSIValue(x => x.Art73);
        }
    }
}
