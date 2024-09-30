using FatturaElettronica.Resources;
using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiGenerali;
using FluentValidation;
using Divisa = FatturaElettronica.Tabelle.Divisa;
using TipoDocumentoSemplificata = FatturaElettronica.Tabelle.TipoDocumentoSemplificata;

namespace FatturaElettronica.Validators.Semplificata
{
    public class DatiGeneraliDocumentoValidator : AbstractValidator<DatiGeneraliDocumento>
    {
        public DatiGeneraliDocumentoValidator()
        {
            RuleFor(x => x.TipoDocumento)
                .NotEmpty()
                .SetValidator(new IsValidValidator<DatiGeneraliDocumento, string, TipoDocumentoSemplificata>());
            RuleFor(x => x.Divisa)
                .NotEmpty()
                .SetValidator(new IsValidValidator<DatiGeneraliDocumento, string, Divisa>());
            RuleFor(x => x.Numero)
                .NotEmpty()
                .BasicLatinValidator()
                .Length(1, 20);
            RuleFor(x => x.Numero)
                .Matches(@"\d")
                .WithMessage(ValidatorMessages.E00425)
                .WithErrorCode("00425");
            RuleFor(x => x.BolloVirtuale)
                .Equal("SI")
                .When(x => x.BolloVirtuale != null);
        }
    }
}
