using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class FatturaElettronicaHeaderValidator : AbstractValidator<FatturaElettronicaHeader.FatturaElettronicaHeader>
    {
        public FatturaElettronicaHeaderValidator()
        {
            RuleFor(x => x.DatiTrasmissione).SetValidator(new DatiTrasmissioneValidator());
            RuleFor(x => x.CedentePrestatore).SetValidator(new CedentePrestatoreValidator());
            RuleFor(x => x.Rappresentante).SetValidator(new RappresentanteFiscaleValidator());
            RuleFor(x => x.CessionarioCommittente).SetValidator(new CessionarioCommittenteValidator());
            RuleFor(x => x.TerzoIntermediarioOSoggettoEmittente).SetValidator(new TerzoIntermediarioOSoggettoEmittenteValidator());
            RuleFor(x => x.SoggettoEmittente).IsValidSoggettoEmittenteValue().Unless(x => string.IsNullOrEmpty(x.SoggettoEmittente));
        }
    }
}
