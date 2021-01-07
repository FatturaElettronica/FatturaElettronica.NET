using System.Text.RegularExpressions;
using FatturaElettronica.Tabelle;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public abstract class LocalitàBaseValidator<T> : AbstractValidator<T> where T : Common.Località
    {
        protected LocalitàBaseValidator()
        {
            RuleFor(x => x.Indirizzo)
                .NotEmpty()
                .Length(1, 60)
                .Latin1SupplementValidator();
            RuleFor(x => x.NumeroCivico)
                .Length(1, 8)
                .When(x => !string.IsNullOrEmpty(x.NumeroCivico));
            RuleFor(x => x.CAP)
                .NotEmpty()
                .Length(5)
                .Matches(@"^[0-9]+$");
            RuleFor(x => x.Comune)
                .NotEmpty()
                .Length(1, 60)
                .Latin1SupplementValidator();
            RuleFor(x => x.Provincia)
                .Matches(@"^[A-Z]{2}$")
                .When(x => !string.IsNullOrEmpty(x.Provincia));
            RuleFor(id => id.Nazione)
                .NotEmpty()
                .SetValidator(new IsValidValidator<IdPaese>());
        }
    }
}