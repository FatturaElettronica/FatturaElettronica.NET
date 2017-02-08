using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Validators
{
    public class DatiGeneraliDocumentoValidator : AbstractValidator<DatiGeneraliDocumento>
    {
        public DatiGeneraliDocumentoValidator()
        {
            RuleFor(x => x.TipoDocumento).NotEmpty().TipoDocumentoDomain();
            RuleFor(x => x.Divisa).NotEmpty().DivisaDomain();
            RuleFor(x => x.Numero).NotEmpty().Length(1, 20);
            RuleFor(x => x.Numero).Matches(@"\d").WithMessage("Almeno un carattere numerico è necessario");
            RuleFor(x => x.DatiRitenuta).SetValidator(new DatiRitenutaValidator());
            RuleFor(x => x.DatiBollo).SetValidator(new DatiBolloValidator());
            RuleFor(x => x.DatiCassaPrevidenziale).SetCollectionValidator(new DatiCassaPrevidenzialeValidator());
            RuleFor(x => x.DatiCassaPrevidenziale)
                .Must((dgd, daticassa) => { return (daticassa.Count > 0) ? !dgd.DatiRitenuta.IsEmpty() : true; })
                .WithMessage("415 DatiRitenuta non presente a fronte di DatiCassaPreviendiale.Ritenuta valorizzato");
            RuleFor(x => x.ScontoMaggiorazione).SetCollectionValidator(new ScontoMaggiorazioneValidator());
            RuleFor(x => x.Causale).SetCollectionValidator(new StringLengthValidator(1, 200));
            RuleFor(x => x.Art73).Equal("SI").Unless(x => string.IsNullOrEmpty(x.Art73));
        }
    }
}
