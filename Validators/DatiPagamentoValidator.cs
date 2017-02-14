using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiPagamento;

namespace FatturaElettronica.Validators
{
    public class DatiPagamentoValidator : AbstractValidator<DatiPagamento>
    {
        public DatiPagamentoValidator()
        {
            RuleFor(x => x.CondizioniPagamento).NotEmpty().IsValidCondizioniPagamentoValue();
            RuleFor(x => x.DettaglioPagamento).SetCollectionValidator(new DettaglioPagamentoValidator());
            RuleFor(x => x.DettaglioPagamento).NotEmpty();
        }
    }
}
