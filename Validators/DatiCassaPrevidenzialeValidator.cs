using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Validators
{
    public class DatiCassaPrevidenzialeValidator : AbstractValidator<DatiCassaPrevidenziale>
    {
        public DatiCassaPrevidenzialeValidator()
        {
            RuleFor(x => x.TipoCassa).NotEmpty().IsValidTipoCassaValue();
            RuleFor(x => x.AlCassa).NotNull();
            RuleFor(x => x.ImportoContributoCassa).NotNull();
            RuleFor(x => x.AliquotaIVA).NotNull();
            RuleFor(x => x.Ritenuta).Equal("SI").Unless(x => string.IsNullOrEmpty(x.Ritenuta));
            RuleFor(x => x.Natura).NotEmpty().IsValidNaturaValue();
            RuleFor(x => x.RiferimentoAmministrazione).Length(1, 20);
        }
    }
}
