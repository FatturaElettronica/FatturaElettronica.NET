using FatturaElettronica.Resources;
using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation;

namespace FatturaElettronica.Validators.Semplificata
{
    public class IdentificativiFiscaliValidator : AbstractValidator<IdentificativiFiscali>
    {
        public IdentificativiFiscaliValidator()
        {
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAValidator())
                .When(x => x.IdFiscaleIVA != null && !x.IdFiscaleIVA.IsEmpty());
            RuleFor(x => x.CodiceFiscale)
                .Matches("^[A-Z0-9]{11,16}$")
                .When(x => !string.IsNullOrEmpty(x.CodiceFiscale));
            RuleFor(x => x.CodiceFiscale)
                .Must((challenge, _) =>
                    !(string.IsNullOrEmpty(challenge.CodiceFiscale) && challenge.IdFiscaleIVA.IsEmpty()))
                .WithMessage(ValidatorMessages.E00417_S)
                .WithErrorCode("00417");
            RuleFor(x => x.IdFiscaleIVA)
                .Must((challenge, _) =>
                    !(string.IsNullOrEmpty(challenge.CodiceFiscale) && challenge.IdFiscaleIVA.IsEmpty()))
                .WithMessage(ValidatorMessages.E00417_S)
                .WithErrorCode("00417");
        }
    }
}
