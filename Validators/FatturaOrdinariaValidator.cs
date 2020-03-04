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
            RuleForEach(x => x.FatturaElettronicaBody)
                .SetValidator(new FatturaElettronicaBodyValidator());
            RuleForEach(x => x.FatturaElettronicaBody)
                .Must((_, body) => BodyValidateAgainstError00443(body))
                .WithMessage(
                    "Non c’è corrispondenza tra i valori indicati nell’elemento 2.2.1.12 <AliquotaIVA> o 2.1.1.7.5 <AliquotaIVA> e quelli" +
                    "dell’elemento 2.2.2.1 <AliquotaIVA> (tutti i valori delle aliquote IVA presenti nelle linee di dettaglio di una fattura" +
                    "o nei dati di cassa previdenziale devono essere presenti anche nei dati di riepilogo)")
                .WithErrorCode("00443");
            RuleForEach(x => x.FatturaElettronicaBody)
                .Must((_, body) => BodyValidateAgainstError00444(body))
                .WithMessage(
                    "non c’è corrispondenza tra i valori indicati nell’elemento 2.2.1.14 <Natura> o 2.1.1.7.7 <Natura> e quelli" +
                    " dell’elemento 2.2.2.2 <Natura> (tutti i valori di natura dell’operazione presenti nelle linee di dettaglio" +
                    " di una fattura o nei dati di cassa previdenziale devono essere presenti anche nei dati di riepilogo)")
                .WithErrorCode("00444");
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