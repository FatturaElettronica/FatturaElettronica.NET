using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiAnagraficiCedentePrestatoreValidator : BaseDatiAnagraficiValidator<FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore.DatiAnagraficiCedentePrestatore, FatturaElettronica.Validators.DatiAnagraficiCedentePrestatoreValidator>
    {
        [TestMethod]
        public void AlboProfessionaleMinMaxLength()
        {
            challenge.AlboProfessionale = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.AlboProfessionale, challenge);
            challenge.AlboProfessionale = new string('x', 61);
            validator.ShouldHaveValidationErrorFor(x => x.AlboProfessionale, challenge);
            challenge.AlboProfessionale = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.AlboProfessionale, challenge);
            challenge.AlboProfessionale = new string('x', 60);
            validator.ShouldNotHaveValidationErrorFor(x => x.AlboProfessionale, challenge);
        }
        [TestMethod]
        public void ProvinciaAlboCanBeEmpty()
        {
            challenge.ProvinciaAlbo = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.ProvinciaAlbo, challenge);
            challenge.ProvinciaAlbo = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.ProvinciaAlbo, challenge);
        }
        [TestMethod]
        public void ProvinciaAlboCanOnlyAcceptDomainValues()
        {
            challenge.ProvinciaAlbo = "XX";
            validator.ShouldHaveValidationErrorFor(x => x.ProvinciaAlbo, challenge);
            challenge.ProvinciaAlbo = "RA";
            validator.ShouldNotHaveValidationErrorFor(x => x.ProvinciaAlbo, challenge);
        }
        [TestMethod]
        public void NumeroIscrizioneAlboMinMaxLength()
        {
            challenge.NumeroIscrizioneAlbo = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroIscrizioneAlbo, challenge);
            challenge.NumeroIscrizioneAlbo = new string('x', 61);
            validator.ShouldHaveValidationErrorFor(x => x.NumeroIscrizioneAlbo, challenge);
            challenge.NumeroIscrizioneAlbo = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroIscrizioneAlbo, challenge);
            challenge.NumeroIscrizioneAlbo = new string('x', 60);
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroIscrizioneAlbo, challenge);
        }
        [TestMethod]
        public void RegimeFiscaleCanOnlyAcceptDomainValues()
        {
            challenge.RegimeFiscale = null;
            validator.ShouldHaveValidationErrorFor(x => x.RegimeFiscale, challenge);
            challenge.RegimeFiscale = "XX";
            validator.ShouldHaveValidationErrorFor(x => x.RegimeFiscale, challenge);
            challenge.RegimeFiscale = "RF01";
            validator.ShouldNotHaveValidationErrorFor(x => x.RegimeFiscale, challenge);
        }
    }
}
