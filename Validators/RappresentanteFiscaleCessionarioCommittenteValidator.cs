using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CessionarioCommittente;

namespace FatturaElettronica.Validators
{
    public class RappresentanteFiscaleCessionarioCommittenteValidator : DenominazioneNomeCognomeValidator<RappresentanteFiscaleCessionarioCommittente>
    {
        public RappresentanteFiscaleCessionarioCommittenteValidator()
        {
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAValidator());
        }
    }
}
