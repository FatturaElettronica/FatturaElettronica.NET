using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CedentePrestatore;
using FatturaElettronica.Tabelle;
using FluentValidation;

namespace FatturaElettronica.Validators.Semplificata
{
    public class CedentePrestatoreValidator : AbstractValidator<CedentePrestatore>
    {
        private const string ExpectedErrorCode = "00200";

        public CedentePrestatoreValidator()
        {
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAValidator());
            RuleFor(x => x.CodiceFiscale)
                .Matches("^[A-Z0-9]{11,16}$")
                .When(x => !string.IsNullOrEmpty(x.CodiceFiscale));
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
                .SetValidator(new SedeCedentePrestatoreValidator());
            RuleFor(x => x.StabileOrganizzazione)
                .SetValidator(new StabileOrganizzazioneValidator())
                .When(x => x.StabileOrganizzazione != null && !x.StabileOrganizzazione.IsEmpty());
            RuleFor(x => x.IscrizioneREA)
                .SetValidator(new IscrizioneREAValidator())
                .When(x => x.IscrizioneREA != null && !x.IscrizioneREA.IsEmpty());
            RuleFor(x => x.RegimeFiscale)
                .NotEmpty()
                .SetValidator(new IsValidValidator<CedentePrestatore, string, RegimeFiscale>());
        }
    }
}