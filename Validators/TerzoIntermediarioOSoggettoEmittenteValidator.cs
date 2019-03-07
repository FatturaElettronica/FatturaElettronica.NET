using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.TerzoIntermediarioOSoggettoEmittente;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class TerzoIntermediarioOSoggettoEmittenteValidator : AbstractValidator<TerzoIntermediarioOSoggettoEmittente>
    {
        public TerzoIntermediarioOSoggettoEmittenteValidator()
        {
            RuleFor(x => x.DatiAnagrafici)
                .SetValidator(new DatiAnagraficiTerzoIntermediarioValidator());
        }
    }
}
