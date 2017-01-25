using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiAnagraficiValidator : BaseTestClass<FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici, FatturaElettronica.Validators.DatiAnagraficiValidator>
    {
        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.IdFiscaleIVA, typeof(FatturaElettronica.Validators.IdFiscaleIVAValidator));
        }
        [TestMethod]
        public void CodiceFiscaleMinMaxLength()
        {
            challenge.CodiceFiscale = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceFiscale, challenge);
            challenge.CodiceFiscale = new string('x', 10);
            validator.ShouldHaveValidationErrorFor(x => x.CodiceFiscale, challenge);
            challenge.CodiceFiscale = new string('x', 17);
            validator.ShouldHaveValidationErrorFor(x => x.CodiceFiscale, challenge);
            challenge.CodiceFiscale = new string('x', 11);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceFiscale, challenge);
            challenge.CodiceFiscale = new string('x', 16);
            validator.ShouldNotHaveValidationErrorFor(x => x.CodiceFiscale, challenge);
        }
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
        public void AnagraficaHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Anagrafica, typeof(FatturaElettronica.Validators.AnagraficaValidator));
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
