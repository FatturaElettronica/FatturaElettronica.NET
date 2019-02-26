namespace Ordinaria.Tests
{
    using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CessionarioCommittente;
    using FluentValidation.TestHelper;
    using global::Tests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CessionarioCommittenteValidator
        : BaseClass<CessionarioCommittente, FatturaElettronica.Validators.CessionarioCommittenteValidator>
    {
        [TestMethod]
        public void DatiAnagraficiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiAnagrafici, typeof(FatturaElettronica.Validators.DatiAnagraficiCessionarioCommittenteValidator));
        }
        [TestMethod]
        public void SedeHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Sede, typeof(FatturaElettronica.Validators.SedeCessionarioCommittenteValidator));
        }
        [TestMethod]
        public void StabileOrganizzazioneHasChildValidator()
        {
            validator.ShouldHaveDelegatePropertyChildValidator(
                x => x.StabileOrganizzazione, typeof(FatturaElettronica.Validators.StabileOrganizzazioneValidator));
        }
        [TestMethod]
        public void RappresentateFiscaleHasChildValidator()
        {
            validator.ShouldHaveDelegatePropertyChildValidator(
                x => x.RappresentanteFiscale, typeof(FatturaElettronica.Validators.RappresentanteFiscaleCessionarioCommittenteValidator));
        }
    }
}
