using FatturaElettronica.FatturaElettronicaHeader.RappresentanteFiscale;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class RappresentanteFiscaleValidator : AbstractValidator<RappresentanteFiscale>
    {
        public RappresentanteFiscaleValidator()
        {
            RuleFor(x => x.DatiAnagrafici)
                .SetValidator(new DatiAnagraficiRappresentanteFiscaleValidator());
        }
    }
}
