using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class RappresentateFiscaleCessionarioCommittenteValidator
        : DenominazioneNomeCognomeValidator<RappresentanteFiscaleCessionarioCommittente,
            Validators.RappresentanteFiscaleCessionarioCommittenteValidator>
    {
        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.IdFiscaleIVA,
                typeof(Validators.IdFiscaleIVAValidator));
        }
    }
}