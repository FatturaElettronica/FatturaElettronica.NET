using FatturaElettronica.Ordinaria.FatturaElettronicaHeader;
using FatturaElettronica.Tabelle;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class FatturaElettronicaHeaderValidator : AbstractValidator<FatturaElettronicaHeader>
    {
        public FatturaElettronicaHeaderValidator()
        {
            RuleFor(x => x.DatiTrasmissione)
                .SetValidator(new DatiTrasmissioneValidator());
            RuleFor(x => x.CedentePrestatore)
                .SetValidator(new CedentePrestatoreValidator());
            RuleFor(x => x.Rappresentante)
                .SetValidator(new RappresentanteFiscaleValidator())
                .When(x => x.Rappresentante != null && !x.Rappresentante.IsEmpty());
            RuleFor(x => x.CessionarioCommittente)
                .SetValidator(new CessionarioCommittenteValidator());
            RuleFor(x => x.TerzoIntermediarioOSoggettoEmittente)
                .SetValidator(new TerzoIntermediarioOSoggettoEmittenteValidator())
                .When(x => x.TerzoIntermediarioOSoggettoEmittente != null &&
                           !x.TerzoIntermediarioOSoggettoEmittente.IsEmpty());
            RuleFor(x => x.SoggettoEmittente)
                .SetValidator(new IsValidValidator<FatturaElettronicaHeader, string, SoggettoEmittente>())
                .When(x => !string.IsNullOrEmpty(x.SoggettoEmittente));
            RuleFor(x => x.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese)
                .Must(idPaese => idPaese != "IT")
                .When(x => x.DatiTrasmissione.CodiceDestinatario == "XXXXXXX")
                .WithErrorCode("00313");
            RuleFor(x => x)
                .Must((header, _) => HeaderValidateAgainstError00476(header))
                .WithMessage(
                    "Gli elementi IdPaese e IdPaese non possono essere entrambi valorizzati con codice diverso da IT")
                .WithErrorCode("00476");
        }

        private static bool HeaderValidateAgainstError00476(FatturaElettronicaHeader header)
        {
            var idCedente = header.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdPaese;
            var idCommittente =
                header.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA is null ||
                header.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IsEmpty()
                    ? ""
                    : header.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese;

            return idCedente == "IT" || idCommittente is "IT" or "";
        }
    }
}