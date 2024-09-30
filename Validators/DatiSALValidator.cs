using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Resources;
using FluentValidation;

namespace FatturaElettronica.Validators;

public class DatiSALValidator : AbstractValidator<DatiSAL>
{
    public DatiSALValidator()
    {
        RuleFor(x => x.RiferimentoFase)
            .InclusiveBetween(1, 999)
            .WithMessage(string.Format(ValidatorMessages.ValidNumberRange_X_Y, 1, 999));
    }
}
