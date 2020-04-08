using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Semplificata
{
    [TestClass]
    public class AltriDatiIdentificativiValidator : BaseClass<AltriDatiIdentificativi,
        FatturaElettronica.Validators.Semplificata.AltriDatiIdentificativiValidator>
    {
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
                typeof(FatturaElettronica.Validators.Semplificata.SedeCessionarioCommittenteValidator));
        }

        [TestMethod]
        public void StabileOrganizzazioneHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(x => x.StabileOrganizzazione,
                typeof(FatturaElettronica.Validators.Semplificata.StabileOrganizzazioneValidator));
        }
    }
}