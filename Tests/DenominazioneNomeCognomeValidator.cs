using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Common;
using FluentValidation;

namespace Tests
{
    [TestClass]
    public abstract class DenominazioneNomeCognomeValidator<TClass, TValidator> 
        : BaseClass<TClass, TValidator>
        where TClass : DenominazioneNomeCognome
        where TValidator : IValidator<TClass>
    {
        [TestMethod]
        public void DenominazioneIsRequiredWhenNomeCognomeIsEmpty()
        {
            challenge.Nome = null;
            challenge.Cognome = null;

            AssertRequired(x => x.Denominazione, expectedErrorCode:"00200");
            AssertMinMaxLength(x => x.Denominazione, 1, 80, expectedErrorCode:"00200");
        }
        [TestMethod]
        public void DenominazioneMustBeEmptyWhenNomeCognoneIsNotEmpty()
        {
            challenge.Nome = "nome";

            challenge.Denominazione = "x";
            validator.ShouldHaveValidationErrorFor(x => x.Denominazione, challenge).WithErrorCode("00200");

            challenge.Denominazione = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Denominazione, challenge);
            challenge.Denominazione = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.Denominazione, challenge);
        }
        [TestMethod]
        public void NomeIsRequiredWhenDenominazioneIsEmpty()
        {
            challenge.Denominazione = null;

            AssertRequired(x => x.Nome, expectedErrorCode:"00200");
            AssertMinMaxLength(x => x.Nome, 1, 60, expectedErrorCode:"00200");
        }
        [TestMethod]
        public void NomeMustBeEmptyWhenDenominazioneIsNotEmpty()
        {
            challenge.Denominazione = "denominazione";

            challenge.Nome = "x";
            validator.ShouldHaveValidationErrorFor(x => x.Nome, challenge).WithErrorCode("00200");

            challenge.Nome = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Nome, challenge);
            challenge.Nome = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.Nome, challenge);
        }
        [TestMethod]
        public void CognomeIsRequiredWhenDenominazioneIsEmpty()
        {
            challenge.Denominazione = null;

            AssertRequired(x => x.Cognome, expectedErrorCode:"00200");
            AssertMinMaxLength(x => x.Cognome, 1, 60, expectedErrorCode:"00200");
        }
        [TestMethod]
        public void CognomeMustBeEmptyWhenDenominazioneIsNotEmpty()
        {
            challenge.Denominazione = "denominazione";
            challenge.Cognome = "x";
            validator.ShouldHaveValidationErrorFor(x => x.Cognome, challenge).WithErrorCode("00200");

            challenge.Cognome = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Cognome, challenge);
            challenge.Cognome = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.Cognome, challenge);
        }
    }
}
