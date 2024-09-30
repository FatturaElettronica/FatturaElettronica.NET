using FluentValidation;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi;
using System;
using FatturaElettronica.Extensions;
using FatturaElettronica.Resources;
using EsigibilitaIVA = FatturaElettronica.Tabelle.EsigibilitaIVA;
using Natura = FatturaElettronica.Tabelle.Natura;

namespace FatturaElettronica.Validators
{
    public class DatiRiepilogoValidator : AbstractValidator<DatiRiepilogo>
    {
        public DatiRiepilogoValidator()
        {
            RuleFor(x => x.Natura)
                .SetValidator(new IsValidValidator<DatiRiepilogo, string, Natura>())
                .When(x => !string.IsNullOrEmpty(x.Natura));
            RuleFor(x => x.Natura)
                .Must(natura => !string.IsNullOrEmpty(natura))
                .When(x => x.AliquotaIVA == 0)
                .WithMessage(ValidatorMessages.E00429)
                .WithErrorCode("00429");
            RuleFor(x => x.Natura)
                .Must(natura => natura == null || !natura.StartsWith("N6"))
                .When(x => x.EsigibilitaIVA == "S")
                .WithMessage(ValidatorMessages.E00420)
                .WithErrorCode("00420");
            RuleFor(x => x.Imposta)
                .Must((challenge, _) => ImpostaValidateAgainstError00421(challenge))
                .WithErrorCode("00421");
            RuleFor(x => x.EsigibilitaIVA)
                .SetValidator(new IsValidValidator<DatiRiepilogo, string, EsigibilitaIVA>())
                .When(x => !string.IsNullOrEmpty(x.EsigibilitaIVA));
            RuleFor(x => x.RiferimentoNormativo)
                .Length(1, 100)
                .Latin1SupplementValidator()
                .When(x => !string.IsNullOrEmpty(x.RiferimentoNormativo));
            RuleFor(x => x.SpeseAccessorie)
                .ScalePrecision2DecimalType();
            RuleFor(x => x.ImponibileImporto)
                .ScalePrecision2DecimalType();
            RuleFor(x => x.Imposta)
                .ScalePrecision2DecimalType();
            RuleFor(x => x.Arrotondamento)
                .ScalePrecision8DecimalType();
        }

        private static bool ImpostaValidateAgainstError00421(DatiRiepilogo datiRiepilogo)
        {
            return (Math.Abs(datiRiepilogo.Imposta -
                             decimal.Parse(((datiRiepilogo.AliquotaIVA * datiRiepilogo.ImponibileImporto) / 100)
                                 .ToString("0.00"))) <= 0.019m);
        }
    }
}
