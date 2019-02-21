using FatturaElettronica.Ordinaria;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class FatturaValidator : AbstractValidator<Fattura>
    {
        public FatturaValidator()
        {
            RuleFor(dt => dt.FatturaElettronicaHeader)
                .SetValidator(new FatturaElettronicaHeaderValidator());
            RuleForEach(dt => dt.FatturaElettronicaBody)
                .SetValidator(new FatturaElettronicaBodyValidator());
        }
    }
}
