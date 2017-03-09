using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class FatturaValidator : AbstractValidator<Fattura>
    {
        public FatturaValidator()
        {
            RuleFor(dt => dt.Header)
                .SetValidator(new HeaderValidator());
            RuleFor(dt => dt.Body)
                .SetCollectionValidator(new BodyValidator());
        }
    }
}
