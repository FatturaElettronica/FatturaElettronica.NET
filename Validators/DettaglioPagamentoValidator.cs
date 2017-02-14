using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiPagamento;

namespace FatturaElettronica.Validators
{
    public class DettaglioPagamentoValidator : AbstractValidator<DettaglioPagamento>
    {
        public DettaglioPagamentoValidator()
        {
            RuleFor(x => x.Beneficiario).Length(1, 200).When(x=>!string.IsNullOrEmpty(x.Beneficiario));
            RuleFor(x => x.ModalitaPagamento).NotEmpty().IsValidModalitaPagamentoValue();
            RuleFor(x => x.CodUfficioPostale).Length(1, 20).When(x => !string.IsNullOrEmpty(x.CodUfficioPostale));
            RuleFor(x => x.CognomeQuietanzante).Length(1, 60).When(x => !string.IsNullOrEmpty(x.CognomeQuietanzante));
            RuleFor(x => x.NomeQuietanzante).Length(1, 60).When(x => !string.IsNullOrEmpty(x.NomeQuietanzante));
            RuleFor(x => x.CFQuietanzante).Length(1, 16).When(x => !string.IsNullOrEmpty(x.CFQuietanzante));
            RuleFor(x => x.TitoloQuietanzante).Length(2, 10).When(x => !string.IsNullOrEmpty(x.TitoloQuietanzante));
            RuleFor(x => x.IstitutoFinanziario).Length(1, 80).When(x => !string.IsNullOrEmpty(x.IstitutoFinanziario));
            RuleFor(x => x.IBAN).Length(15, 34).When(x => !string.IsNullOrEmpty(x.IBAN));
            RuleFor(x => x.ABI).Length(5).When(x => !string.IsNullOrEmpty(x.ABI));
            RuleFor(x => x.CAB).Length(5).When(x => !string.IsNullOrEmpty(x.CAB));
            RuleFor(x => x.BIC).Length(8, 11).When(x => !string.IsNullOrEmpty(x.BIC));
            RuleFor(x => x.CodicePagamento).Length(1, 60).When(x => !string.IsNullOrEmpty(x.CodicePagamento));
        }
    }
}
