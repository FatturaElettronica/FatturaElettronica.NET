using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaHeader.CessionarioCommittente;

namespace Tests
{
    [TestClass]
    public class RappresentateFiscaleCessionarioCommittenteValidator : BaseTestClass<RappresentanteFiscaleCessionarioCommittente, FatturaElettronica.Validators.RappresentanteFiscaleCessionarioCommittenteValidator>
    {
        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.IdFiscaleIVA, typeof(FatturaElettronica.Validators.IdFiscaleIVAValidator));
        }
        [TestMethod]
        public void DenominazioneCannotBeEmptyWhenNomeCognomeIsEmpty()
        {
            challenge.Denominazione = null;
            validator.ShouldHaveValidationErrorFor(x => x.Denominazione, challenge);
            challenge.Denominazione = new string('x', 81);
            validator.ShouldHaveValidationErrorFor(x => x.Denominazione, challenge);

            challenge.Denominazione = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.Denominazione, challenge);
            challenge.Denominazione = new string('x', 80);
            validator.ShouldNotHaveValidationErrorFor(x => x.Denominazione, challenge);
        }
        [TestMethod]
        public void DenominazioneMustBeEmptyWhenNomeCognoneHasValue()
        {
            challenge.Nome = "nome";
            challenge.Denominazione = new string('x', 81);
            validator.ShouldHaveValidationErrorFor(x => x.Denominazione, challenge);
            challenge.Denominazione = new string('x', 1);
            validator.ShouldHaveValidationErrorFor(x => x.Denominazione, challenge);
            challenge.Denominazione = new string('x', 80);
            validator.ShouldHaveValidationErrorFor(x => x.Denominazione, challenge);

            challenge.Denominazione = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Denominazione, challenge);
        }
        [TestMethod]
        public void NomeCannotBeEmptyWhenDenominazioneIsEmpty()
        {
            challenge.Denominazione = null;
            challenge.Nome = null;
            validator.ShouldHaveValidationErrorFor(x => x.Nome, challenge);
            challenge.Nome = new string('x', 61);
            validator.ShouldHaveValidationErrorFor(x => x.Nome, challenge);
            challenge.Nome = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.Nome, challenge);
            challenge.Nome = new string('x', 60);
            validator.ShouldNotHaveValidationErrorFor(x => x.Nome, challenge);
        }
        [TestMethod]
        public void NomeMustBeEmptyWhenDenominazioneHasValue()
        {
            challenge.Denominazione = "denominazione";
            challenge.Nome = new string('x', 61);
            validator.ShouldHaveValidationErrorFor(x => x.Nome, challenge);
            challenge.Nome = new string('x', 1);
            validator.ShouldHaveValidationErrorFor(x => x.Nome, challenge);
            challenge.Nome = new string('x', 60);
            validator.ShouldHaveValidationErrorFor(x => x.Nome, challenge);
            challenge.Nome = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Nome, challenge);
        }
        [TestMethod]
        public void CognomeCannotBeEmptyWhenDenominazioneIsEmpty()
        {
            challenge.Denominazione = null;
            challenge.Cognome = null;
            validator.ShouldHaveValidationErrorFor(x => x.Cognome, challenge);
            challenge.Cognome = new string('x', 61);
            validator.ShouldHaveValidationErrorFor(x => x.Cognome, challenge);
            challenge.Cognome = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.Cognome, challenge);
            challenge.Cognome = new string('x', 60);
            validator.ShouldNotHaveValidationErrorFor(x => x.Cognome, challenge);
        }
        [TestMethod]
        public void CognomeMustBeEmptyWhenDenominazioneHasValue()
        {
            challenge.Denominazione = "denominazione";
            challenge.Cognome = new string('x', 61);
            validator.ShouldHaveValidationErrorFor(x => x.Cognome, challenge);
            challenge.Cognome = new string('x', 1);
            validator.ShouldHaveValidationErrorFor(x => x.Cognome, challenge);
            challenge.Cognome = new string('x', 60);
            validator.ShouldHaveValidationErrorFor(x => x.Cognome, challenge);
            challenge.Cognome = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Cognome, challenge);
        }
    }
}
