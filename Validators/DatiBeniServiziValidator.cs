using FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class DatiBeniServiziValidator : AbstractValidator<DatiBeniServizi>
    {
        public DatiBeniServiziValidator()
        {
            RuleFor(x => x.DettaglioLinee).SetCollectionValidator(new DettaglioLineeValidator());
            RuleFor(x => x.DettaglioLinee).NotEmpty();
        }
    }
}
