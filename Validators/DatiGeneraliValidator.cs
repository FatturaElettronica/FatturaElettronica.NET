using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Validators
{
    public class DatiGeneraliValidator : AbstractValidator<DatiGenerali>
    {
        public DatiGeneraliValidator()
        {
            RuleFor(x => x.DatiGeneraliDocumento).SetValidator(new DatiGeneraliDocumentoValidator());
        }
    }
}
