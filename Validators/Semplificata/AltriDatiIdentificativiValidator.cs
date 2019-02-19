using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation;

namespace FatturaElettronica.Validators.Semplificata
{
    public class AltriDatiIdentificativiValidator : AbstractValidator<AltriDatiIdentificativi>
    {
        const string expectedErrorCode = "00200";

        public AltriDatiIdentificativiValidator()
        {
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
            RuleFor(x => x.Sede)
                .SetValidator(new SedeCessionarioCommittenteValidator());
            RuleFor(x => x.StabileOrganizzazione)
                .SetValidator(new StabileOrganizzazioneValidator())
                .When(x => !x.StabileOrganizzazione.IsEmpty());
            RuleFor(x => x.RappresentanteFiscale)
                .SetValidator(new RappresentanteFiscaleCessionarioCommittenteValidator())
                .When(x => !x.RappresentanteFiscale.IsEmpty());
        }
    }
}
