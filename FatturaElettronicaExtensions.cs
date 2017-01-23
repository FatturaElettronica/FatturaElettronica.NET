using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FatturaElettronica.FatturaElettronicaHeader.DatiTrasmissione;
using FatturaElettronica.Validators;

namespace FatturaElettronica
{
    public static class FatturaElettronicaExtensions
    {
        public static FluentValidation.Results.ValidationResult Validate(this DatiTrasmissione fe)
        {
            var validator = new FatturaElettronicaValidator();
            return validator.Validate(fe);
        }
    }
}
