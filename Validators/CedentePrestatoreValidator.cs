using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class CedentePrestatoreValidator : AbstractValidator<CedentePrestatore>
    {
        public CedentePrestatoreValidator()
        {
            RuleFor(x => x.DatiAnagrafici)
                .SetValidator(new DatiAnagraficiCedentePrestatoreValidator());
            RuleFor(x => x.Sede)
                .SetValidator(new SedeCedentePrestatoreValidator());
            RuleFor(x => x.StabileOrganizzazione)
                .SetValidator(new StabileOrganizzazioneValidator())
                .When(x=>!x.StabileOrganizzazione.IsEmpty());
            RuleFor(x => x.IscrizioneREA)
                .SetValidator(new IscrizioneREAValidator())
                .When(x=>!x.IscrizioneREA.IsEmpty());
            RuleFor(x => x.Contatti)
                .SetValidator(new ContattiValidator())
                .When(x=>!x.Contatti.IsEmpty());
            RuleFor(x => x.RiferimentoAmministrazione)
                .BasicLatinValidator()
                .Length(1, 20);
        }
    }
}
