using FluentValidation;
using FatturaElettronica.Common;
namespace FatturaElettronica.Validators
{
    public abstract class DenominazioneNomeCognomeValidator<T> : AbstractValidator<T> where T : DenominazioneNomeCognome
    {
        public DenominazioneNomeCognomeValidator()
        {
            const string expectedErrorCode = "00200";

            RuleFor(x => x.Denominazione)
                .NotEmpty()
                .WithErrorCode(expectedErrorCode)
                .Length(1, 80)
                .WithErrorCode(expectedErrorCode)
                .Latin1SupplementValidator()
                .When(x => string.IsNullOrEmpty(x.CognomeNome));
            RuleFor(x => x.Denominazione)
                .Empty()
                .WithErrorCode(expectedErrorCode)
                .When(x => !string.IsNullOrEmpty(x.CognomeNome));
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithErrorCode(expectedErrorCode)
                .Length(1, 60)
                .WithErrorCode(expectedErrorCode)
                .Latin1SupplementValidator()
                .When(x => string.IsNullOrEmpty(x.Denominazione));
            RuleFor(x => x.Nome)
                .Empty()
                .WithErrorCode(expectedErrorCode)
                .When(x => !string.IsNullOrEmpty(x.Denominazione));
            RuleFor(x => x.Cognome)
                .NotEmpty()
                .WithErrorCode(expectedErrorCode)
                .Length(1, 60)
                .WithErrorCode(expectedErrorCode)
                .Latin1SupplementValidator()
                .When(x => string.IsNullOrEmpty(x.Denominazione));
            RuleFor(x => x.Cognome)
                .Empty()
                .WithErrorCode(expectedErrorCode)
                .When(x => !string.IsNullOrEmpty(x.Denominazione));
        }
    }
}
