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
                .Must(x => !x.IsEmpty()).WithMessage("IdentificativiFiscali è obbligatorio");
            RuleFor(x => x.AltriDatiIdentificativi)
                .SetValidator(new AltriDatiIdentificativiValidator())
                .When(x => x.AltriDatiIdentificativi != null && !x.AltriDatiIdentificativi.IsEmpty());
        }
    }
}
