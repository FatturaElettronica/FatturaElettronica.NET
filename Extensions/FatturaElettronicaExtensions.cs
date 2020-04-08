using System;
using System.Collections.Concurrent;
using FluentValidation;
using FluentValidation.Results;
using System.Reflection;

namespace FatturaElettronica
{
    public static class FatturaElettronicaExtensions
    {
        private static readonly ConcurrentDictionary<string, IValidator> ValidatorsCache = new ConcurrentDictionary<string, IValidator>();
        public static ValidationResult Validate<T>(this T obj) where T : Common.BaseClassSerializable
        {
            var t = typeof(T);
            if(t.GetTypeInfo().IsAbstract) t = obj.GetType();
            var name = (t.FullName.Contains("Semplificata") ? "Semplificata." : string.Empty) + t.Name;

            var validator = ValidatorsCache.GetOrAdd(name, n =>
            {
                var type = Type.GetType($"FatturaElettronica.Validators.{n}Validator");
                return (IValidator)Activator.CreateInstance(type);
            });

            return validator.Validate(obj);
        }
    }
}
