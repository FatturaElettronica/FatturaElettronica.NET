namespace Tests
{
    using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CedentePrestatore;
    using FluentValidation.TestHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CedentePrestatoreValidator
        : BaseClass<CedentePrestatore, FatturaElettronica.Validators.CedentePrestatoreValidator>
    {
        [TestMethod]
        public void DatiAnagraficiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiAnagrafici, typeof(FatturaElettronica.Validators.DatiAnagraficiCedentePrestatoreValidator));
        }
        [TestMethod]
        public void SedeHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Sede, typeof(FatturaElettronica.Validators.SedeCedentePrestatoreValidator));
        }
        [TestMethod]
        public void StabileOrganizzazioneHasChildValidator()
        {
            validator.ShouldHaveDelegatePropertyChildValidator(
                x => x.StabileOrganizzazione, typeof(FatturaElettronica.Validators.StabileOrganizzazioneValidator));
        }
        [TestMethod]
        public void IscrizioneREAHasChildValidator()
        {
            validator.ShouldHaveDelegatePropertyChildValidator(x => x.IscrizioneREA, typeof(FatturaElettronica.Validators.IscrizioneREAValidator));
        }
        [TestMethod]
        public void ContattiHasChildValidator()
        {
            validator.ShouldHaveDelegatePropertyChildValidator(x => x.Contatti, typeof(FatturaElettronica.Validators.ContattiValidator));
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
