using System;
using System.Collections.Generic;
using FatturaElettronica.Tabelle;
using FluentValidation.Validators;

namespace FatturaElettronica.Validators
{
    public class IsValidValidator<T> : PropertyValidator where T : Tabella, new()
    {
        private static readonly Lazy<T> DomainObjectLazy = new Lazy<T>(() => new T());

        public IsValidValidator() : base("'{PropertyName}' valori accettati: {AcceptedValues}")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            context.MessageFormatter.AppendArgument("AcceptedValues", string.Format(string.Join(", ", Domain)));

            if (context.PropertyValue is string codice)
                return Domain.Contains(codice);

            return false;
        }

        private static HashSet<string> Domain
        {
            get { return DomainObjectLazy.Value.Codici; }
        }
    }
}