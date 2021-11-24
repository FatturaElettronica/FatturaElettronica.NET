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
        }
    }
}