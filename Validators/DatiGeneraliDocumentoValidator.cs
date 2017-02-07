using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Validators
{
    public class DatiGeneraliDocumentoValidator : AbstractValidator<DatiGeneraliDocumento>
    {
        public DatiGeneraliDocumentoValidator()
        {
            RuleFor(x => x.TipoDocumento).NotEmpty().TipoDocumentoDomain();
            RuleFor(x => x.Divisa).NotEmpty().DivisaDomain();
            RuleFor(x => x.Numero).NotEmpty().Length(1, 20);
            RuleFor(x => x.Numero).Matches(@"\d").WithMessage("Almeno un carattere numerico è necessario");
            RuleFor(x => x.DatiRitenuta).SetValidator(new DatiRitenutaValidator());

        }
    }
}
