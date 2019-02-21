namespace FatturaElettronica.Validators.Semplificata
{
    using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi;
    using FluentValidation;

    public class DatiBeniServiziValidator : AbstractValidator<DatiBeniServizi>
    {
        public DatiBeniServiziValidator()
        {
            RuleFor(x => x.Descrizione)
               .NotEmpty()
               .Length(1, 1000)
               .Latin1SupplementValidator();
            RuleFor(x => x.DatiIVA)
                .NotEmpty();
            RuleFor(x => x.Natura)
                .Must(natura => !string.IsNullOrEmpty(natura))
                .When(x => x.DatiIVA.Aliquota == 0)
                .WithMessage("Natura non presente a fronte di Aliquota IVA pari a 0")
                .WithErrorCode("00400");
            RuleFor(x => x.Natura)
                .Must(natura => string.IsNullOrEmpty(natura))
                .When(x => x.DatiIVA.Aliquota > 0)
                .WithMessage("Natura presente a fronte di Aliquota IVA diversa da zero")
                .WithErrorCode("00401");
            RuleFor(x => x.RiferimentoNormativo)
               .Length(1, 100)
               .BasicLatinValidator()
               .When(x => !string.IsNullOrEmpty(x.RiferimentoNormativo));
        }
    }
}
