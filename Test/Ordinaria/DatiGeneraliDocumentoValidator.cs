using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Validators;
using System.Linq;
using FatturaElettronica.Tabelle;
using Tests;

namespace Ordinaria.Tests
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
            challenge.Numero = "hello";
            validator.ShouldHaveValidationErrorFor(x => x.Numero, challenge).WithErrorCode("00425");
            challenge.Numero = "hello1";
            validator.ShouldNotHaveValidationErrorFor(x => x.Numero, challenge);
        }
        [TestMethod]
        [System.Obsolete]
        public void DatiRitenutaHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiRitenuta, typeof(FatturaElettronica.Validators.DatiRitenutaValidator));
        }
        [TestMethod]
        [System.Obsolete]
        public void DatiBolloHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiBollo, typeof(FatturaElettronica.Validators.DatiBolloValidator));
        }
        [TestMethod]
        [System.Obsolete]
        public void DatiCassaPrevidenzialeHasCollectionValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiCassaPrevidenziale, typeof(FatturaElettronica.Validators.DatiCassaPrevidenzialeValidator));
        }
        [TestMethod]
        [System.Obsolete]
        public void ScontoMaggiorazioneHasCollectionValidator()
        {
            validator.ShouldHaveChildValidator(x => x.ScontoMaggiorazione, typeof(FatturaElettronica.Validators.ScontoMaggiorazioneValidator));
        }
        [TestMethod]
        public void DatiRitenutaRequiredWhenDatiCassaPrevidenzialeNotEmpty()
        {
            challenge.DatiCassaPrevidenziale.Add(new DatiCassaPrevidenziale { Ritenuta = "SI" });
            var r = validator.Validate(challenge);
            Assert.AreEqual("00415", r.Errors.FirstOrDefault(x => x.PropertyName == "DatiCassaPrevidenziale").ErrorCode);

            challenge.DatiCassaPrevidenziale.Clear();
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiCassaPrevidenziale"));

            // test che falso errore di convalida sia risolto. Vedi:
            // https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/44
            challenge.DatiCassaPrevidenziale.Add(new DatiCassaPrevidenziale { TipoCassa = "TC20", AlCassa = 4, ImportoContributoCassa = 46.56m, Natura = "N5" });
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiCassaPrevidenziale"));
        }
        [TestMethod]
        [System.Obsolete]
        public void CausaleHasCollectionValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Causale, typeof(CausaleValidator));
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
