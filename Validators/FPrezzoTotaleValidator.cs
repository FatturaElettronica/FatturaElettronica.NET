using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Validators;

namespace FatturaElettronicaPA.Validators
{
    public class FPrezzoTotaleValidator : DelegateValidator
    {
        public FPrezzoTotaleValidator(string propertyName, string description, SimpleValidatorDelegate ruleDelegate) : base(propertyName, description, ruleDelegate)
        {
        }
    }
}
