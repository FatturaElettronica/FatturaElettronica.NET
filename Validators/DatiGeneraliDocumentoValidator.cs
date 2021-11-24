using FluentValidation;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Tabelle;
using System.Linq;

namespace FatturaElettronica.Validators
{
    public class DatiGeneraliDocumentoValidator : AbstractValidator<DatiGeneraliDocumento>
    {
        public DatiGeneraliDocumentoValidator()
        {
            RuleFor(x => x.TipoDocumento)
                .NotEmpty()
                .SetValidator(new IsValidValidator<DatiGeneraliDocumento, string, TipoDocumento>());
            RuleFor(x => x.Divisa)
                .NotEmpty()
                .SetValidator(new IsValidValidator<DatiGeneraliDocumento, string, Divisa>());
            RuleFor(x => x.Numero)
                .NotEmpty()
                .BasicLatinValidator()
                .Length(1, 20);
            RuleFor(x => x.Numero)
                .Matches(@"\d")
                .WithMessage("Numero non contiene caratteri numerici")
                .WithErrorCode("00425");
            RuleForEach(x => x.DatiRitenuta)
                .SetValidator(new DatiRitenutaValidator());
            RuleFor(x => x.DatiBollo)
                .SetValidator(new DatiBolloValidator())
                .When(x => x.DatiBollo != null && !x.DatiBollo.IsEmpty());
            RuleForEach(x => x.DatiCassaPrevidenziale)
                .SetValidator(new DatiCassaPrevidenzialeValidator());
            RuleFor(x => x.DatiCassaPrevidenziale)
                .Must((datiGeneraliDocumento, datiCassa) =>
                {
                    return (datiCassa.Count(a => a.Ritenuta == "SI") <= 0) ||
                           datiGeneraliDocumento.DatiRitenuta.Count > 0;
                })
                .WithMessage("DatiRitenuta non presente a fronte di DatiCassaPrevidenziale.Ritenuta valorizzato")
                .WithErrorCode("00415");
            RuleForEach(x => x.ScontoMaggiorazione)
                .SetValidator(new ScontoMaggiorazioneValidator());
            RuleForEach(x => x.Causale)
                .SetValidator(new CausaleValidator(1, 200));
            RuleFor(x => x.Art73)
                .Equal("SI")
                .When(x => !string.IsNullOrEmpty(x.Art73));
            RuleFor(x => x.ImportoTotaleDocumento)
                .ScalePrecision(2, 13);
            RuleFor(x => x.Arrotondamento)
                .ScalePrecision(2, 13);
        }
    }
}