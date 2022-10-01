using System;
using System.Linq;
using FatturaElettronica.Ordinaria;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody;
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
                .WithMessage(
                    "Per il valore indicato nell’elemento TipoDocumento deve essere presente l’elemento IdFiscaleIVA del cessionario/committente (i tipi documento TD16, TD17, TD18, TD19, TD20, TD22, TD23 e TD28 prevedono obbligatoriamente la presenza della partita IVA del cessionario/committente)")
                .WithErrorCode("00475");
            RuleFor(x => x)
                .Must((fattura, _) => FatturaValidateAgainstError00471(fattura))
                .WithMessage(
                    "I valori TD01, TD02, TD03, TD06, TD16, TD17, TD18, TD19, TD20, TD24, TD25 e TD28 del tipo documento non ammettono l’indicazione in fattura dello stesso soggetto sia come cedente che come cessionario")
                .WithErrorCode("00471");
            RuleFor(x => x)
                .Must((fattura, _) => FatturaValidateAgainstError00472(fattura))
                .WithMessage(
                    "I valori TD21 e TD27 del tipo documento non ammettono l’indicazione in fattura di un cedente diverso dal cessionario")
                .WithErrorCode("00472");
            RuleFor(x => x)
                .Must((fattura, _) => FatturaValidateAgainstError00473(fattura))
                .WithMessage(
                    "Per il valore indicato nell’elemento TipoDocumento il valore presente nell’elemento IdPaese non è ammesso (i valori TD17, TD18, TD19 e TD28 del tipo documento non ammettono l’indicazione in fattura di un cedente italiano. Nei casi di TD17 e TD19 è ammessa l’indicazione del valore ‘OO’ nell’elemento IdPaese per operazioni effettuate da soggetti residenti in Livigno e Campione d’Italia. Inoltre, nel caso del TD28, l’elemento IdPaese deve essere valorizzato con il valore SM)")
                .WithErrorCode("00473");
            RuleForEach(x => x.FatturaElettronicaBody)
                .SetValidator(new FatturaElettronicaBodyValidator());
            RuleForEach(x => x.FatturaElettronicaBody)
                .Must((_, body) => BodyValidateAgainstError00443(body))
                .WithMessage(
                    "Tutti i valori delle aliquote IVA presenti nelle linee di dettaglio di una fattura o nei dati di cassa previdenziale devono essere presenti anche nei dati di riepilogo")
                .WithErrorCode("00443");
            RuleForEach(x => x.FatturaElettronicaBody)
                .Must((_, body) => BodyValidateAgainstError00444(body))
                .WithMessage(
                    "Tutti i valori di natura dell’operazione presenti nelle linee di dettaglio di una fattura o nei dati di cassa previdenziale devono essere presenti anche nei dati di riepilogo")
                .WithErrorCode("00444");
            RuleForEach(x => x.FatturaElettronicaBody)
                .Must((_, body) => BodyValidateAgainstError00401(body))
                .WithMessage(
                    "Natura presente a fronte di Aliquota IVA diversa da zero (l’indicazione di un’aliquota IVA diversa da zero qualifica l’operazione come imponibile e quindi non è ammessa la presenza dell’elemento Natura, ad eccezione del caso in cui l’elemento TipoDocumento assume valore TD16)")
                .WithErrorCode("00401");
            RuleForEach(x => x.FatturaElettronicaBody)
                .Must((_, body) => BodyValidateAgainstError00430(body))
                .WithMessage(
                    "Natura presente a fronte di Aliquota IVA diversa da zero (l’indicazione di un’aliquota IVA diversa da zero qualifica l’operazione come imponibile e quindi non è ammessa la presenza dell’elemento Natura, ad eccezione del caso in cui l’elemento TipoDocumento assume valore TD16)")
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

            return fatturaOrdinaria.FatturaElettronicaBody.All(x =>
                !tipiDocumento.Contains(x.DatiGenerali.DatiGeneraliDocumento.TipoDocumento));
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

            return cedente.IdFiscaleIVA?.ToString() == cessionario.IdFiscaleIVA?.ToString() &&
                   cedente.CodiceFiscale == cessionario.CodiceFiscale;
        }

        private static bool FatturaValidateAgainstError00471(FatturaOrdinaria fatturaOrdinaria)
        {
            var cedente = fatturaOrdinaria.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici;
            var cessionario =
                fatturaOrdinaria.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici;

            if (cedente.IdFiscaleIVA?.ToString() != cessionario.IdFiscaleIVA?.ToString())
                return true;
            if (cedente.CodiceFiscale != cessionario.CodiceFiscale)
                return true;

            var tipiDocumento = new[]
            {
                "TD01", "TD02", "TD03", "TD06", "TD16", "TD17", "TD18", "TD19", "TD20", "TD24", "TD25", "TD28"
            };

            return fatturaOrdinaria.FatturaElettronicaBody.All(x =>
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