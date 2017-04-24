﻿using FatturaElettronica.Common;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ScontoMaggiorazioneValidator 
        : BaseClass<ScontoMaggiorazione, FatturaElettronica.Validators.ScontoMaggiorazioneValidator>
    {

        [TestMethod]
        public void TipoIsRequired()
        {
            AssertRequired(x => x.Tipo);
        }
        [TestMethod]
        public void TipoOnlyAcceptsTableValues()
        {
            // Necessario per non incappare nell'errore 00437.
            challenge.Importo = 1;

            AssertOnlyAcceptsTableValues<FatturaElettronica.Tabelle.ScontoMaggiorazione>(x => x.Tipo);
        }
        [TestMethod]
        public void TipoValidateAgainstError00437()
        {
            challenge.Tipo = "SC";
            challenge.Importo = null;
            challenge.Percentuale = null;
            validator.ShouldHaveValidationErrorFor(x => x.Tipo, challenge).WithErrorCode("00437");

            challenge.Importo = 0;
            challenge.Percentuale = 0;
            validator.ShouldHaveValidationErrorFor(x => x.Tipo, challenge).WithErrorCode("00437");
        }
        [TestMethod]
        public void ImportoMustHaveValueUnlessPercentualeDoes()
        {
            challenge.Importo = null;
            validator.ShouldHaveValidationErrorFor(x => x.Importo, challenge);
            validator.ShouldHaveValidationErrorFor(x => x.Percentuale, challenge);
            challenge.Importo = 0;
            validator.ShouldHaveValidationErrorFor(x => x.Importo, challenge);
            validator.ShouldNotHaveValidationErrorFor(x => x.Percentuale, challenge);
            challenge.Importo = 1;
            validator.ShouldNotHaveValidationErrorFor(x => x.Importo, challenge);
            validator.ShouldNotHaveValidationErrorFor(x => x.Percentuale, challenge);
            challenge.Importo = -1;
            validator.ShouldNotHaveValidationErrorFor(x => x.Importo, challenge);
            validator.ShouldNotHaveValidationErrorFor(x => x.Percentuale, challenge);
        }
        [TestMethod]
        public void PercentualeMustHaveValueUnlessPercentualeDoes()
        {
            challenge.Percentuale = null;
            validator.ShouldHaveValidationErrorFor(x => x.Percentuale, challenge);
            validator.ShouldHaveValidationErrorFor(x => x.Importo, challenge);
            challenge.Percentuale = 0;
            validator.ShouldHaveValidationErrorFor(x => x.Percentuale, challenge);
            validator.ShouldNotHaveValidationErrorFor(x => x.Importo, challenge);
            challenge.Percentuale = 1;
            validator.ShouldNotHaveValidationErrorFor(x => x.Percentuale, challenge);
            validator.ShouldNotHaveValidationErrorFor(x => x.Importo, challenge);
        }
    }
}
