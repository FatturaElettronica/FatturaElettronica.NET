using FluentValidation;

namespace FatturaElettronica.Validators
{
    public abstract class LocalitàBaseValidator<T> : AbstractValidator<T> where T : Common.Località
    {
        public LocalitàBaseValidator()
        {
            RuleFor(x => x.Indirizzo).NotEmpty().Length(1, 60);
            RuleFor(x => x.NumeroCivico).Length(1, 8);
            RuleFor(x => x.CAP).NotEmpty().Length(5);
            RuleFor(x => x.Comune).NotEmpty().Length(1, 60);
            RuleFor(x => x.Provincia).IsValidProvinciaValue().Unless(x => string.IsNullOrEmpty(x.Provincia));
            RuleFor(id => id.Nazione).NotEmpty().IsValidIdPaeseValue();
        }
    }
}
