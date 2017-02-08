using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class StabileOrganizzazioneValidator : AbstractValidator<Common.StabileOrganizzazione>
    {
        public StabileOrganizzazioneValidator()
        {
            When(x => !x.IsEmpty(), () =>
            {
                RuleFor(x => x.Indirizzo).NotEmpty().Length(1, 60);
                RuleFor(x => x.NumeroCivico).Length(1, 8);
                RuleFor(x => x.CAP).NotEmpty().Length(5);
                RuleFor(x => x.Comune).NotEmpty().Length(1, 60);
                RuleFor(x => x.Provincia).IsValidProvinciaValue().Unless(x => string.IsNullOrEmpty(x.Provincia));
                RuleFor(id => id.Nazione).NotEmpty().IsValidIdPaeseValue();
            });
        }
    }
}
