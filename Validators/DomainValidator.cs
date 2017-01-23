using System;
using FluentValidation.Validators;

namespace FatturaElettronica.Validators
{
    public abstract class DomainValidator<T> : PropertyValidator
    {
        public DomainValidator() : base("'{PropertyName}' valori accettati: {AcceptedValues}") { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            context.MessageFormatter.AppendArgument("AcceptedValues", string.Format(string.Join(", ", Domain)));

            return Array.IndexOf(Domain, context.PropertyValue) != -1;
        }
        protected abstract string[] Domain { get; }
    }
}
