using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation.TestHelper;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ordinaria.Tests
{
    [TestClass]
    public class RappresentateFiscaleCessionarioCommittenteValidator
        : DenominazioneNomeCognomeValidator<RappresentanteFiscaleCessionarioCommittente, FatturaElettronica.Validators.RappresentanteFiscaleCessionarioCommittenteValidator>
    {
        [TestMethod]
        [System.Obsolete]
        public void IdFiscaleIVAHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.IdFiscaleIVA, typeof(FatturaElettronica.Validators.IdFiscaleIVAValidator));
        }
    }
}
