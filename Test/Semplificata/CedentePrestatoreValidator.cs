using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CedentePrestatore;
using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Semplificata
{
    [TestClass]
    public class CedentePrestatoreValidator
        : BaseClass<CedentePrestatore, FatturaElettronica.Validators.Semplificata.CedentePrestatoreValidator>
    {
        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.IdFiscaleIVA,
                typeof(Validators.IdFiscaleIVAValidator));
        }

        [TestMethod]
        public void CodiceFiscaleIsOptional()
        {
            AssertOptional(x => x.CodiceFiscale);
        }

        [TestMethod]
        public void CodiceFiscaleMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodiceFiscale, 11, 16);
        }

        [TestMethod]
        public void DenominazioneIsRequiredWhenNomeCognomeIsEmpty()
        {
            Challenge.Nome = null;
            Challenge.Cognome = null;

            AssertRequired(x => x.Denominazione, expectedErrorCode: "00200");
            AssertMinMaxLength(x => x.Denominazione, 1, 80, expectedErrorCode: "00200");
            AssertMustBeLatin1Supplement(x => x.Denominazione);
        }

        [TestMethod]
        public void DenominazioneMustBeEmptyWhenNomeCognoneIsNotEmpty()
        {
            Challenge.Nome = "nome";

            Challenge.Denominazione = "x";
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Denominazione).WithErrorCode("00200");

            Challenge.Denominazione = null;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Denominazione);

            Challenge.Denominazione = string.Empty;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Denominazione);
        }

        [TestMethod]
        public void NomeIsRequiredWhenDenominazioneIsEmpty()
        {
            Challenge.Denominazione = null;

            AssertRequired(x => x.Nome, expectedErrorCode: "00200");
            AssertMinMaxLength(x => x.Nome, 1, 60, expectedErrorCode: "00200");
            AssertMustBeLatin1Supplement(x => x.Nome);
        }

        [TestMethod]
        public void NomeMustBeEmptyWhenDenominazioneIsNotEmpty()
        {
            Challenge.Denominazione = "denominazione";

            Challenge.Nome = "x";
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Nome).WithErrorCode("00200");

            Challenge.Nome = null;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Nome);

            Challenge.Nome = string.Empty;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void CognomeIsRequiredWhenDenominazioneIsEmpty()
        {
            Challenge.Denominazione = null;

            AssertRequired(x => x.Cognome, expectedErrorCode: "00200");
            AssertMinMaxLength(x => x.Cognome, 1, 60, expectedErrorCode: "00200");
            AssertMustBeLatin1Supplement(x => x.Cognome);
        }

        [TestMethod]
        public void CognomeMustBeEmptyWhenDenominazioneIsNotEmpty()
        {
            Challenge.Denominazione = "denominazione";
            Challenge.Cognome = "x";
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.Cognome).WithErrorCode("00200");

            Challenge.Cognome = null;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Cognome);

            Challenge.Cognome = string.Empty;
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.Cognome);
        }

        [TestMethod]
        public void SedeHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.Sede,
                typeof(FatturaElettronica.Validators.Semplificata.SedeCedentePrestatoreValidator));
        }

        [TestMethod]
        public void StabileOrganizzazioneHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(
                x => x.StabileOrganizzazione,
                typeof(FatturaElettronica.Validators.Semplificata.StabileOrganizzazioneValidator));
        }

        [TestMethod]
        public void IscrizioneREAHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(x => x.IscrizioneREA,
                typeof(FatturaElettronica.Validators.Semplificata.IscrizioneREAValidator));
        }

        [TestMethod]
        public void RegimeFiscaleIsRequired()
        {
            AssertRequired(x => x.RegimeFiscale);
        }

        [TestMethod]
        public void RegimeFiscaleOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<RegimeFiscale>(x => x.RegimeFiscale);
        }
    }
}