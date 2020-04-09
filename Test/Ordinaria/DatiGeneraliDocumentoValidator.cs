using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Validators;
using System.Linq;
using FatturaElettronica.Tabelle;

namespace FatturaElettronica.Test.Ordinaria
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
            AssertMinMaxLength(x => x.Numero, 1, 20, filler: '1');
        }

        [TestMethod]
        public void NumeroMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.Numero);
        }

        [TestMethod]
        public void NumeroMustHaveAtLeatOneNumericChar()
        {
            Challenge.Numero = "hello";
            Validator.ShouldHaveValidationErrorFor(x => x.Numero, Challenge).WithErrorCode("00425");
            Challenge.Numero = "hello1";
            Validator.ShouldNotHaveValidationErrorFor(x => x.Numero, Challenge);
        }

        [TestMethod]
        public void DatiRitenutaHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.DatiRitenuta,
                typeof(FatturaElettronica.Validators.DatiRitenutaValidator));
        }

        [TestMethod]
        public void DatiBolloHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(x => x.DatiBollo,
                typeof(FatturaElettronica.Validators.DatiBolloValidator));
        }

        [TestMethod]
        public void DatiCassaPrevidenzialeHasCollectionValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.DatiCassaPrevidenziale,
                typeof(FatturaElettronica.Validators.DatiCassaPrevidenzialeValidator));
        }

        [TestMethod]
        public void ScontoMaggiorazioneHasCollectionValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.ScontoMaggiorazione,
                typeof(ScontoMaggiorazioneValidator));
        }

        [TestMethod]
        public void DatiRitenutaRequiredWhenDatiCassaPrevidenzialeNotEmpty()
        {
            Challenge.DatiCassaPrevidenziale.Add(new DatiCassaPrevidenziale {Ritenuta = "SI"});
            var r = Validator.Validate(Challenge);
            Assert.AreEqual("00415",
                r.Errors.FirstOrDefault(x => x.PropertyName == "DatiCassaPrevidenziale")?.ErrorCode);

            Challenge.DatiCassaPrevidenziale.Clear();
            r = Validator.Validate(Challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiCassaPrevidenziale"));

            // test che falso errore di convalida sia risolto. Vedi:
            // https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/44
            Challenge.DatiCassaPrevidenziale.Add(new DatiCassaPrevidenziale
            {
                TipoCassa = "TC20", AlCassa = 4, ImportoContributoCassa = 46.56m, Natura = "N5"
            });
            r = Validator.Validate(Challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiCassaPrevidenziale"));
        }

        [TestMethod]
        public void CausaleHasCollectionValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.Causale, typeof(CausaleValidator));
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