using FluentValidation;
using FatturaElettronica.Common;
using FatturaElettronica.Extensions;

namespace FatturaElettronica.Validators
{
    public class ScontoMaggiorazioneValidator : AbstractValidator<ScontoMaggiorazione>
    {
        public ScontoMaggiorazioneValidator()
        {
            RuleFor(x => x.Tipo)
                .NotEmpty()
                .SetValidator(new IsValidValidator<ScontoMaggiorazione, string, Tabelle.ScontoMaggiorazione>());
            RuleFor(x => x.Tipo)
                .Must((challenge, _) => challenge.Importo != null || challenge.Percentuale != null)
                .WithMessage("Percentuale e Importo non presenti a fronte di Tipo valorizzato")
                .WithErrorCode("00437");
            RuleFor(x => x.Importo)
                .ScalePrecision8DecimalType();
            RuleFor(x => x.Percentuale)
                .ScalePrecisionPercentualeDecimalType();
        }
    }
}