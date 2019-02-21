namespace FatturaElettronica.Validators.Semplificata
{
    using FatturaElettronica.Semplificata;
    using FluentValidation;

    public class FatturaSemplificataValidator : AbstractValidator<FatturaSemplificata>
    {
        public FatturaSemplificataValidator()
        {
            RuleFor(dt => dt.FatturaElettronicaHeader)
                .SetValidator(new FatturaElettronicaHeaderValidator());
            //RuleForEach(dt => dt.FatturaElettronicaBody)
            //    .SetValidator(new FatturaElettronicaBodyValidator());
        }
    }
}
