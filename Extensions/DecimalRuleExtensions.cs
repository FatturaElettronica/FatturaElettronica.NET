using FluentValidation;

namespace FatturaElettronica.Extensions
{
    internal static class DecimalRuleExtensions
    {
        public static void ScalePrecision8DecimalType<T>(this IRuleBuilder<T, decimal> ruleBuilder)
        {
            ruleBuilder.ScalePrecision(8, 19);
        }

        public static void ScalePrecision2DecimalType<T>(this IRuleBuilder<T, decimal> ruleBuilder)
        {
            ruleBuilder.ScalePrecision(2, 13);
        }

        public static void ScalePrecision8DecimalType<T>(this IRuleBuilder<T, decimal?> ruleBuilder)
        {
            ruleBuilder.ScalePrecision(8, 19);
        }

        public static void ScalePrecision2DecimalType<T>(this IRuleBuilder<T, decimal?> ruleBuilder)
        {
            ruleBuilder.ScalePrecision(2, 13);
        }

        public static void ScalePrecisionPercentualeDecimalType<T>(this IRuleBuilder<T, decimal?> ruleBuilder)
        {
            ruleBuilder.ScalePrecision(2, 6);
        }
    }
}