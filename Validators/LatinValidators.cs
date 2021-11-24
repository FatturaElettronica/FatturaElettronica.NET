using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace FatturaElettronica.Validators
{
    public abstract class LatinBaseValidator<T, TProperty> : PropertyValidator<T, TProperty>
    {
        private readonly Charsets _charset;

        protected LatinBaseValidator(Charsets charset)
        {
            _charset = charset;
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return
                $"Testo contenente caratteri non validi ({(_charset == Charsets.BasicLatin ? "Unicode Basic Latin" : "Unicode Latin-1 Supplement")}). valori non accettati: {{NonLatinCode}}";
        }

        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            if (value == null || value.ToString() == string.Empty) return true;

            var challenge = _charset switch
            {
                Charsets.BasicLatin => @"^[\p{IsBasicLatin}]+$",
                Charsets.Latin1Supplement => @"^[\p{IsBasicLatin}\p{IsLatin-1Supplement}]+$",
                _ => string.Empty
            };
            
            var invalidLetters = new HashSet<char>();
            foreach (var letter in value.ToString())
            {
                var upperLimit = _charset switch
                {
                    Charsets.BasicLatin => 0x7F,
                    Charsets.Latin1Supplement => 0xFF,
                    _ => throw new ArgumentOutOfRangeException()
                };

                if (letter > upperLimit)
                    invalidLetters.Add(letter);
            }

            context.MessageFormatter.AppendArgument("NonLatinCode", new string(invalidLetters.ToArray()));
            
            return Regex.Match(value.ToString(), challenge).Success;
        }

        public override string Name => "LatinBaseValidator";

    }

    public class BasicLatinValidator<T, TProperty> : LatinBaseValidator<T, TProperty>
    {
        public BasicLatinValidator() : base(Charsets.BasicLatin)
        {
        }
    }

    public class Latin1SupplementValidator<T, TProperty> : LatinBaseValidator<T, TProperty>
    {
        public Latin1SupplementValidator() : base(Charsets.Latin1Supplement)
        {
        }
    }

    public enum Charsets
    {
        BasicLatin,
        Latin1Supplement
    }

    public static class MyValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TElement> BasicLatinValidator<T, TElement>(
            this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new BasicLatinValidator<T, TElement>());
        }

        public static IRuleBuilderOptions<T, TElement> Latin1SupplementValidator<T, TElement>(
            this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new Latin1SupplementValidator<T, TElement>());
        }
    }
}