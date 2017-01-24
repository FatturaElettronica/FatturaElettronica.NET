using FatturaElettronica.Common;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class DatiAnagraficiValidator : AbstractValidator<DatiAnagrafici>
    {
        public DatiAnagraficiValidator()
        {
            RuleFor(x => x.Anagrafica).SetValidator(new AnagraficaValidator());
        }
    }
}
