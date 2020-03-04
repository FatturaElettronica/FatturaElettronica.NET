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
                .Must((fattura, _) => FatturaValidateAgainstError00471(fattura))
                .WithMessage(
                    "I valori TD16, TD17, TD18, TD19 e TD20 del tipo documento non ammettono l’indicazione in fattura dello stesso soggetto sia come cedente che come cessionario")
                .WithErrorCode("00471");
            RuleFor(x => x)
                .Must((fattura, _) => FatturaValidateAgainstError00472(fattura))
                .WithMessage(
                    "Il tipo documento ‘autofattura per splafonamento’ non ammette l’indicazione in fattura di un cedente diverso dal cessionario")
                .WithErrorCode("00472");
            RuleFor(x => x)
                .Must((fattura, _) => FatturaValidateAgainstError00473(fattura))
                .WithMessage(
                    "I valori TD17, TD18 e TD19 del tipo documento non ammettono l’indicazione in fattura di un cedente italiano")
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
        }

        private bool FatturaValidateAgainstError00473(FatturaOrdinaria fatturaOrdinaria)
        {
            
            var cedente = fatturaOrdinaria.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici;

            if (cedente.IdFiscaleIVA.IdPaese != "IT")
                return true;
            
            var tipiDocumento = new string[] {"TD17", "TD18", "TD19"};
            
            return fatturaOrdinaria.FatturaElettronicaBody.All(x =>
                !tipiDocumento.Contains(x.DatiGenerali.DatiGeneraliDocumento.TipoDocumento));
        }
        private bool FatturaValidateAgainstError00472(FatturaOrdinaria fatturaOrdinaria)
        {
            var bodies =
                fatturaOrdinaria.FatturaElettronicaBody.Where(x =>
                    x.DatiGenerali.DatiGeneraliDocumento.TipoDocumento == "TD21");

            if (!bodies.Any())
                return true;

            var cedente = fatturaOrdinaria.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici;
            var cessionario =
                fatturaOrdinaria.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici;

            return cedente.IdFiscaleIVA.ToString() == cessionario.IdFiscaleIVA.ToString() &&
                   cedente.CodiceFiscale == cessionario.CodiceFiscale;
        }

        private bool FatturaValidateAgainstError00471(FatturaOrdinaria fatturaOrdinaria)
        {
            var cedente = fatturaOrdinaria.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici;
            var cessionario =
                fatturaOrdinaria.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici;

            if (cedente.IdFiscaleIVA.ToString() != cessionario.IdFiscaleIVA.ToString())
                return true;
            if (cedente.CodiceFiscale != cessionario.CodiceFiscale)
                return true;

            var tipiDocumento = new string[] {"TD16", "TD17", "TD18", "TD19", "TD20"};

            return fatturaOrdinaria.FatturaElettronicaBody.All(x =>
                !tipiDocumento.Contains(x.DatiGenerali.DatiGeneraliDocumento.TipoDocumento));
        }

        private bool BodyValidateAgainstError00444(FatturaElettronicaBody body)
        {
            var cassaPrevidenziale = body.DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale;
            var dettaglioLinee = body.DatiBeniServizi.DettaglioLinee;

            var nature = dettaglioLinee.Select(x => x.Natura)
                .Concat(cassaPrevidenziale.Select(x => x.Natura))
                .ToArray();

            var riepilogo = body.DatiBeniServizi.DatiRiepilogo.Select(x => x.Natura);

            return nature.All(natura => riepilogo.Contains(natura));
        }

        private bool BodyValidateAgainstError00443(FatturaElettronicaBody body)
        {
            var cassaPrevidenziale = body.DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale;
            var dettaglioLinee = body.DatiBeniServizi.DettaglioLinee;

            var aliquote = dettaglioLinee.Select(x => x.AliquotaIVA)
                .Concat(cassaPrevidenziale.Select(x => x.AliquotaIVA))
                .ToArray();

            var riepilogo = body.DatiBeniServizi.DatiRiepilogo.Select(x => x.AliquotaIVA);

            return aliquote.All(aliquota => riepilogo.Contains(aliquota));
        }
    }
}