using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CedentePrestatore;
using FatturaElettronica.Tabelle;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class DatiAnagraficiCedentePrestatoreValidator
        : BaseClass<DatiAnagraficiCedentePrestatore,
            FatturaElettronica.Validators.DatiAnagraficiCedentePrestatoreValidator>
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
        public void AnagraficaHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.Anagrafica,
                typeof(Validators.AnagraficaValidator));
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
            AssertOnlyAcceptsTableValues<RegimeFiscale>(x => x.RegimeFiscale);
        }
    }
}