using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation;

namespace FatturaElettronica.Validators.Semplificata
{
    public class CessionarioCommittenteValidator : AbstractValidator<CessionarioCommittente>
    {
        public CessionarioCommittenteValidator()
        {
            RuleFor(x => x.IdentificativiFiscali)
               .SetValidator(new IdentificativiFiscaliValidator());

            RuleFor(x => x.IdentificativiFiscali)
                .NotEmpty()
                .WithErrorCode("00431")
                .When(x => x.AltriDatiIdentificativi == null);

            RuleFor(x => x.AltriDatiIdentificativi)
                .SetValidator(new AltriDatiIdentificativiValidator());

            RuleFor(x => x.AltriDatiIdentificativi)
                .NotEmpty()
                .WithErrorCode("00431")
                .When(x => x.IdentificativiFiscali == null);

        }
    }
}
