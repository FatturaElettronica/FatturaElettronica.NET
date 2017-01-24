using FluentValidation;

namespace FatturaElettronica.Validators
{
    class FatturaElettronicaHeaderValidator : AbstractValidator<FatturaElettronicaHeader.FatturaElettronicaHeader>
    {
        public FatturaElettronicaHeaderValidator()
        {
            RuleFor(dt => dt.DatiTrasmissione).SetValidator(new DatiTrasmissioneValidator());
        }
    }
}
