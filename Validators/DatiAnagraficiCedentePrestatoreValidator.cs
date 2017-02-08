using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class DatiAnagraficiCedentePrestatoreValidator : DatiAnagraficiBaseValidator<FatturaElettronicaHeader.CedentePrestatore.DatiAnagraficiCedentePrestatore>
    {
        public DatiAnagraficiCedentePrestatoreValidator()
        {
            RuleFor(x => x.AlboProfessionale).Length(1, 60);
            RuleFor(x => x.ProvinciaAlbo).IsValidProvinciaValue().Unless(x => string.IsNullOrEmpty(x.ProvinciaAlbo));
            RuleFor(x => x.NumeroIscrizioneAlbo).Length(1, 60);
            RuleFor(x => x.RegimeFiscale).NotEmpty().IsValidRegimeFiscaleValue();
        }
    }
}
