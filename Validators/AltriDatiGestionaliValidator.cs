using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi;

namespace FatturaElettronica.Validators
{
    public class AltriDatiGestionaliValidator : AbstractValidator<AltriDatiGestionali>
    {
        public AltriDatiGestionaliValidator()
        {
            RuleFor(x => x.TipoDato)
                .NotEmpty()
                .Length(1, 10);
            RuleFor(x => x.RiferimentoTesto)
                .Length(1, 60)
                .When(x => !string.IsNullOrEmpty(x.RiferimentoTesto));
        }
    }
}
