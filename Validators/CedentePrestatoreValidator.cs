using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class CedentePrestatoreValidator : AbstractValidator<CedentePrestatore>
    {
        public CedentePrestatoreValidator()
        {
            RuleFor(x => x.DatiAnagrafici).SetValidator(new DatiAnagraficiValidator());
        }
    }
}
