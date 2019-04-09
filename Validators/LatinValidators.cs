using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace FatturaElettronica.Validators
{

    public abstract class LatinBaseValidator<T> : PropertyValidator
    {
        private readonly Charsets _charset;

        public LatinBaseValidator(Charsets charset)
            : base($"Testo contenente caratteri non validi ({(charset == Charsets.BasicLatin ? "Unicode Basic Latin" : "Unicode Latin-1 Supplement")}). valori non accettati: {{NonLatinCode}}")
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

        protected override void PrepareMessageFormatterForValidationError(PropertyValidatorContext context)
        {
            base.PrepareMessageFormatterForValidationError(context);

            var invalidLetters = new HashSet<char>();
            if (context.PropertyValue != null)
            {
                foreach (var letter in context.PropertyValue.ToString())
                {
                    int upperLimit;
                    switch (_charset)
                    {
                        case Charsets.BasicLatin:
                            upperLimit = 0x7F;
                            break;
                        case Charsets.Latin1Supplement:
                            upperLimit = 0xFF;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    if (letter > upperLimit)
                    {
                        invalidLetters.Add(letter);
                    }
                }
            }
            
            context.MessageFormatter.AppendArgument("NonLatinCode", new string(invalidLetters.ToArray()));
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
        public static IRuleBuilderOptions<T, TElement> BasicLatinValidator<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new BasicLatinValidator<T>());
        }
        public static IRuleBuilderOptions<T, TElement> Latin1SupplementValidator<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new Latin1SupplementValidator<T>());
        }
    }
}
