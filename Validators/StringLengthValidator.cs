using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class StringLengthValidator : AbstractValidator<string>
    {
        public StringLengthValidator(int min, int max)
        {
            RuleFor(x => x).NotEmpty().Length(min, max);
        }
    }
}
