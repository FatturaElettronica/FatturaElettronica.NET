using System;
using System.Collections.Concurrent;
using System.Reflection;
using FatturaElettronica.Core;
using FluentValidation;
using FluentValidation.Results;

namespace FatturaElettronica.Extensions
{
    public static class FatturaElettronicaExtensions
    {
        private static readonly ConcurrentDictionary<string, IValidator> ValidatorsCache = new();
        public static ValidationResult Validate<T>(this T obj) where T : BaseClassSerializable
        {
            var t = typeof(T);
            if(t.GetTypeInfo().IsAbstract) t = obj.GetType();
            var name = (t.FullName.Contains("Semplificata") ? "Semplificata." : string.Empty) + t.Name;

            var validator = ValidatorsCache.GetOrAdd(name, n =>
            {
                var type = Type.GetType($"FatturaElettronica.Validators.{n}Validator");
                return (IValidator)Activator.CreateInstance(type);
            });

            var context = new ValidationContext<T>(obj);
            return validator.Validate(context);
        }
    }
}
