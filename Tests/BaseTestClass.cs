using FatturaElettronica;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentValidation.Results;
using FluentValidation;
using System;

namespace Tests
{
    [TestClass]
    public abstract class BaseTestClass<TClass, TValidator> 
        where TClass : FatturaElettronica.Common.BusinessObject
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
            for (var i=0; i<=r1.Errors.Count-1;i++)
            {
                Assert.AreEqual(r1.Errors[i].PropertyName, r2.Errors[i].PropertyName);
                Assert.AreEqual(r1.Errors[i].ErrorMessage, r2.Errors[i].ErrorMessage);
            }
        }
    }
}
