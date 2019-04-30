using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Ordinaria.Tests
{
    [TestClass]
    public class CessionarioCommittenteValidator
        : BaseClass<CessionarioCommittente, FatturaElettronica.Validators.CessionarioCommittenteValidator>
    {
        [TestMethod]
        [System.Obsolete]
        public void DatiAnagraficiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiAnagrafici, typeof(FatturaElettronica.Validators.DatiAnagraficiCessionarioCommittenteValidator));
        }
        [TestMethod]
        [System.Obsolete]
        public void SedeHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Sede, typeof(FatturaElettronica.Validators.SedeCessionarioCommittenteValidator));
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
        public void RappresentateFiscaleHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.RappresentanteFiscale, typeof(FatturaElettronica.Validators.RappresentanteFiscaleCessionarioCommittenteValidator));
        }
    }
}
