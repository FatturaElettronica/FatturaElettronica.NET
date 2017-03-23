using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class CausaleValidator : AbstractValidator<string>
    {
        public CausaleValidator(int min, int max)
        {
            RuleFor(x => x)
                .NotEmpty()
                .Length(min, max)
                .Latin1SupplementValidator();
        }
    }
}
