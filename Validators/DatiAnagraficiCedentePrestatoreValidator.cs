using FatturaElettronica.Tabelle;
using FluentValidation;
using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;

namespace FatturaElettronica.Validators
{
    public class DatiAnagraficiCedentePrestatoreValidator : 
        AbstractValidator<DatiAnagraficiCedentePrestatore>
    {
        public DatiAnagraficiCedentePrestatoreValidator()
        {
            RuleFor(x => x.IdFiscaleIVA).SetValidator(new IdFiscaleIVAValidator());
            RuleFor(x => x.CodiceFiscale).Length(11, 16).When(x => !string.IsNullOrEmpty(x.CodiceFiscale));
            RuleFor(x => x.Anagrafica).SetValidator(new AnagraficaValidator());
            RuleFor(x => x.AlboProfessionale).Length(1, 60).When(x=>!string.IsNullOrEmpty(x.AlboProfessionale));
            RuleFor(x => x.ProvinciaAlbo).SetValidator(new IsValidValidator<Provincia>()).When(x => !string.IsNullOrEmpty(x.ProvinciaAlbo));
            RuleFor(x => x.NumeroIscrizioneAlbo).Length(1, 60).When(x=>!string.IsNullOrEmpty(x.NumeroIscrizioneAlbo));
            RuleFor(x => x.RegimeFiscale).NotEmpty().SetValidator(new IsValidValidator<RegimeFiscale>());
        }
    }
}
