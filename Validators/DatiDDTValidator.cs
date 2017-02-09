using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Validators
{
    public class DatiDDTValidator : AbstractValidator<DatiDDT>
    {
        public DatiDDTValidator()
        {
            RuleFor(x => x.NumeroDDT).NotEmpty().Length(1, 20);
        }
    }
}
