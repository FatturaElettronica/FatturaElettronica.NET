using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiVeicoli;

namespace FatturaElettronica.Validators
{
    public class DatiVeicoliValidator : AbstractValidator<DatiVeicoli>
    {
        public DatiVeicoliValidator()
        {
            RuleFor(x => x.Data)
                .NotNull();
            RuleFor(x => x.TotalePercorso)
                .NotEmpty()
                .BasicLatinValidator()
                .Length(1, 15);
        }
    }
}
