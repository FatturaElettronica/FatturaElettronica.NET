using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CedentePrestatore;
using FatturaElettronica.Tabelle;
using FatturaElettronica.Validators;
using FluentValidation;

namespace FatturaElettronica.Semplificata.Validators
{
    public class CedentePrestatoreValidator : AbstractValidator<CedentePrestatore>
    {
        const string expectedErrorCode = "00200";

        public CedentePrestatoreValidator()
        {

            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAValidator());
            RuleFor(x => x.CodiceFiscale)
                .Length(11, 16)
                .When(x => !string.IsNullOrEmpty(x.CodiceFiscale));
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
                .SetValidator(new SedeCedentePrestatoreValidator());
            RuleFor(x => x.StabileOrganizzazione)
                .SetValidator(new StabileOrganizzazioneValidator())
                .When(x => !x.StabileOrganizzazione.IsEmpty());
            RuleFor(x => x.IscrizioneREA)
                .SetValidator(new IscrizioneREAValidator())
                .When(x => !x.IscrizioneREA.IsEmpty());
            RuleFor(x => x.RegimeFiscale)
                .NotEmpty()
                .SetValidator(new RegimeFiscaleValidator<RegimeFiscale>());
        }
    }
}
