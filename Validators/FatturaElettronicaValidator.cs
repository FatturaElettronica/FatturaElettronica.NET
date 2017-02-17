using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class FatturaElettronicaValidator : AbstractValidator<FatturaElettronica>
    {
        public FatturaElettronicaValidator()
        {
            RuleFor(dt => dt.FatturaElettronicaHeader)
                .SetValidator(new FatturaElettronicaHeaderValidator());
            RuleFor(dt => dt.FatturaElettronicaBody)
                .SetCollectionValidator(new FatturaElettronicaBodyValidator());
        }
    }
}
