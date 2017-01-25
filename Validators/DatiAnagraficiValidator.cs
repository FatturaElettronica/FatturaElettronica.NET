using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class DatiAnagraficiValidator : AbstractValidator<FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici>
    {
        public DatiAnagraficiValidator()
        {
            RuleFor(x => x.IdFiscaleIVA).SetValidator(new IdFiscaleIVAValidator());
            RuleFor(x => x.CodiceFiscale).Length(11, 16);
            RuleFor(x => x.Anagrafica).SetValidator(new AnagraficaValidator());
            RuleFor(x => x.AlboProfessionale).Length(1, 60);
            RuleFor(x => x.ProvinciaAlbo).ProvinciaDomain().Unless(x => string.IsNullOrEmpty(x.ProvinciaAlbo));
            RuleFor(x => x.NumeroIscrizioneAlbo).Length(1, 60);
            RuleFor(x => x.RegimeFiscale).NotEmpty().RegimeFiscaleDomain();
        }
    }
}
