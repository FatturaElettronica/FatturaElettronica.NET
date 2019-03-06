using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiGenerali;
using FluentValidation;

namespace FatturaElettronica.Validators.Semplificata
{
     public class DatiFatturaRettificataValidator : AbstractValidator<DatiFatturaRettificata>
    {
        public DatiFatturaRettificataValidator()
        {
            RuleFor(x => x.NumeroFR)
                .NotEmpty()
                .BasicLatinValidator()
                .Length(1, 20);
            RuleFor(x => x.DataFR)
                .NotEmpty();
            RuleFor(x => x.ElementiRettificati)
                .NotEmpty()
                .BasicLatinValidator()
                .Length(1, 1000);
        }
    }
}
