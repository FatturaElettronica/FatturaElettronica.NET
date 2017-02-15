using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;
using FatturaElettronica.FatturaElettronicaHeader.CessionarioCommittente;

namespace Tests
{
    [TestClass]
    public class CessionarioCommittenteValidator 
        : BaseClass<CessionarioCommittente, FatturaElettronica.Validators.CessionarioCommittenteValidator>
    {
        [TestMethod]
        public void DatiAnagraficiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiAnagrafici, typeof(FatturaElettronica.Validators.DatiAnagraficiValidator));
        }
        [TestMethod]
        public void SedeHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Sede, typeof(FatturaElettronica.Validators.SedeCessionarioCommittenteValidator));
        }
        [TestMethod]
        public void StabileOrganizzazioneHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.StabileOrganizzazione, typeof(FatturaElettronica.Validators.StabileOrganizzazioneValidator));
        }
        [TestMethod]
        public void RappresentateFiscaleHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.RappresentanteFiscale, typeof(FatturaElettronica.Validators.RappresentanteFiscaleCessionarioCommittenteValidator));
        }
    }
}
