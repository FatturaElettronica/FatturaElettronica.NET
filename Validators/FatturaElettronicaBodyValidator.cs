using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class FatturaElettronicaBodyValidator : AbstractValidator<FatturaElettronicaBody.FatturaElettronicaBody>
    {
        public FatturaElettronicaBodyValidator()
        {
            RuleFor(x => x.DatiGenerali).SetValidator(new DatiGeneraliValidator());
        }
    }
}
