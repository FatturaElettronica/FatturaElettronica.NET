using FluentValidation;
using FatturaElettronica.Extensions;
using FatturaElettronica.Resources;
using ScontoMaggiorazione = FatturaElettronica.Common.ScontoMaggiorazione;

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
                .WithMessage(ValidatorMessages.E00437)
                .WithErrorCode("00437");
            RuleFor(x => x.Importo)
                .ScalePrecision8DecimalType();
            RuleFor(x => x.Percentuale)
                .ScalePrecisionPercentualeDecimalType();
        }
    }
}
