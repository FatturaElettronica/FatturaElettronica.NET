using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente;

namespace FatturaElettronica.Validators.Semplificata
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
