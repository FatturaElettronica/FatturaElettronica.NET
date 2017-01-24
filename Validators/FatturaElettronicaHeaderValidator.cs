using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class FatturaElettronicaHeaderValidator : AbstractValidator<FatturaElettronicaHeader.FatturaElettronicaHeader>
    {
        public FatturaElettronicaHeaderValidator()
        {
            RuleFor(x => x.DatiTrasmissione).SetValidator(new DatiTrasmissioneValidator());
            RuleFor(x => x.CedentePrestatore).SetValidator(new CedentePrestatoreValidator());
        }
    }
}
