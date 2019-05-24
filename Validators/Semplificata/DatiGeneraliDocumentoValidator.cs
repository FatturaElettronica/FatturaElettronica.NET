using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Tabelle;
using FluentValidation;

namespace FatturaElettronica.Validators.Semplificata
{
    public class DatiGeneraliDocumentoValidator : AbstractValidator<DatiGeneraliDocumento>
    {
        public DatiGeneraliDocumentoValidator()
        {
            RuleFor(x => x.TipoDocumento)
                .NotEmpty()
                .SetValidator(new IsValidValidator<TipoDocumentoSemplificata>());
            RuleFor(x => x.Divisa)
                .NotEmpty()
                .SetValidator(new IsValidValidator<Divisa>());
            RuleFor(x => x.Numero)
                .NotEmpty()
                .BasicLatinValidator()
                .Length(1, 20);
            RuleFor(x => x.Numero)
                .Matches(@"\d")
                .WithMessage("Numero non contiene caratteri numerici")
                .WithErrorCode("00425");
        }
    }
}
