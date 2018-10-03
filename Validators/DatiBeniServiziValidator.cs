using FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class DatiBeniServiziValidator : AbstractValidator<DatiBeniServizi>
    {
        public DatiBeniServiziValidator()
        {
            RuleForEach(x => x.DettaglioLinee)
                .SetValidator(new DettaglioLineeValidator());
            RuleFor(x => x.DettaglioLinee)
                .NotEmpty();
            RuleForEach(x => x.DatiRiepilogo)
                .SetValidator(new DatiRiepilogoValidator());
            RuleFor(x => x.DatiRiepilogo)
                .NotEmpty();
        }
    }
}
