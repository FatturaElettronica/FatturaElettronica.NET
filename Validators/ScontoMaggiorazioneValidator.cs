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
                .Must((challenge, _) => !((challenge.Importo == 0 || challenge.Importo == null) && (challenge.Percentuale == 0 || challenge.Percentuale == null)))
                .WithMessage("Percentuale e Importo non presenti a fronte di Tipo valorizzato")
                .WithErrorCode("00437");

            RuleFor(x => x.Importo).NotNull().Must(x => x != 0).Unless(x => x.Percentuale != null);
            RuleFor(x => x.Percentuale).NotNull().GreaterThan(0).Unless(x => x.Importo != null);
        }
    }
}
