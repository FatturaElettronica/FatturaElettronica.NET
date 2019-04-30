using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CedentePrestatore;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Ordinaria.Tests
{

    [TestClass]
    public class CedentePrestatoreValidator
        : BaseClass<CedentePrestatore, FatturaElettronica.Validators.CedentePrestatoreValidator>
    {
        [TestMethod]
        [System.Obsolete]
        public void DatiAnagraficiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiAnagrafici, typeof(FatturaElettronica.Validators.DatiAnagraficiCedentePrestatoreValidator));
        }
        [TestMethod]
        [System.Obsolete]
        public void SedeHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Sede, typeof(FatturaElettronica.Validators.SedeCedentePrestatoreValidator));
        }
        [TestMethod]
        [System.Obsolete]
        public void StabileOrganizzazioneHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.StabileOrganizzazione, typeof(FatturaElettronica.Validators.StabileOrganizzazioneValidator));
        }
        [TestMethod]
        [System.Obsolete]
        public void IscrizioneREAHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.IscrizioneREA, typeof(FatturaElettronica.Validators.IscrizioneREAValidator));
        }
        [TestMethod]
        [System.Obsolete]
        public void ContattiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Contatti, typeof(FatturaElettronica.Validators.ContattiValidator));
        }
        [TestMethod]
        public void RiferimentoAmministrazioneMinMaxLength()
        {
            AssertMinMaxLength(x => x.RiferimentoAmministrazione, 1, 20);
        }
        [TestMethod]
        public void RiferimentoAmministrazioneMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.RiferimentoAmministrazione);
        }
    }
}
