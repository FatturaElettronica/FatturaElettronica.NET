using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class FatturaElettronicaBodyValidator : AbstractValidator<FatturaElettronicaBody.FatturaElettronicaBody>
    {
        public FatturaElettronicaBodyValidator()
        {
            RuleFor(x => x.DatiGenerali).SetValidator(new DatiGeneraliValidator());
            RuleFor(x => x.DatiBeniServizi).SetValidator(new DatiBeniServiziValidator());
            RuleFor(x => x.DatiBeniServizi).Must(x => !x.IsEmpty()).WithMessage("DatiBeniServizi è obbligatorio");
            RuleFor(x => x.DatiGenerali.DatiGeneraliDocumento.DatiRitenuta)
                .Must((body, datiRitenuta) => ValidateDatiRitenutaAgainstDettaglioLinee(datiRitenuta, body))
                .When(x => x.DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.IsEmpty())
                .WithMessage("00411: DatiRitenuta non presente a fronte di almeno un blocco DettaglioLinee con Ritenuta ugualie a SI");
        }

        private bool ValidateDatiRitenutaAgainstDettaglioLinee(DatiRitenuta datiRitenuta, FatturaElettronicaBody.FatturaElettronicaBody body)
        {
            foreach (var linea in body.DatiBeniServizi.DettaglioLinee)
            {
                if (linea.Ritenuta == "SI") return false;
            }
            return true;
        }
    }
}
