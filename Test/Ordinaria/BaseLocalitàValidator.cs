using FatturaElettronica.Tabelle;
using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public abstract class BaseLocalitàValidator<TClass, TValidator>
        : BaseClass<TClass, TValidator>
        where TClass : FatturaElettronica.Common.Località
        where TValidator : IValidator<TClass>

    {
        [TestMethod]
        public void IndirizzoIsRequired()
        {
            AssertRequired(x => x.Indirizzo);
        }

        [TestMethod]
        public void IndirizzoMinMaxLength()
        {
            AssertMinMaxLength(x => x.Indirizzo, 1, 60);
        }

        [TestMethod]
        public void IndirizzoMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.Indirizzo);
        }

        [TestMethod]
        public void NumeroCivicoIsOptional()
        {
            AssertOptional(x => x.NumeroCivico);
        }

        [TestMethod]
        public void NumeroCivicoMinMaxLength()
        {
            AssertMinMaxLength(x => x.NumeroCivico, 1, 8);
        }

        [TestMethod]
        public void CAPIsRequired()
        {
            AssertRequired(x => x.CAP);
        }

        [TestMethod]
        public void CAPLength()
        {
            AssertLength(x => x.CAP, 5, filler: '9');
        }

        [TestMethod]
        public void CAPMustBeNumeric()
        {
            Challenge.CAP = "1234A";
            Validator.ShouldHaveValidationErrorFor(x => x.CAP, Challenge);
            Challenge.CAP = "12345";
            Validator.ShouldNotHaveValidationErrorFor(x => x.CAP, Challenge);
        }

        [TestMethod]
        public void ComuneIsRequired()
        {
            AssertRequired(x => x.Comune);
        }

        [TestMethod]
        public void ComuneMinMaxLength()
        {
            AssertMinMaxLength(x => x.Comune, 1, 60);
        }

        [TestMethod]
        public void ComuneMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.Indirizzo);
        }

        [TestMethod]
        public void ProvinciaOptional()
        {
            AssertOptional(x => x.Provincia);
        }

        [TestMethod]
        public void ProvinciaOnlyAcceptsValidValues()
        {
            AssertProvinciaOnlyAcceptsValidValues(x => x.Provincia);
        }

        [TestMethod]
        public void NazioneIsRequired()
        {
            AssertRequired(x => x.Nazione);
        }

        [TestMethod]
        public void NazioneOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<IdPaese>(x => x.Nazione);
        }
    }
}