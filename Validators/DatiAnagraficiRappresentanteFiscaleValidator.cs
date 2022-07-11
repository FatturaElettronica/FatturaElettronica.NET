using FatturaElettronica.Common;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class DatiAnagraficiRappresentanteFiscaleValidator : AbstractValidator<DatiAnagrafici>
    {
        public DatiAnagraficiRappresentanteFiscaleValidator()
        {
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAValidator());
            RuleFor(x => x.CodiceFiscale)
                .Matches("^[A-Z0-9]{11,16}$")
                .When(x => !string.IsNullOrEmpty(x.CodiceFiscale));
            RuleFor(x => x.Anagrafica)
                .SetValidator(new AnagraficaValidator());
        }
    }
}