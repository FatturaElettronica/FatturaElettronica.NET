using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;

namespace Tests
{
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
            validator.ShouldHaveChildValidator(
                x => x.StabileOrganizzazione, typeof(FatturaElettronica.Validators.StabileOrganizzazioneValidator));
        }
        [TestMethod]
        public void IscrizioneREAHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.IscrizioneREA, typeof(FatturaElettronica.Validators.IscrizioneREAValidator));
        }
        [TestMethod]
        public void ContattiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Contatti, typeof(FatturaElettronica.Validators.ContattiValidator));
        }
        [TestMethod]
        public void RiferimentoAmministrazioneMinMaxLength()
        {
            AssertMinMaxLength(x => x.RiferimentoAmministrazione, 1, 20);
        }
    }
}
