using FluentValidation;

namespace FatturaElettronica.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> IsValidFormatoTrasmissioneValue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsValidFormatoTrasmissioneValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> IsValidIdPaeseValue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsValidIdPaeseValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> IsValidProvinciaValue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsValidProvinciaValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> IsValidRegimeFiscaleValue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsValidRegimeFiscaleValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> IsValidSocioUnicoValue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsSocioUnicoValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> IsValidStatoLiquidazioneValue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsStatoLiquidazioneValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> IsValidSoggettoEmittenteValue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsSoggettoEmittenteValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> IsValidTipoDocumentoValue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsValidTipoDocumentoValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> IsValidDivisaValue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsValidDivisaValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> IsValidTipoRitenutaValue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsValidTipoRitenutaValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> IsValidCausalePagamentoValue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsValidCausalePagamentoValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> IsValidTipoCassaValue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsValidTipoCassaValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> IsValidNaturaValue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsValidNaturaValidator<TProperty>());
        }
        public static IRuleBuilderOptions<T, TProperty> IsValidScontoMaggiorazioneValue<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsValidScontoMaggiorazioneValidator<TProperty>());
        }
    }
}
