using BusinessObjects;
using FatturaElettronica.Tabelle;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public abstract class LocalitàBaseValidator<T> : AbstractValidator<T> where T : Common.Località
    {
        public LocalitàBaseValidator(bool optional=false)
        {
            if (optional)
            {
                When(x => !x.IsEmpty(), () =>
                {
                    SetRules();
                });
            }
            else
            {
                SetRules();
            }
        }
        private void SetRules()
        {
            RuleFor(x => x.Indirizzo).NotEmpty().Length(1, 60);
            RuleFor(x => x.NumeroCivico).Length(1, 8).When(x => !string.IsNullOrEmpty(x.NumeroCivico));
            RuleFor(x => x.CAP).NotEmpty().Length(5);
            RuleFor(x => x.Comune).NotEmpty().Length(1, 60);
            RuleFor(x => x.Provincia).SetValidator(new IsValidValidator<Provincia>()).When(x => !string.IsNullOrEmpty(x.Provincia));
            RuleFor(id => id.Nazione).NotEmpty().SetValidator(new IsValidValidator<IdPaese>());
        }
    }
}
