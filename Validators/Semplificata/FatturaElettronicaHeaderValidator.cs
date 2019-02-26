namespace FatturaElettronica.Validators.Semplificata
{
    using FatturaElettronica.Semplificata.FatturaElettronicaHeader;
    using FatturaElettronica.Tabelle;
    using FatturaElettronica.Validators;
    using FluentValidation;

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
                .SetValidator(new IsValidValidator<SoggettoEmittente>())
                .When(x => !string.IsNullOrEmpty(x.SoggettoEmittente));
        }
    }
}
