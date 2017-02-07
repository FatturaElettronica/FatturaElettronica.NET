using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Validators
{
    public class DatiGeneraliDocumentoValidator : AbstractValidator<DatiGeneraliDocumento>
    {
        public DatiGeneraliDocumentoValidator()
        {
            RuleFor(x => x.TipoDocumento).NotEmpty().TipoDocumentoDomain();
        }
    }
}
