using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class DatiOrdineAcquistoValidator : AbstractValidator<DatiOrdineAcquisto>
    {
        public DatiOrdineAcquistoValidator()
        {
            RuleFor(x => x.IdDocumento).NotEmpty().Length(1, 20);
            RuleFor(x => x.NumItem).Length(1, 20).Unless(x => string.IsNullOrEmpty(x.NumItem));
            RuleFor(x => x.CodiceCommessaConvenzione).Length(1, 100).Unless(x => string.IsNullOrEmpty(x.CodiceCommessaConvenzione));
            RuleFor(x => x.CodiceCUP).Length(1, 15).Unless(x => string.IsNullOrEmpty(x.CodiceCUP));
            RuleFor(x => x.CodiceCIG).Length(1, 15).Unless(x => string.IsNullOrEmpty(x.CodiceCIG));
        }
    }
}
