using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi;

namespace FatturaElettronica.Validators
{
    public class CodiceArticoloValidator : AbstractValidator<CodiceArticolo>
    {
        public CodiceArticoloValidator()
        {
            RuleFor(x => x.CodiceTipo)
                .NotEmpty()
                .Length(1, 35);
            RuleFor(x => x.CodiceValore)
                .NotEmpty()
                .Length(1, 35);
        }
    }
}
