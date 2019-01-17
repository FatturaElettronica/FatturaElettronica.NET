using FatturaElettronica;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentValidation.Results;
using FluentValidation;
using System;
using FluentValidation.TestHelper;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq;
using FatturaElettronica.Tabelle;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public abstract class BaseClass<TClass, TValidator>
        where TClass : FatturaElettronica.Common.BaseClassSerializable
        where TValidator : IValidator<TClass>
    {
        protected TValidator validator;
        protected TClass challenge;

        [TestInitialize]
        public void Init()
        {
            validator = Activator.CreateInstance<TValidator>();
            challenge = Activator.CreateInstance<TClass>();
        }

        [TestMethod]
        public void ValidateExtensionMethodIsAvailable()
        {
            var r1 = challenge.Validate();
            Assert.IsInstanceOfType(r1, typeof(ValidationResult));

            var r2 = validator.Validate(challenge);

            // ValidationResult equality operatore has not been implemented.
            for (var i = 0; i <= r1.Errors.Count - 1; i++)
            {
                Assert.AreEqual(r1.Errors[i].PropertyName, r2.Errors[i].PropertyName);
                Assert.AreEqual(r1.Errors[i].ErrorMessage, r2.Errors[i].ErrorMessage);
            }
        }
        protected void AssertOptional<T>(Expression<Func<TClass, T>> outExpr)
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(challenge, null);
            validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);

            if (typeof(T) == typeof(string))
            {
                prop.SetValue(challenge, string.Empty);
                validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
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

            prop.SetValue(challenge, null);
            var r = validator.Validate(challenge);
            validator.ShouldHaveValidationErrorFor(outExpr, challenge).WithErrorCode(expectedErrorCode);

            if (typeof(T) == typeof(string))
            {
                prop.SetValue(challenge, string.Empty);
                validator.ShouldHaveValidationErrorFor(outExpr, challenge).WithErrorCode(expectedErrorCode);
            }
            if (typeof(T) == typeof(decimal))
            {
                prop.SetValue(challenge, 0);
                validator.ShouldHaveValidationErrorFor(outExpr, challenge).WithErrorCode(expectedErrorCode);
            }
        }
        protected void AssertMinMaxLength(Expression<Func<TClass, string>> outExpr, int min, int max, char filler = 'x', string expectedErrorCode = "LengthValidator")
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(challenge, new string(filler, max + 1));
            validator.ShouldHaveValidationErrorFor(outExpr, challenge).WithErrorCode(expectedErrorCode);
            prop.SetValue(challenge, new string(filler, min));
            validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
            prop.SetValue(challenge, new string(filler, max));
            validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
        }
        protected void AssertLength(Expression<Func<TClass, string>> outExpr, int length, char filler = 'x', string expectedErrorCode = "ExactLengthValidator")
        {
            var prop = GetProperty(outExpr);
            var r = validator.Validate(challenge);

            prop.SetValue(challenge, new string(filler, length + 1));
            validator.ShouldHaveValidationErrorFor(outExpr, challenge).WithErrorCode(expectedErrorCode);
            prop.SetValue(challenge, new string(filler, length - 1));
            validator.ShouldHaveValidationErrorFor(outExpr, challenge).WithErrorCode(expectedErrorCode);
            prop.SetValue(challenge, new string(filler, length));
            validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
        }
        protected void AssertOnlyAcceptsTableValues<T>(Expression<Func<TClass, string>> outExpr, string expectedErrorCode = "IsValidValidator`1") where T : Tabella, new()
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(challenge, "hello");
            var r = validator.Validate(challenge);
            validator.ShouldHaveValidationErrorFor(outExpr, challenge).WithErrorCode(expectedErrorCode);

            foreach (var codice in new T().Codici)
            {
                prop.SetValue(challenge, codice);
                validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
            }
        }
        protected void AssertCollectionCanBeEmpty<T>(Expression<Func<TClass, List<T>>> outExpr)
        {
            var prop = GetProperty(outExpr);

            var r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == prop.Name));
        }
        public void AssertCollectionCannotBeEmpty<T>(Expression<Func<TClass, List<T>>> outExpr)
        {
            var prop = GetProperty(outExpr);

            var r = validator.Validate(challenge);
            Assert.AreEqual("NotEmptyValidator", r.Errors.FirstOrDefault(x => x.PropertyName == prop.Name).ErrorCode);

        }
        protected void AssertOnlyAcceptsSIValue(Expression<Func<TClass, string>> outExpr)
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(challenge, "NO");
            validator.ShouldHaveValidationErrorFor(outExpr, challenge);
            prop.SetValue(challenge, "SI");
            validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
        }
        protected void AssertMustBeBasicLatin(Expression<Func<TClass, string>> outExpr)
        {
            var prop = GetProperty(outExpr);

            // Important: test string not longer than 10. Must include a number.
            prop.SetValue(challenge, "test ~tes1");
            validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
            prop.SetValue(challenge, "test Àtes1");
            validator.ShouldHaveValidationErrorFor(outExpr, challenge);
        }
        protected void AssertMustBeLatin1Supplement(Expression<Func<TClass, string>> outExpr)
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(challenge, "test ~tes1");
            validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
            prop.SetValue(challenge, "test Àtes1");
            validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
            prop.SetValue(challenge, "test ›tes1");
            validator.ShouldHaveValidationErrorFor(outExpr, challenge);
        }
        protected void AssertProvinciaOnlyAcceptsValidValues(Expression<Func<TClass, string>> outExpr)
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(challenge, "mi");
            validator.ShouldHaveValidationErrorFor(outExpr, challenge);

            prop.SetValue(challenge, "M");
            validator.ShouldHaveValidationErrorFor(outExpr, challenge);

            prop.SetValue(challenge, "MIL");
            validator.ShouldHaveValidationErrorFor(outExpr, challenge);

            prop.SetValue(challenge, "MI");
            validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
        }
        private PropertyInfo GetProperty<T>(Expression<Func<TClass, T>> outExpr)
        {
            var expr = (MemberExpression)outExpr.Body;
            return (PropertyInfo)expr.Member;
        }
    }
}
