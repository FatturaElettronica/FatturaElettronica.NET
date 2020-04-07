using FluentValidation;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Tabelle;

namespace FatturaElettronica.Validators
{
    public class DatiRitenutaValidator : AbstractValidator<DatiRitenuta>
    {
        public DatiRitenutaValidator()
        {
            RuleFor(x => x.TipoRitenuta)
                .NotEmpty()
                .SetValidator(new IsValidValidator<TipoRitenuta>());
            RuleFor(x => x.CausalePagamento)
                .NotEmpty()
                .SetValidator(new IsValidValidator<CausalePagamento>());
        }
    }
}
