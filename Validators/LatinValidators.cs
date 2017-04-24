using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace FatturaElettronica.Validators
{
    public abstract class LatinBaseValidator<T> : PropertyValidator 
    {
        private Charsets _charset;


        public LatinBaseValidator(Charsets charset) 
            : base($"Testo contentente caratteri non validi ({(charset == Charsets.BasicLatin ? "Unicode Basic Latin" : "Unicode Latin-1 Supplement")})")
        {
            _charset = charset;
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null || (string)context.PropertyValue == string.Empty) return true;

            var challenge = string.Empty;
            switch (_charset)
            {
                case Charsets.BasicLatin:
                    challenge = @"^[\p{IsBasicLatin}]+$";
                    break;
                case Charsets.Latin1Supplement:
                    challenge = @"^[\p{IsBasicLatin}\p{IsLatin-1Supplement}]+$";
                    break;
            }
            return Regex.Match(context.PropertyValue.ToString(), challenge).Success;
        }
    }

    public class BasicLatinValidator<T> : LatinBaseValidator<T>
    {
        public BasicLatinValidator() : base(Charsets.BasicLatin) { }
    }
    public class Latin1SupplementValidator<T> : LatinBaseValidator<T>
    {
        public Latin1SupplementValidator() : base(Charsets.Latin1Supplement) { }
    }
    public enum Charsets { BasicLatin, Latin1Supplement };
    public static class MyValidatorExtensions
    {
       public static IRuleBuilderOptions<T, TElement> BasicLatinValidator<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder) {
          return ruleBuilder.SetValidator(new BasicLatinValidator<T>());
       }
       public static IRuleBuilderOptions<T, TElement> Latin1SupplementValidator<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder) {
          return ruleBuilder.SetValidator(new Latin1SupplementValidator<T>());
       }
    }
}
