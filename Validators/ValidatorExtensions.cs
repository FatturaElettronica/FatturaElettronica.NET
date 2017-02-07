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
        public static IRuleBuilderOptions<T, TProperty> ProvinciaDomain<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new ProvinciaDomainValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> RegimeFiscaleDomain<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new RegimeFiscaleDomainValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> SocioUnicoDomain<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new SocioUnicoDomainValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> StatoLiquidazioneDomain<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new StatoLiquidazioneDomainValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> SoggettoEmittenteDomain<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new SoggettoEmittenteDomainValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> TipoDocumentoDomain<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new TipoDocumentoDomainValidator<TProperty>());
        }
    }
}
