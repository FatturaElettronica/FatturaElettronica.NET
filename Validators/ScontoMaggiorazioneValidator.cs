using FluentValidation;
using FatturaElettronica.Common;

namespace FatturaElettronica.Validators
{
    public class ScontoMaggiorazioneValidator : AbstractValidator<ScontoMaggiorazione>
    {
        public ScontoMaggiorazioneValidator()
        {
            RuleFor(x => x.Tipo)
                .NotEmpty()
                .SetValidator(new IsValidValidator<Tabelle.ScontoMaggiorazione>());
            RuleFor(x => x.Tipo)
                .Must((challenge, _) => challenge.Importo != null || challenge.Percentuale != null)
                .WithMessage("Percentuale e Importo non presenti a fronte di Tipo valorizzato")
                .WithErrorCode("00437");
            RuleFor(x => x.Tipo)
                .Must((challenge, _) => challenge.Importo == null || challenge.Percentuale == null)
                .WithErrorCode("00200");
        }
    }
}