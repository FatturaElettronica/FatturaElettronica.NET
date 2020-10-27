using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation;

namespace FatturaElettronica.Validators.Semplificata
{
    public class AltriDatiIdentificativiValidator : AbstractValidator<AltriDatiIdentificativi>
    {
        private const string ExpectedErrorCode = "00200";

        public AltriDatiIdentificativiValidator()
        {
            RuleFor(x => x.Denominazione)
                .NotEmpty()
                .WithErrorCode(ExpectedErrorCode)
                .Length(1, 80)
                .WithErrorCode(ExpectedErrorCode)
                .Latin1SupplementValidator()
                .When(x => string.IsNullOrEmpty(x.CognomeNome));
            RuleFor(x => x.Denominazione)
                .Empty()
                .WithErrorCode(ExpectedErrorCode)
                .When(x => !string.IsNullOrEmpty(x.CognomeNome));
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithErrorCode(ExpectedErrorCode)
                .Length(1, 60)
                .WithErrorCode(ExpectedErrorCode)
                .Latin1SupplementValidator()
                .When(x => string.IsNullOrEmpty(x.Denominazione));
            RuleFor(x => x.Nome)
                .Empty()
                .WithErrorCode(ExpectedErrorCode)
                .When(x => !string.IsNullOrEmpty(x.Denominazione));
            RuleFor(x => x.Cognome)
                .NotEmpty()
                .WithErrorCode(ExpectedErrorCode)
                .Length(1, 60)
                .WithErrorCode(ExpectedErrorCode)
                .Latin1SupplementValidator()
                .When(x => string.IsNullOrEmpty(x.Denominazione));
            RuleFor(x => x.Cognome)
                .Empty()
                .WithErrorCode(ExpectedErrorCode)
                .When(x => !string.IsNullOrEmpty(x.Denominazione));
            RuleFor(x => x.Sede)
                .SetValidator(new SedeCessionarioCommittenteValidator());
            RuleFor(x => x.StabileOrganizzazione)
                .SetValidator(new StabileOrganizzazioneValidator())
                .When(x => x.StabileOrganizzazione != null && !x.StabileOrganizzazione.IsEmpty());
            RuleFor(x => x.RappresentanteFiscale)
                .SetValidator(new RappresentanteFiscaleCessionarioCommittenteValidator())
                .When(x => x.RappresentanteFiscale != null && !x.RappresentanteFiscale.IsEmpty());
        }
    }
}