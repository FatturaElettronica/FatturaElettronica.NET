using FatturaElettronica.Resources;
using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi;
using FluentValidation;
using NaturaSemplificata = FatturaElettronica.Tabelle.NaturaSemplificata;

namespace FatturaElettronica.Validators.Semplificata
{
    public class DatiBeniServiziValidator : AbstractValidator<DatiBeniServizi>
    {
        public DatiBeniServiziValidator()
        {
            RuleFor(x => x.Descrizione)
                .NotEmpty()
                .Length(1, 1000)
                .Latin1SupplementValidator();
            RuleFor(x => x.Importo)
                .NotEmpty();
            RuleFor(x => x.DatiIVA)
                .SetValidator(new DatiIVAValidator());
            RuleFor(x => x.Natura)
                .Must(natura => !string.IsNullOrEmpty(natura))
                .When(x => x.DatiIVA.Aliquota == 0m && x.DatiIVA.Imposta == 0m)
                .WithMessage(ValidatorMessages.E00400_S)
                .WithErrorCode("00400");
            RuleFor(x => x.Natura)
                .Must(string.IsNullOrEmpty)
                .When(x => x.DatiIVA.Aliquota > 0m || x.DatiIVA.Imposta > 0m)
                .WithMessage(ValidatorMessages.E00401_S)
                .WithErrorCode("00401");
            RuleFor(x => x.Natura)
                .SetValidator(new IsValidValidator<DatiBeniServizi, string, NaturaSemplificata>())
                .When(x => x.Natura != null);
            RuleFor(x => x.RiferimentoNormativo)
                .Length(1, 100)
                .BasicLatinValidator()
                .When(x => !string.IsNullOrEmpty(x.RiferimentoNormativo));
        }
    }
}
