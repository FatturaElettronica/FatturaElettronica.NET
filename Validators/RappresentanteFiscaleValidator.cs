using FatturaElettronica.FatturaElettronicaHeader.RappresentanteFiscale;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class RappresentanteFiscaleValidator : AbstractValidator<RappresentanteFiscale>
    {
        public RappresentanteFiscaleValidator()
        {
            When(x => !x.IsEmpty(), () =>
            {
                RuleFor(x => x.DatiAnagrafici).SetValidator(new DatiAnagraficiValidator());
            });
        }
    }
}
