using FluentValidation;
using FatturaElettronica.Common;

namespace FatturaElettronica.Validators
{
    public class DenominazioneNomeCognomeValidator : AbstractValidator<DenominazioneNomeCognome>
    {
        public DenominazioneNomeCognomeValidator()
        {
            RuleFor(x => x.Denominazione).NotEmpty().Length(1, 80).When(x => string.IsNullOrEmpty(x.CognomeNome));
            RuleFor(x => x.Denominazione).Empty().When(x => !string.IsNullOrEmpty(x.CognomeNome));

            RuleFor(x => x.Nome).NotEmpty().Length(1, 60).When(x => string.IsNullOrEmpty(x.Denominazione));
            RuleFor(x => x.Cognome).NotEmpty().Length(1, 60).When(x => string.IsNullOrEmpty(x.Denominazione));
            RuleFor(x => x.Nome).Empty().When(x => !string.IsNullOrEmpty(x.Denominazione));
            RuleFor(x => x.Cognome).Empty().When(x => !string.IsNullOrEmpty(x.Denominazione));
        }
    }
}
