using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Tabelle;

namespace FatturaElettronica.Validators
{
    public class DatiCassaPrevidenzialeValidator : AbstractValidator<DatiCassaPrevidenziale>
    {
        public DatiCassaPrevidenzialeValidator()
        {
            RuleFor(x => x.TipoCassa).NotEmpty().SetValidator(new IsValidValidator<TipoCassa>());
            RuleFor(x => x.AlCassa).NotNull();
            RuleFor(x => x.ImportoContributoCassa).NotNull();
            RuleFor(x => x.AliquotaIVA).NotNull();
            RuleFor(x => x.Ritenuta).Equal("SI").Unless(x => string.IsNullOrEmpty(x.Ritenuta));
            RuleFor(x => x.Natura).NotEmpty().SetValidator(new IsValidValidator<Natura>());
            RuleFor(x => x.RiferimentoAmministrazione).Length(1, 20);
        }
    }
}
