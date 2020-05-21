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
            Validator.ShouldNotHaveValidationErrorFor(outExpr, Challenge);

            if (emptyStringAllowed && typeof(T) == typeof(string))
            {
                prop.SetValue(Challenge, string.Empty);
                Validator.ShouldNotHaveValidationErrorFor(outExpr, Challenge);
            }
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
            Validator.ShouldHaveValidationErrorFor(outExpr, Challenge).WithErrorCode(expectedErrorCode);

            if (typeof(T) == typeof(string))
            {
                prop.SetValue(Challenge, string.Empty);
                Validator.ShouldHaveValidationErrorFor(outExpr, Challenge).WithErrorCode(expectedErrorCode);
            }

            if (typeof(T) == typeof(decimal))
            {
                prop.SetValue(Challenge, 0m);
                Validator.ShouldHaveValidationErrorFor(outExpr, Challenge).WithErrorCode(expectedErrorCode);
            }
        }

        protected void AssertMinMaxLength(Expression<Func<TClass, string>> outExpr, int min, int max, char filler = 'x',
            string expectedErrorCode = "LengthValidator")
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(Challenge, new string(filler, max + 1));
            Validator.ShouldHaveValidationErrorFor(outExpr, Challenge).WithErrorCode(expectedErrorCode);
            prop.SetValue(Challenge, new string(filler, min));
            Validator.ShouldNotHaveValidationErrorFor(outExpr, Challenge);
            prop.SetValue(Challenge, new string(filler, max));
            Validator.ShouldNotHaveValidationErrorFor(outExpr, Challenge);
        }

        protected void AssertLength(Expression<Func<TClass, string>> outExpr, int length, char filler = 'x',
            string expectedErrorCode = "ExactLengthValidator")
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(Challenge, new string(filler, length + 1));
            Validator.ShouldHaveValidationErrorFor(outExpr, Challenge).WithErrorCode(expectedErrorCode);
            prop.SetValue(Challenge, new string(filler, length - 1));
            Validator.ShouldHaveValidationErrorFor(outExpr, Challenge).WithErrorCode(expectedErrorCode);
            prop.SetValue(Challenge, new string(filler, length));
            Validator.ShouldNotHaveValidationErrorFor(outExpr, Challenge);
        }

        protected void AssertOnlyAcceptsTableValues<T>(Expression<Func<TClass, string>> outExpr,
            string expectedErrorCode = "IsValidValidator`1") where T : Tabella, new()
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(Challenge, "hello");
            Validator.ShouldHaveValidationErrorFor(outExpr, Challenge).WithErrorCode(expectedErrorCode);

            foreach (var codice in new T().Codici)
            {
                prop.SetValue(Challenge, codice);
                Validator.ShouldNotHaveValidationErrorFor(outExpr, Challenge);
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
            Validator.ShouldHaveValidationErrorFor(outExpr, Challenge);
            prop.SetValue(Challenge, "SI");
            Validator.ShouldNotHaveValidationErrorFor(outExpr, Challenge);
        }

        protected void AssertMustBeBasicLatin(Expression<Func<TClass, string>> outExpr)
        {
            var prop = GetProperty(outExpr);

            // Important: test string not longer than 10. Must include a number.
            prop.SetValue(Challenge, "test ~tes1");
            Validator.ShouldNotHaveValidationErrorFor(outExpr, Challenge);
            prop.SetValue(Challenge, "test Àtes1");
            Validator.ShouldHaveValidationErrorFor(outExpr, Challenge);
        }

        protected void AssertMustBeLatin1Supplement(Expression<Func<TClass, string>> outExpr)
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(Challenge, "test ~tes1");
            Validator.ShouldNotHaveValidationErrorFor(outExpr, Challenge);
            prop.SetValue(Challenge, "test Àtes1");
            Validator.ShouldNotHaveValidationErrorFor(outExpr, Challenge);
            prop.SetValue(Challenge, "test ›tes1");
            Validator.ShouldHaveValidationErrorFor(outExpr, Challenge);
        }

        protected void AssertProvinciaOnlyAcceptsValidValues(Expression<Func<TClass, string>> outExpr)
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(Challenge, "mi");
            Validator.ShouldHaveValidationErrorFor(outExpr, Challenge);

            prop.SetValue(Challenge, "M");
            Validator.ShouldHaveValidationErrorFor(outExpr, Challenge);

            prop.SetValue(Challenge, "MIL");
            Validator.ShouldHaveValidationErrorFor(outExpr, Challenge);

            prop.SetValue(Challenge, "MI");
            Validator.ShouldNotHaveValidationErrorFor(outExpr, Challenge);
        }

        private PropertyInfo GetProperty<T>(Expression<Func<TClass, T>> outExpr)
        {
            var expr = (MemberExpression) outExpr.Body;
            return (PropertyInfo) expr.Member;
        }
    }
}