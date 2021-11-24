using FatturaElettronica.Extensions;
using FluentValidation;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Tabelle;

namespace FatturaElettronica.Validators
{
    public class DatiCassaPrevidenzialeValidator : AbstractValidator<DatiCassaPrevidenziale>
    {
        public DatiCassaPrevidenzialeValidator()
        {
            RuleFor(x => x.TipoCassa)
                .NotEmpty()
                .SetValidator(new IsValidValidator<DatiCassaPrevidenziale, string, TipoCassa>());
            RuleFor(x => x.AlCassa)
                .NotNull();
            RuleFor(x => x.ImportoContributoCassa)
                .NotNull();
            RuleFor(x => x.AliquotaIVA)
                .NotNull();
            RuleFor(x => x.Ritenuta)
                .Equal("SI")
                .When(x => !string.IsNullOrEmpty(x.Ritenuta));
            RuleFor(x => x.Natura)
                .NotEmpty()
                .When(x => x.AliquotaIVA == 0).WithErrorCode("00413");
            RuleFor(x => x.Natura)
                .SetValidator(new IsValidValidator<DatiCassaPrevidenziale, string, Natura>())
                .When(x => x.AliquotaIVA == 0);
            RuleFor(x => x.Natura)
                .Empty()
                .When(x => x.AliquotaIVA != 0).WithErrorCode("00414");
            RuleFor(x => x.RiferimentoAmministrazione)
                .Length(1, 20)
                .BasicLatinValidator()
                .When(x => !string.IsNullOrEmpty(x.RiferimentoAmministrazione));
            RuleFor(x => x.ImportoContributoCassa)
                .ScalePrecision2DecimalType();
            RuleFor(x => x.ImponibileCassa)
                .ScalePrecision2DecimalType();
        }
    }
}