using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiAnagraficiCedentePrestatoreValidator
        : BaseClass<FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore.DatiAnagraficiCedentePrestatore,
            FatturaElettronica.Validators.DatiAnagraficiCedentePrestatoreValidator>
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
        public void AnagraficaHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Anagrafica, typeof(FatturaElettronica.Validators.AnagraficaValidator));
        }
        [TestMethod]
        public void AlboProfessionalIsOptional()
        {
            AssertOptional(x => x.AlboProfessionale);
        }
        [TestMethod]
        public void AlboProfessionaleMinMaxLength()
        {
            AssertMinMaxLength(x => x.AlboProfessionale, 1, 60);
        }
        [TestMethod]
        public void AlboProfessionaleMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.AlboProfessionale);
        }
        [TestMethod]
        public void ProvinciaAlboIsOptional()
        {
            AssertOptional(x => x.ProvinciaAlbo);
        }
        [TestMethod]
        public void ProvinciaAlboOnlyAcceptsValidValues()
        {
            AssertProvinciaOnlyAcceptsValidValues(x => x.ProvinciaAlbo);
        }
        [TestMethod]
        public void NumeroIscrizioneAlboIsOptional()
        {
            AssertOptional(x => x.NumeroIscrizioneAlbo);
        }
        [TestMethod]
        public void NumeroIscrizioneAlboMinMaxLength()
        {
            AssertMinMaxLength(x => x.NumeroIscrizioneAlbo, 1, 60);
        }
        [TestMethod]
        public void NumeroIscrizioneAlboMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.NumeroIscrizioneAlbo);
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
