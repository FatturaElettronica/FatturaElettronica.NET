using FluentValidation;

namespace FatturaElettronica.Extensions
{
    internal static class DecimalRuleExtensions
    {
        public static void ScalePrecision8DecimalType<T>(this IRuleBuilder<T, decimal> ruleBuilder)
        {
            ruleBuilder.PrecisionScale(19, 8, false);
        }

        public static void ScalePrecision2DecimalType<T>(this IRuleBuilder<T, decimal> ruleBuilder)
        {
            ruleBuilder.PrecisionScale(13, 2, false);
        }

        public static void ScalePrecision8DecimalType<T>(this IRuleBuilder<T, decimal?> ruleBuilder)
        {
            ruleBuilder.PrecisionScale(19, 8, false);
        }

        public static void ScalePrecision2DecimalType<T>(this IRuleBuilder<T, decimal?> ruleBuilder)
        {
            ruleBuilder.PrecisionScale(13, 2, false);
        }

        public static void ScalePrecisionPercentualeDecimalType<T>(this IRuleBuilder<T, decimal?> ruleBuilder)
        {
            ruleBuilder.PrecisionScale(6, 2, false);
        }
    }
}