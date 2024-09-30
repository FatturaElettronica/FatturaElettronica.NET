using FluentValidation;
using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CessionarioCommittente;
using FatturaElettronica.Resources;

namespace FatturaElettronica.Validators
{
    public class DatiAnagraficiCessionarioCommittenteValidator
        : AbstractValidator<DatiAnagraficiCessionarioCommittente>
    {
        public DatiAnagraficiCessionarioCommittenteValidator()
        {
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAValidator())
                .When(x => x.IdFiscaleIVA != null && !x.IdFiscaleIVA.IsEmpty());
            RuleFor(x => x.CodiceFiscale)
                .Matches("^[A-Z0-9]{11,16}$")
                .When(x => !string.IsNullOrEmpty(x.CodiceFiscale));
            RuleFor(x => x.Anagrafica)
                .SetValidator(new AnagraficaValidator());
            RuleFor(x => x.CodiceFiscale)
                .Must((challenge, _) =>
                    !(string.IsNullOrEmpty(challenge.CodiceFiscale) && challenge.IdFiscaleIVA.IsEmpty()))
                .WithMessage(ValidatorMessages.E00417)
                .WithErrorCode("00417");
            RuleFor(x => x.IdFiscaleIVA)
                .Must((challenge, _) =>
                    !(string.IsNullOrEmpty(challenge.CodiceFiscale) && challenge.IdFiscaleIVA.IsEmpty()))
                .WithMessage(ValidatorMessages.E00417)
                .WithErrorCode("00417");
        }
    }
}
