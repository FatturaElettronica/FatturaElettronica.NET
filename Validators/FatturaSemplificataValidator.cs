using FatturaElettronica.Semplificata;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class FatturaSemplificataValidator : AbstractValidator<FatturaSemplificata>
    {
        public FatturaSemplificataValidator()
        {
            RuleFor(dt => dt.FatturaElettronicaHeader)
                .SetValidator(new Semplificata.Validators.FatturaElettronicaHeaderValidator());
            //RuleForEach(dt => dt.FatturaElettronicaBody)
            //    .SetValidator(new FatturaElettronicaBodyValidator());
        }
    }
}
