using System;
using BusinessObjects;
using FatturaElettronica.Tabelle;
using FluentValidation.Validators;

namespace FatturaElettronica.Validators
{
    public class IsValidValidator<T> : PropertyValidator 
        where T : Tabella, new()
    {
        public IsValidValidator() : base("'{PropertyName}' valori accettati: {AcceptedValues}") { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            context.MessageFormatter.AppendArgument("AcceptedValues", string.Format(string.Join(", ", Domain)));

            return Array.IndexOf(Domain, context.PropertyValue) != -1;
        }
        protected string[] Domain { get { return new T().Codici; } }
    }
}
