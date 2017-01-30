using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaHeader.CessionarioCommittente;

namespace Tests
{
    [TestClass]
    public class RappresentateFiscaleCessionarioCommittenteValidator : DenominazioneNomeCognomeValidator<RappresentanteFiscaleCessionarioCommittente, FatturaElettronica.Validators.RappresentanteFiscaleCessionarioCommittenteValidator>
    {
        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.IdFiscaleIVA, typeof(FatturaElettronica.Validators.IdFiscaleIVAValidator));
        }
    }
}
