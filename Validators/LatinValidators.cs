﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace FatturaElettronica.Validators
{
    public abstract class LatinBaseValidator : PropertyValidator
    {
        private readonly Charsets _charset;

        protected LatinBaseValidator(Charsets charset)
        {
            _charset = charset;
        }

        protected override string GetDefaultMessageTemplate()
        {
            return
                $"Testo contenente caratteri non validi ({(_charset == Charsets.BasicLatin ? "Unicode Basic Latin" : "Unicode Latin-1 Supplement")}). valori non accettati: {{NonLatinCode}}";
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null || (string) context.PropertyValue == string.Empty) return true;

            var challenge = _charset switch
            {
                Charsets.BasicLatin => @"^[\p{IsBasicLatin}]+$",
                Charsets.Latin1Supplement => @"^[\p{IsBasicLatin}\p{IsLatin-1Supplement}]+$",
                _ => string.Empty
            };
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
                    var upperLimit = _charset switch
                    {
                        Charsets.BasicLatin => 0x7F,
                        Charsets.Latin1Supplement => 0xFF,
                        _ => throw new ArgumentOutOfRangeException()
                    };

                    if (letter > upperLimit)
                        invalidLetters.Add(letter);
                }
            }

            context.MessageFormatter.AppendArgument("NonLatinCode", new string(invalidLetters.ToArray()));
        }
    }

    public class BasicLatinValidator : LatinBaseValidator
    {
        public BasicLatinValidator() : base(Charsets.BasicLatin)
        {
        }
    }

    public class Latin1SupplementValidator : LatinBaseValidator
    {
        public Latin1SupplementValidator() : base(Charsets.Latin1Supplement)
        {
        }
    }

    public enum Charsets
    {
        BasicLatin,
        Latin1Supplement
    };

    public static class MyValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TElement> BasicLatinValidator<T, TElement>(
            this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new BasicLatinValidator());
        }

        public static IRuleBuilderOptions<T, TElement> Latin1SupplementValidator<T, TElement>(
            this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new Latin1SupplementValidator());
        }
    }
}