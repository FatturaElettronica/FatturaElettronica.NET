using System;
using BusinessObjects;
using BusinessObjects.Validators;

namespace FatturaElettronica.Validators
{
    /// <summary>
    /// Validates AliquotaIVA properties
    /// </summary>
    class FPECDestinatarioValidator : Validator
    {
        //public FPECDestinatarioValidator(string propertyName) : base(propertyName) { }
        public override bool Validate(BusinessObjectBase businessObject)
        {
            var codiceDestinatario = GetPropertyValue(businessObject, "CodiceDestinatario");
            var pecDestinatario = GetPropertyValue(businessObject, PropertyName);

            if (codiceDestinatario != null && (string)codiceDestinatario == "0000000") {
                if (pecDestinatario == null || string.IsNullOrEmpty((string)pecDestinatario)) {
                    Description = "00426: 1.1.6 PECDestinatario non valorizzato a fronte di 1.1.4 <CodiceDestinatario> con valore 0000000";
                    return false;
                }
            }
            else {
                if (pecDestinatario != null && !string.IsNullOrEmpty((string)pecDestinatario)) {
                    Description = "00426: 1.1.6 PECDestinatario valorizzato a fronte di 1.1.4 <Codice Destinatario> con valore diverso da 0000000";
                    return false;
                }
            }
            return true;
        }
    }
}
