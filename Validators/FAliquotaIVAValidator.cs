using System;
using BusinessObjects;
using BusinessObjects.Validators;

namespace FatturaElettronica.Validators
{
    /// <summary>
    /// Validates AliquotaIVA properties
    /// </summary>
    class FAliquotaIVAValidator : Validator
    {
        public FAliquotaIVAValidator(string propertyName) : base(propertyName, "00424: l’aliquota IVA deve essere indicata in termini percentuali.") { }
        public override bool Validate(BusinessObjectBase businessObject)
        {
            var v = (decimal)GetPropertyValue(businessObject, PropertyName);
            return v == 0 || v >= 1.00M;
        }
    }
}
