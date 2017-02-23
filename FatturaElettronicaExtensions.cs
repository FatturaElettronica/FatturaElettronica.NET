using System;
using System.Reflection;
using FluentValidation.Results;

namespace FatturaElettronica
{
    public static class FatturaElettronicaExtensions
    {
        public static ValidationResult Validate(this Common.BaseClassSerializable obj)
        {
            var type = Type.GetType(
                string.Format("FatturaElettronica.Validators.{0}Validator", obj.GetType().Name));
            var instance = Activator.CreateInstance(type);
            var method = type.GetRuntimeMethod("Validate", new[] { obj.GetType() });
            return (ValidationResult)method.Invoke(instance, new [] {obj} );
        }
        
        public static bool IsValid(this Common.BaseClassSerializable obj)
        {
            return obj.Validate().IsValid;
        }
    }
}
