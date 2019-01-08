using System;
using System.Collections.Concurrent;
using FluentValidation;
using FluentValidation.Results;

namespace FatturaElettronica
{
    public static class FatturaElettronicaExtensions
    {
        private static readonly ConcurrentDictionary<string, IValidator> ValidatorsCache = new ConcurrentDictionary<string, IValidator>();
        public static ValidationResult Validate<T>(this T obj) where T : Common.BaseClassSerializable
        {
            var validator = ValidatorsCache.GetOrAdd(typeof(T).Name, name =>
            {
                var type = Type.GetType($"FatturaElettronica.Validators.{name}Validator");
                return (IValidator) Activator.CreateInstance(type);
            });

            return validator.Validate(obj);
        }
    }
}
