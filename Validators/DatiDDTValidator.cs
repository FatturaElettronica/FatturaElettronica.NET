using FluentValidation;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Validators
{
    public class DatiDDTValidator : AbstractValidator<DatiDDT>
    {
        public DatiDDTValidator()
        {
            RuleFor(x => x.NumeroDDT)
                .NotEmpty()
                .BasicLatinValidator()
                .Length(1, 20);
            RuleForEach(x => x.RiferimentoNumeroLinea)
                .InclusiveBetween(1, 9999)
                .WithMessage("Valori consentiti 1-9999");
        }
    }
}
