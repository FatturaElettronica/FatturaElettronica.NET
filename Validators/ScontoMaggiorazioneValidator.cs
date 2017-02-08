using FluentValidation;
using FatturaElettronica.Common;

namespace FatturaElettronica.Validators
{
    public class ScontoMaggiorazioneValidator : AbstractValidator<ScontoMaggiorazione>
    {
        public ScontoMaggiorazioneValidator()
        {
            RuleFor(x => x.Tipo).NotEmpty().IsValidScontoMaggiorazioneValue();
            RuleFor(x => x.Importo).NotNull().GreaterThan(0).Unless(x => x.Percentuale != null);
            RuleFor(x => x.Percentuale).NotNull().GreaterThan(0).Unless(x => x.Importo != null);
        }
    }
}
