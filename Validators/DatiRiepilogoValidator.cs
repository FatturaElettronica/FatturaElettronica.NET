using FluentValidation;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi;
using FatturaElettronica.Tabelle;
using System;
using FatturaElettronica.Extensions;

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
                .WithMessage("Natura non presente a fronte di Aliquota IVA pari a 0")
                .WithErrorCode("00429");
            RuleFor(x => x.Natura)
                .Must(string.IsNullOrEmpty)
                .When(x => x.AliquotaIVA > 0)
                .WithMessage("Natura presente a fronte di Aliquota IVA diversa da zero  (l’indicazione di un’aliquota IVA diversa da zero qualifica i dati di riepilogo come dati riferiti ad operazioni imponibili e quindi non è ammessa la presenza dell’elemento Natura, ad eccezione del caso in cui l’elemento TipoDocumento assume valore TD16)")
                .WithErrorCode("00430");
            RuleFor(x => x.Natura)
                .Must(natura => natura == null || !natura.StartsWith("N6"))
                .When(x => x.EsigibilitaIVA == "S")
                .WithMessage(
                    "Natura con valore di tipo 'N6' (inversione contabile) a fronte EsigiblitaIVA uguale a 'S' (scissione pagamenti)")
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
                                 .ToString("0.00"))) <= 0.01m);
        }
    }
}