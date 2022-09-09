using FatturaElettronica.Semplificata.FatturaElettronicaHeader;
using FatturaElettronica.Tabelle;
using FluentValidation;

namespace FatturaElettronica.Validators.Semplificata
{
    public class FatturaElettronicaHeaderValidator : AbstractValidator<FatturaElettronicaHeader>
    {
        public FatturaElettronicaHeaderValidator()
        {
            RuleFor(x => x.DatiTrasmissione)
                .SetValidator(new DatiTrasmissioneValidator());
            RuleFor(x => x.CedentePrestatore)
                .SetValidator(new CedentePrestatoreValidator());
            RuleFor(x => x.CessionarioCommittente)
                .SetValidator(new CessionarioCommittenteValidator());
            RuleFor(x => x.SoggettoEmittente)
                .SetValidator(new IsValidValidator<FatturaElettronicaHeader, string, SoggettoEmittente>())
                .When(x => !string.IsNullOrEmpty(x.SoggettoEmittente));
            RuleFor(x => x)
                .Must((header, _) => HeaderValidateAgainstError00476(header))
                .WithMessage(
                    "Gli elementi IdPaese e IdPaese non possono essere entrambi valorizzati con codice diverso da IT")
                .WithErrorCode("00476");
        }

        private static bool HeaderValidateAgainstError00476(FatturaElettronicaHeader header)
        {
            var idCedente = header.CedentePrestatore.IdFiscaleIVA;
            var idCommittente = header.CessionarioCommittente.IdentificativiFiscali.IdFiscaleIVA;

            return (idCedente.IdPaese == "IT" || (idCommittente is not null && idCommittente.IdPaese == "IT"));
        }
    }
}