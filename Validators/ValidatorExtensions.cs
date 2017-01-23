using FluentValidation;

namespace FatturaElettronica.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> FormatoTrasmissioneDomain<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new FormatoTrasmissioneDomainValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> IdPaeseDomain<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IdPaeseDomainValidator<TProperty>());
        }
    }
}
