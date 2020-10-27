using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CedentePrestatore;
using FluentValidation;
using FluentValidation.Validators;

namespace FatturaElettronica.Validators
{
    public class ContattiValidator : AbstractValidator<Contatti>
    {
        public ContattiValidator()
        {
            RuleFor(x => x.Telefono)
                .Length(5, 12)
                .When(x => !string.IsNullOrEmpty(x.Telefono));
            RuleFor(x => x.Fax)
                .Length(5, 12)
                .When(x => !string.IsNullOrEmpty(x.Fax));
            RuleFor(x => x.Email)
#pragma warning disable 618
                .EmailAddress(EmailValidationMode.Net4xRegex)
#pragma warning restore 618
                .When(x => !string.IsNullOrEmpty(x.Email));
        }
    }
}