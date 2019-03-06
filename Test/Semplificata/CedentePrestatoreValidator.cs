﻿using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CedentePrestatore;
using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Semplificata.Tests
{
    [TestClass]
    public class CedentePrestatoreValidator
        : BaseClass<CedentePrestatore, FatturaElettronica.Validators.Semplificata.CedentePrestatoreValidator>
    {
        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.IdFiscaleIVA, typeof(FatturaElettronica.Validators.IdFiscaleIVAValidator));
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
            challenge.Nome = null;
            challenge.Cognome = null;

            AssertRequired(x => x.Denominazione, expectedErrorCode: "00200");
            AssertMinMaxLength(x => x.Denominazione, 1, 80, expectedErrorCode: "00200");
            AssertMustBeLatin1Supplement(x => x.Denominazione);
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

            AssertRequired(x => x.Nome, expectedErrorCode: "00200");
            AssertMinMaxLength(x => x.Nome, 1, 60, expectedErrorCode: "00200");
            AssertMustBeLatin1Supplement(x => x.Nome);
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

            AssertRequired(x => x.Cognome, expectedErrorCode: "00200");
            AssertMinMaxLength(x => x.Cognome, 1, 60, expectedErrorCode: "00200");
            AssertMustBeLatin1Supplement(x => x.Cognome);
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
        [TestMethod]
        public void SedeHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Sede, typeof(FatturaElettronica.Validators.Semplificata.SedeCedentePrestatoreValidator));
        }
        [TestMethod]
        public void StabileOrganizzazioneHasChildValidator()
        {
            validator.ShouldHaveDelegatePropertyChildValidator(
                x => x.StabileOrganizzazione, typeof(FatturaElettronica.Validators.Semplificata.StabileOrganizzazioneValidator));
        }
        [TestMethod]
        public void IscrizioneREAHasChildValidator()
        {
            validator.ShouldHaveDelegatePropertyChildValidator(x => x.IscrizioneREA, typeof(FatturaElettronica.Validators.Semplificata.IscrizioneREAValidator));
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
        public void RegimeFiscaleRF03Abrogated()
        {
            // RF03 è abrogato a partire dalla v1.2.1 del 15 Marzo 2017.
            challenge.RegimeFiscale = "RF03";
            validator.ShouldHaveValidationErrorFor(x => x.RegimeFiscale, challenge).WithErrorCode("00459");
        }
    }
}
