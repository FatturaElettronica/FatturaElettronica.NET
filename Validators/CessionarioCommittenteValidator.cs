using FatturaElettronica.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class CessionarioCommittenteValidator : AbstractValidator<CessionarioCommittente>
    {
        public CessionarioCommittenteValidator()
        {
            RuleFor(x => x.DatiAnagrafici)
                .SetValidator(new DatiAnagraficiCessionarioCommittenteValidator());
            RuleFor(x => x.Sede)
                .SetValidator(new SedeCessionarioCommittenteValidator());
            RuleFor(x => x.StabileOrganizzazione)
                .SetValidator(new StabileOrganizzazioneValidator())
                .When(x=>!x.StabileOrganizzazione.IsEmpty());
            RuleFor(x => x.RappresentanteFiscale)
                .SetValidator(new RappresentanteFiscaleCessionarioCommittenteValidator())
                .When(x=>!x.RappresentanteFiscale.IsEmpty());
        }
    }
}
