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
                .When(x => x.TerzoIntermediarioOSoggettoEmittente != null && !x.TerzoIntermediarioOSoggettoEmittente.IsEmpty());
            RuleFor(x => x.SoggettoEmittente)
                .SetValidator(new IsValidValidator<SoggettoEmittente>())
                .When(x => !string.IsNullOrEmpty(x.SoggettoEmittente));
        }
    }
}
