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
            Validator.ShouldHaveValidationErrorFor(x => x.Denominazione, Challenge).WithErrorCode("00200");

            Challenge.Denominazione = null;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Denominazione, Challenge);
            Challenge.Denominazione = string.Empty;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Denominazione, Challenge);
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
            Validator.ShouldHaveValidationErrorFor(x => x.Nome, Challenge).WithErrorCode("00200");

            Challenge.Nome = null;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Nome, Challenge);
            Challenge.Nome = string.Empty;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Nome, Challenge);
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
            Validator.ShouldHaveValidationErrorFor(x => x.Cognome, Challenge).WithErrorCode("00200");

            Challenge.Cognome = null;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Cognome, Challenge);
            Challenge.Cognome = string.Empty;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Cognome, Challenge);
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
            AssertOnlyAcceptsTableValues<RegimeFiscale>(x => x.RegimeFiscale, "RegimeFiscaleValidator`1");
        }

        [TestMethod]
        public void RegimeFiscaleRf03Abrogated()
        {
            // RF03 è abrogato a partire dalla v1.2.1 del 15 Marzo 2017.
            Challenge.RegimeFiscale = "RF03";
            Validator.ShouldHaveValidationErrorFor(x => x.RegimeFiscale, Challenge).WithErrorCode("00459");
        }
    }
}