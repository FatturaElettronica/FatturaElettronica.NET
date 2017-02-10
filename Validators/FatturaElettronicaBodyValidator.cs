using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class FatturaElettronicaBodyValidator : AbstractValidator<FatturaElettronicaBody.FatturaElettronicaBody>
    {
        public FatturaElettronicaBodyValidator()
        {
            RuleFor(x => x.DatiGenerali).SetValidator(new DatiGeneraliValidator());
            RuleFor(x => x.DatiBeniServizi).SetValidator(new DatiBeniServiziValidator());
            RuleFor(x => x.DatiBeniServizi).Must(x => !x.IsEmpty()).WithMessage("DatiBeniServizi è obbligatorio");
        }
    }
}
