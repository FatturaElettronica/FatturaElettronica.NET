using System;
using System.Reflection;
using FatturaElettronica;
using FatturaElettronica.Validators;
using FluentValidation;
using FluentValidation.Results;

namespace FatturaElettronica
{
    public static class FatturaElettronicaExtensions
    {
        public static ValidationResult Validate(this Common.BusinessObject obj)
        {
            var type = Type.GetType(
                string.Format("FatturaElettronica.Validators.{0}Validator", obj.GetType().Name));
            var instance = Activator.CreateInstance(type);
            var method = type.GetMethod("Validate", new [] {obj.GetType()});
            return (ValidationResult)method.Invoke(instance, new [] {obj} );
        }
    }
}
