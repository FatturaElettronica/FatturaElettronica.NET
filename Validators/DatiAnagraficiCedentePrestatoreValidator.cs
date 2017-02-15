using FatturaElettronica.Tabelle;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class DatiAnagraficiCedentePrestatoreValidator : DatiAnagraficiBaseValidator<FatturaElettronicaHeader.CedentePrestatore.DatiAnagraficiCedentePrestatore>
    {
        public DatiAnagraficiCedentePrestatoreValidator()
        {
            RuleFor(x => x.AlboProfessionale).Length(1, 60).When(x=>!string.IsNullOrEmpty(x.AlboProfessionale));
            RuleFor(x => x.ProvinciaAlbo).SetValidator(new IsValidValidator<Provincia>()).When(x => !string.IsNullOrEmpty(x.ProvinciaAlbo));
            RuleFor(x => x.NumeroIscrizioneAlbo).Length(1, 60).When(x=>!string.IsNullOrEmpty(x.NumeroIscrizioneAlbo));
            RuleFor(x => x.RegimeFiscale).NotEmpty().SetValidator(new IsValidValidator<RegimeFiscale>());
        }
    }
}
