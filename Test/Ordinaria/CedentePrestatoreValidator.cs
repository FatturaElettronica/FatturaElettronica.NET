using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CedentePrestatore;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class CedentePrestatoreValidator
        : BaseClass<CedentePrestatore, FatturaElettronica.Validators.CedentePrestatoreValidator>
    {
        [TestMethod]
        public void DatiAnagraficiHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.DatiAnagrafici,
                typeof(FatturaElettronica.Validators.DatiAnagraficiCedentePrestatoreValidator));
        }

        [TestMethod]
        public void SedeHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.Sede,
                typeof(FatturaElettronica.Validators.SedeCedentePrestatoreValidator));
        }

        [TestMethod]
        public void StabileOrganizzazioneHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(
                x => x.StabileOrganizzazione, typeof(Validators.StabileOrganizzazioneValidator));
        }

        [TestMethod]
        public void IscrizioneREAHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(x => x.IscrizioneREA,
                typeof(FatturaElettronica.Validators.IscrizioneREAValidator));
        }

        [TestMethod]
        public void ContattiHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(x => x.Contatti,
                typeof(FatturaElettronica.Validators.ContattiValidator));
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