using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class CessionarioCommittenteValidator
        : BaseClass<CessionarioCommittente, FatturaElettronica.Validators.CessionarioCommittenteValidator>
    {
        [TestMethod]
        public void DatiAnagraficiHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.DatiAnagrafici,
                typeof(FatturaElettronica.Validators.DatiAnagraficiCessionarioCommittenteValidator));
        }

        [TestMethod]
        public void SedeHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.Sede,
                typeof(FatturaElettronica.Validators.SedeCessionarioCommittenteValidator));
        }

        [TestMethod]
        public void StabileOrganizzazioneHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(
                x => x.StabileOrganizzazione, typeof(Validators.StabileOrganizzazioneValidator));
        }

        [TestMethod]
        public void RappresentateFiscaleHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(
                x => x.RappresentanteFiscale,
                typeof(Validators.RappresentanteFiscaleCessionarioCommittenteValidator));
        }
    }
}