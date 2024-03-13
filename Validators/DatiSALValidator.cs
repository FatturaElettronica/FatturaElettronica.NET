using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FluentValidation;

namespace FatturaElettronica.Validators;

public class DatiSALValidator : AbstractValidator<DatiSAL>
{
    public DatiSALValidator()
    {
        RuleFor(x => x.RiferimentoFase)
            .InclusiveBetween(1, 999)
            .WithMessage("Valori consentiti 1-999");
    }
}