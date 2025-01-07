using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi;
using FluentValidation;

namespace FatturaElettronica.Validators.Semplificata
{
    public class DatiIVAValidator : AbstractValidator<DatiIVA>
    {
        public DatiIVAValidator()
        {
            RuleFor(x => x.Imposta)
                .NotNull()
                .When(x => x.Aliquota == null);
            RuleFor(x => x.Aliquota)
                .NotNull()
                .LessThanOrEqualTo(100)
                .When(x => x.Imposta == null);
        }
    }
}