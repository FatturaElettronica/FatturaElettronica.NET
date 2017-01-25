using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class CedentePrestatoreValidator : AbstractValidator<CedentePrestatore>
    {
        public CedentePrestatoreValidator()
        {
            RuleFor(x => x.DatiAnagrafici).SetValidator(new DatiAnagraficiValidator());
            RuleFor(x => x.Sede).SetValidator(new SedeValidator());
            RuleFor(x => x.StabileOrganizzazione).SetValidator(new StabileOrganizzazioneValidator());
            RuleFor(x => x.IscrizioneREA).SetValidator(new IscrizioneREAValidator());
            RuleFor(x => x.Contatti).SetValidator(new ContattiValidator());
        }
    }
}
