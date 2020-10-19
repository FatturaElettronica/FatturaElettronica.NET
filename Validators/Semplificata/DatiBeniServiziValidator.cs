using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi;
using FatturaElettronica.Tabelle;
using FluentValidation;

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
                .NotEmpty<DatiBeniServizi, decimal>();
            RuleFor(x => x.DatiIVA)
                .SetValidator(new DatiIVAValidator());
            RuleFor(x => x.Natura)
                .Must(natura => !string.IsNullOrEmpty(natura))
                .When(x => x.DatiIVA.Aliquota == 0m && x.DatiIVA.Imposta == 0m)
                .WithMessage("L’indicazione di un’aliquota IVA pari a zero obbliga all’indicazione della natura dell’operazione che giustifichi la non imponibilità della stessa")
                .WithErrorCode("00400");
            RuleFor(x => x.Natura)
                .Must(natura => string.IsNullOrEmpty(natura))
                .When(x => x.DatiIVA.Aliquota > 0m || x.DatiIVA.Imposta > 0m)
                .WithMessage("Natura presente a fronte di Aliquota IVA o Imposta diversa da zero")
                .WithErrorCode("00401");
            RuleFor(x => x.Natura)
               .SetValidator(new IsValidValidator<NaturaSemplificata>())
               .When(x => x.Natura != null);
            RuleFor(x => x.RiferimentoNormativo)
               .Length(1, 100)
               .BasicLatinValidator()
               .When(x => !string.IsNullOrEmpty(x.RiferimentoNormativo));
        }
    }
}
