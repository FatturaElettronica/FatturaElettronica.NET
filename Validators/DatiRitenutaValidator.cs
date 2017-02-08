using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Validators
{
    public class DatiRitenutaValidator : AbstractValidator<DatiRitenuta>
    {
        public DatiRitenutaValidator()
        {
            When(x => !x.IsEmpty(), () =>
            {
                RuleFor(x => x.TipoRitenuta).NotEmpty().TipoRitenutaDomain();
                RuleFor(x => x.ImportoRitenuta).NotNull();
                RuleFor(x => x.AliquotaRitenuta).NotNull();
                RuleFor(x => x.CausalePagamento).NotNull().CausalePagamentoDomain();
            });
        }
    }
}
