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
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAValidator());
            RuleFor(x => x.CodiceFiscale)
                .Length(11, 16)
                .When(x => !string.IsNullOrEmpty(x.CodiceFiscale));
            RuleFor(x => x.Anagrafica)
                .SetValidator(new AnagraficaValidator());
            RuleFor(x => x.AlboProfessionale)
                .Length(1, 60)
                .Latin1SupplementValidator()
                .When(x => !string.IsNullOrEmpty(x.AlboProfessionale));
            RuleFor(x => x.ProvinciaAlbo)
                .Matches(@"^[A-Z]{2}$")
                .When(x => !string.IsNullOrEmpty(x.ProvinciaAlbo));
            RuleFor(x => x.NumeroIscrizioneAlbo)
                .Length(1, 60)
                .BasicLatinValidator()
                .When(x => !string.IsNullOrEmpty(x.NumeroIscrizioneAlbo));
            RuleFor(x => x.RegimeFiscale)
                .NotEmpty()
                .SetValidator(new RegimeFiscaleValidator<RegimeFiscale>());

        }
    }
}
