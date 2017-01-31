using FatturaElettronica.FatturaElettronicaHeader.TerzoIntermediarioOSoggettoEmittente;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class TerzoIntermediarioOSoggettoEmittenteValidator : AbstractValidator<TerzoIntermediarioOSoggettoEmittente>
    {
        public TerzoIntermediarioOSoggettoEmittenteValidator()
        {
            When(x => !x.IsEmpty(), () =>
            {
                RuleFor(x => x.DatiAnagrafici).SetValidator(new DatiAnagraficiValidator());
            });
        }
    }
}
