using System;
using System.Linq;
using FatturaElettronica.Ordinaria;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody;
using FatturaElettronica.Resources;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class FatturaOrdinariaValidator : AbstractValidator<FatturaOrdinaria>
    {
        public FatturaOrdinariaValidator()
        {
            RuleFor(x => x.FatturaElettronicaHeader)
                .SetValidator(new FatturaElettronicaHeaderValidator());
            RuleFor(x => x)
                .Must((fattura, _) => FatturaValidateAgainstError00475(fattura))
                .WithMessage(ValidatorMessages.E00475)
                .WithErrorCode("00475");
            RuleFor(x => x)
                .Must((fattura, _) => FatturaValidateAgainstError00471(fattura))
                .WithMessage(ValidatorMessages.E00471)
                .WithErrorCode("00471");
            RuleFor(x => x)
                .Must((fattura, _) => FatturaValidateAgainstError00472(fattura))
                .WithMessage(ValidatorMessages.E00472)
                .WithErrorCode("00472");
            RuleFor(x => x)
                .Must((fattura, _) => FatturaValidateAgainstError00473(fattura))
                .WithMessage(ValidatorMessages.E00473)
                .WithErrorCode("00473");
            RuleForEach(x => x.FatturaElettronicaBody)
                .SetValidator(new FatturaElettronicaBodyValidator());
            RuleForEach(x => x.FatturaElettronicaBody)
                .Must((_, body) => BodyValidateAgainstError00443(body))
                .WithMessage(ValidatorMessages.E00443)
                .WithErrorCode("00443");
            RuleForEach(x => x.FatturaElettronicaBody)
                .Must((_, body) => BodyValidateAgainstError00444(body))
                .WithMessage(ValidatorMessages.E00444)
                .WithErrorCode("00444");
            RuleForEach(x => x.FatturaElettronicaBody)
                .Must((_, body) => BodyValidateAgainstError00401(body))
                .WithMessage(ValidatorMessages.E00401)
                .WithErrorCode("00401");
            RuleForEach(x => x.FatturaElettronicaBody)
                .Must((_, body) => BodyValidateAgainstError00430(body))
                .WithMessage(ValidatorMessages.E00430)
                .WithErrorCode("00430");
        }

        private static bool FatturaValidateAgainstError00475(FatturaOrdinaria fatturaOrdinaria)
        {
            var tipiDocumento = new[] { "TD16", "TD17", "TD18", "TD19", "TD20", "TD22", "TD23" };

            if (!fatturaOrdinaria.FatturaElettronicaBody.Any(x =>
                    tipiDocumento.Contains(x.DatiGenerali.DatiGeneraliDocumento.TipoDocumento)))
                return true;

            var idFiscaleIva = fatturaOrdinaria.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici
                .IdFiscaleIVA;

            return idFiscaleIva != null && !idFiscaleIva.IsEmpty();
        }

        private static bool FatturaValidateAgainstError00473(FatturaOrdinaria fatturaOrdinaria)
        {
            var cedente = fatturaOrdinaria.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici;

            if (cedente.IdFiscaleIVA.IdPaese != "IT")
                return true;

            var tipiDocumento = new[] { "TD17", "TD18", "TD19", "TD28" };

            var success = fatturaOrdinaria.FatturaElettronicaBody.All(x =>
                !tipiDocumento.Contains(x.DatiGenerali.DatiGeneraliDocumento.TipoDocumento));

            return success;
        }

        private static bool FatturaValidateAgainstError00472(FatturaOrdinaria fatturaOrdinaria)
        {
            var bodies =
                fatturaOrdinaria.FatturaElettronicaBody.Where(x =>
                    x.DatiGenerali.DatiGeneraliDocumento.TipoDocumento is "TD21" or "TD27");

            if (!bodies.Any())
                return true;

            var cedente = fatturaOrdinaria.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici;
            var cessionario =
                fatturaOrdinaria.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici;

            if (cessionario.IdFiscaleIVA.IsEmpty() && cessionario.CodiceFiscale == cedente.CodiceFiscale)
                // Vedi https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/388
                return true;

            if (string.IsNullOrEmpty(cessionario.CodiceFiscale) &&
                cedente.IdFiscaleIVA?.ToString() == cessionario.IdFiscaleIVA?.ToString())
                return true;

            return cedente.IdFiscaleIVA?.ToString() == cessionario.IdFiscaleIVA?.ToString() &&
                   cedente.CodiceFiscale == cessionario.CodiceFiscale;
        }

        private static bool FatturaValidateAgainstError00471(FatturaOrdinaria fatturaOrdinaria)
        {
            var cedente = fatturaOrdinaria.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA
                .ToString();
            var cessionario = fatturaOrdinaria.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici
                .IdFiscaleIVA.ToString();

            var tipiDocumento = new[]
            {
                "TD01", "TD02", "TD03", "TD06", "TD16", "TD17", "TD18", "TD19", "TD20", "TD24", "TD25", "TD28"
            };

            return cedente != cessionario || fatturaOrdinaria.FatturaElettronicaBody.All(x =>
                !tipiDocumento.Contains(x.DatiGenerali.DatiGeneraliDocumento.TipoDocumento));
        }

        private static bool BodyValidateAgainstError00444(FatturaElettronicaBody body)
        {
            var cassaPrevidenziale = body.DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale;
            var dettaglioLinee = body.DatiBeniServizi.DettaglioLinee;

            var nature = dettaglioLinee.Select(x => x.Natura)
                .Concat(cassaPrevidenziale.Select(x => x.Natura))
                .ToArray();

            var riepilogo = body.DatiBeniServizi.DatiRiepilogo.Select(x => x.Natura);

            return nature.All(natura => riepilogo.Contains(natura)) &&
                   riepilogo.All(natura => nature.Contains(natura));
        }

        private static bool BodyValidateAgainstError00443(FatturaElettronicaBody body)
        {
            var cassaPrevidenziale = body.DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale;
            var dettaglioLinee = body.DatiBeniServizi.DettaglioLinee;

            var aliquote = dettaglioLinee.Select(x => x.AliquotaIVA)
                .Concat(cassaPrevidenziale.Select(x => x.AliquotaIVA))
                .ToArray();

            var riepilogo = body.DatiBeniServizi.DatiRiepilogo.Select(x => x.AliquotaIVA);

            return aliquote.All(aliquota => riepilogo.Contains(aliquota)) &&
                   riepilogo.All(aliquota => aliquote.Contains(aliquota));
        }

        private bool BodyValidateAgainstError00401(FatturaElettronicaBody body)
        {
            if (body.DatiGenerali.DatiGeneraliDocumento.TipoDocumento == "TD16")
            {
                return true;
            }

            return body.DatiBeniServizi.DettaglioLinee.All(x =>
                x.AliquotaIVA > 0 && string.IsNullOrEmpty(x.Natura) ||
                x.AliquotaIVA == 0 && !string.IsNullOrEmpty(x.Natura));
        }

        private bool BodyValidateAgainstError00430(FatturaElettronicaBody body)
        {
            if (body.DatiGenerali.DatiGeneraliDocumento.TipoDocumento == "TD16")
            {
                return true;
            }

            return body.DatiBeniServizi.DatiRiepilogo.All(x =>
                x.AliquotaIVA > 0 && string.IsNullOrEmpty(x.Natura) ||
                x.AliquotaIVA == 0 && !string.IsNullOrEmpty(x.Natura));
        }
    }
}
