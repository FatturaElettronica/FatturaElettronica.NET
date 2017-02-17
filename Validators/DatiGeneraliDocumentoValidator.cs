using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Tabelle;

namespace FatturaElettronica.Validators
{
    public class DatiGeneraliDocumentoValidator : AbstractValidator<DatiGeneraliDocumento>
    {
        public DatiGeneraliDocumentoValidator()
        {
            RuleFor(x => x.TipoDocumento).NotEmpty().SetValidator(new IsValidValidator<TipoDocumento>());
            RuleFor(x => x.Divisa).NotEmpty().SetValidator(new IsValidValidator<Divisa>());
            RuleFor(x => x.Numero).NotEmpty().Length(1, 20);
            RuleFor(x => x.Numero)
                .Matches(@"\d")
                .WithMessage("Numero non contiene caratteri numerici")
                .WithErrorCode("00411");

            RuleFor(x => x.DatiRitenuta)
                .SetValidator(new DatiRitenutaValidator())
                .When(x=>!x.DatiRitenuta.IsEmpty());

            RuleFor(x => x.DatiBollo)
                .SetValidator(new DatiBolloValidator())
                .When(x=>!x.DatiBollo.IsEmpty());

            RuleFor(x => x.DatiCassaPrevidenziale).SetCollectionValidator(new DatiCassaPrevidenzialeValidator());
            RuleFor(x => x.DatiCassaPrevidenziale)
                .Must((datiGeneraliDocumento, datiCassa) => { return (datiCassa.Count > 0) ? !datiGeneraliDocumento.DatiRitenuta.IsEmpty() : true; })
                .WithMessage("DatiRitenuta non presente a fronte di DatiCassaPreviendiale.Ritenuta valorizzato")
                .WithErrorCode("00415");
            RuleFor(x => x.ScontoMaggiorazione).SetCollectionValidator(new ScontoMaggiorazioneValidator());
            RuleFor(x => x.Causale).SetCollectionValidator(new StringLengthValidator(1, 200));
            RuleFor(x => x.Art73).Equal("SI").Unless(x => string.IsNullOrEmpty(x.Art73));
        }
    }
}
