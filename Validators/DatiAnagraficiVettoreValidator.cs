using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class DatiAnagraficiVettoreValidator : AbstractValidator<DatiAnagraficiVettore>
    {
        public DatiAnagraficiVettoreValidator()
        {
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAValidator());
            RuleFor(x => x.CodiceFiscale).Length(11, 16).When(x => !string.IsNullOrEmpty(x.CodiceFiscale));
            RuleFor(x => x.Anagrafica)
                .SetValidator(new AnagraficaValidator());
            RuleFor(x => x.NumeroLicenzaGuida)
                .Length(1,20)
                .BasicLatinValidator()
                .When(x => !string.IsNullOrEmpty(x.NumeroLicenzaGuida));
        }
    }
}
