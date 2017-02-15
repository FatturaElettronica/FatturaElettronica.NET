using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Tabelle;

namespace FatturaElettronica.Validators
{
    public class DatiRitenutaValidator : AbstractValidator<DatiRitenuta>
    {
        public DatiRitenutaValidator()
        {
            When(x => !x.IsEmpty(), () =>
            {
                RuleFor(x => x.TipoRitenuta).NotEmpty().SetValidator(new IsValidValidator<TipoRitenuta>());
                RuleFor(x => x.ImportoRitenuta).NotNull();
                RuleFor(x => x.AliquotaRitenuta).NotNull();
                RuleFor(x => x.CausalePagamento).NotEmpty().SetValidator(new IsValidValidator<CausalePagamento>());
            });
        }
    }
}
