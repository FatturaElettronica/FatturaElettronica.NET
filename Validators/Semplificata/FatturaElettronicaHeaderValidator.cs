using FatturaElettronica.Resources;
using FatturaElettronica.Semplificata.FatturaElettronicaHeader;
using FluentValidation;
using SoggettoEmittente = FatturaElettronica.Tabelle.SoggettoEmittente;

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
                .WithMessage(ValidatorMessages.E00476)
                .WithErrorCode("00476");
        }

        private static bool HeaderValidateAgainstError00476(FatturaElettronicaHeader header)
        {
            var idCedente = header.CedentePrestatore.IdFiscaleIVA.IdPaese;
            var idCommittente =
                header.CessionarioCommittente.IdentificativiFiscali.IdFiscaleIVA is null ||
                header.CessionarioCommittente.IdentificativiFiscali.IdFiscaleIVA.IsEmpty()
                    ? ""
                    : header.CessionarioCommittente.IdentificativiFiscali.IdFiscaleIVA.IdPaese;

            return idCedente == "IT" || idCommittente is "IT" or "";
        }
    }
}
