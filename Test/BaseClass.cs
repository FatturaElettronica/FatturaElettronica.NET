using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using FatturaElettronica.Core;
using FatturaElettronica.Extensions;
using FatturaElettronica.Tabelle;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test
{
    [TestClass]
    public abstract class BaseClass<TClass, TValidator>
        where TClass : BaseClassSerializable
        where TValidator : IValidator<TClass>
    {
        protected TValidator Validator;
        protected TClass Challenge;

        [TestInitialize]
        public void Init()
        {
            Validator = Activator.CreateInstance<TValidator>();
            Challenge = Activator.CreateInstance<TClass>();
        }

        [TestMethod]
        public void ValidateExtensionMethodIsAvailable()
        {
            var r1 = Challenge.Validate();
            Assert.IsInstanceOfType(r1, typeof(ValidationResult));

            var r2 = Validator.Validate(Challenge);

            // ValidationResult equality operatore has not been implemented.
            for (var i = 0; i <= r1.Errors.Count - 1; i++)
            {
                Assert.AreEqual(r1.Errors[i].PropertyName, r2.Errors[i].PropertyName);
                Assert.AreEqual(r1.Errors[i].ErrorMessage, r2.Errors[i].ErrorMessage);
            }
        }

        protected void AssertOptional<T>(Expression<Func<TClass, T>> outExpr, bool emptyStringAllowed = true)
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(Challenge, null);
            var result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);

            if (!emptyStringAllowed || typeof(T) != typeof(string)) return;
            prop.SetValue(Challenge, string.Empty);
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);
        }

        protected void AssertRequired<T>(Expression<Func<TClass, T>> outExpr, string expectedErrorCode = null)
        {
            var prop = GetProperty(outExpr);

            if (expectedErrorCode == null)
            {
                if (typeof(T) == typeof(DateTime?) || typeof(T) == typeof(decimal?))
                    expectedErrorCode = "NotNullValidator";
                else
                    expectedErrorCode = "NotEmptyValidator";
            }

            prop.SetValue(Challenge, null);
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr).WithErrorCode(expectedErrorCode);

            if (typeof(T) == typeof(string))
            {
                prop.SetValue(Challenge, string.Empty);
                result = Validator.TestValidate(Challenge);
                result.ShouldHaveValidationErrorFor(outExpr).WithErrorCode(expectedErrorCode);
            }

            if (typeof(T) != typeof(decimal)) return;
            prop.SetValue(Challenge, 0m);
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr).WithErrorCode(expectedErrorCode);
        }

        protected void AssertMinMaxLength(Expression<Func<TClass, string>> outExpr, int min, int max, char filler = 'x',
            string expectedErrorCode = "LengthValidator")
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(Challenge, new string(filler, max + 1));
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr).WithErrorCode(expectedErrorCode);

            prop.SetValue(Challenge, new string(filler, min));
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);

            prop.SetValue(Challenge, new string(filler, max));
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);
        }

        protected void AssertDigitsOrUppercase(Expression<Func<TClass, string>> outExpr, int length = 16)
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(Challenge, new string('x', 16));
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr).WithErrorCode("RegularExpressionValidator");

            prop.SetValue(Challenge, new string('X', 16));
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);
        }

        protected void AssertLength(Expression<Func<TClass, string>> outExpr, int length, char filler = 'x',
            string expectedErrorCode = "ExactLengthValidator")
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(Challenge, new string(filler, length + 1));
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr).WithErrorCode(expectedErrorCode);

            prop.SetValue(Challenge, new string(filler, length - 1));
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr).WithErrorCode(expectedErrorCode);

            prop.SetValue(Challenge, new string(filler, length));
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);
        }

        protected void AssertOnlyAcceptsTableValues<T>(Expression<Func<TClass, string>> outExpr,
            string expectedErrorCode = "IsValidValidator") where T : Tabella, new()
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(Challenge, "hello");
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr).WithErrorCode(expectedErrorCode);

            foreach (var codice in new T().Codici)
            {
                prop.SetValue(Challenge, codice);
                result = Validator.TestValidate(Challenge);
                result.ShouldNotHaveValidationErrorFor(outExpr);
            }
        }

        protected void AssertCollectionCanBeEmpty<T>(Expression<Func<TClass, List<T>>> outExpr)
        {
            var prop = GetProperty(outExpr);

            var r = Validator.Validate(Challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == prop.Name));
        }

        protected void AssertCollectionCannotBeEmpty<T>(Expression<Func<TClass, List<T>>> outExpr)
        {
            var prop = GetProperty(outExpr);

            var r = Validator.Validate(Challenge);
            Assert.AreEqual("NotEmptyValidator", r.Errors.FirstOrDefault(x => x.PropertyName == prop.Name)?.ErrorCode);
        }

        protected void AssertOnlyAcceptsSIValue(Expression<Func<TClass, string>> outExpr)
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(Challenge, "NO");
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr);

            prop.SetValue(Challenge, "SI");
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);
        }

        protected void AssertMustBeBasicLatin(Expression<Func<TClass, string>> outExpr)
        {
            var prop = GetProperty(outExpr);

            // Important: test string not longer than 10. Must include a number.
            prop.SetValue(Challenge, "test ~tes1");
            var result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);

            prop.SetValue(Challenge, "test Àtes1");
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr);
        }

        protected void AssertMustBeLatin1Supplement(Expression<Func<TClass, string>> outExpr)
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(Challenge, "test ~tes1");
            var result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);

            prop.SetValue(Challenge, "test Àtes1");
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);

            prop.SetValue(Challenge, "test ›tes1");
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr);
        }

        protected void AssertProvinciaOnlyAcceptsValidValues(Expression<Func<TClass, string>> outExpr)
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(Challenge, "mi");
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr);

            prop.SetValue(Challenge, "M");
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr);

            prop.SetValue(Challenge, "MIL");
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr);

            prop.SetValue(Challenge, "MI");
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);
        }

        private static PropertyInfo GetProperty<T>(Expression<Func<TClass, T>> outExpr)
        {
            var expr = (MemberExpression)outExpr.Body;
            return (PropertyInfo)expr.Member;
        }

        protected void AssertDecimalType(Expression<Func<TClass, decimal?>> outExpr, int scale, int precision)
        {
            var maxValue = (decimal)Math.Pow(10, precision - scale) - 1;
            var prop = GetProperty(outExpr);
            prop.SetValue(Challenge, maxValue + 1);
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr);

            prop.SetValue(Challenge, maxValue);
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);

            var decimalValueValid = (decimal)Math.Pow(10, -scale);
            prop.SetValue(Challenge, decimalValueValid);
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);

            var decimalValueInvalid = (decimal)Math.Pow(10, -scale - 1);
            prop.SetValue(Challenge, decimalValueInvalid);
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr);
        }

        protected void AssertDecimalType(Expression<Func<TClass, decimal>> outExpr, int scale, int precision)
        {
            var maxValue = (decimal)Math.Pow(10, precision - scale) - 1;
            var prop = GetProperty(outExpr);
            prop.SetValue(Challenge, maxValue + 1);
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr);

            prop.SetValue(Challenge, maxValue);
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);

            var decimalValueValid = (decimal)Math.Pow(10, -scale);
            prop.SetValue(Challenge, decimalValueValid);
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(outExpr);

            var decimalValueInvalid = (decimal)Math.Pow(10, -scale - 1);
            prop.SetValue(Challenge, decimalValueInvalid);
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(outExpr);
        }
    }
}