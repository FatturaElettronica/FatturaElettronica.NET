using System;
using BusinessObjects;
using BusinessObjects.Validators;

namespace FatturaElettronica.Validators
{
    /// <summary>
    /// Validates AliquotaIVA properties
    /// </summary>
    class FCodiceDestinatarioValidator : Validator
    {
        public override bool Validate(BusinessObjectBase businessObject)
        {
            var codiceDestinatario = GetPropertyValue(businessObject, "CodiceDestinatario");
            var formatoTrasmissione = GetPropertyValue(businessObject, "FormatoTrasmissione");

            if (formatoTrasmissione != null && (string)formatoTrasmissione == Impostazioni.FormatoTrasmissione.Privati) {
                if (codiceDestinatario == null || ((string)codiceDestinatario).Length != 7) {
                    Description = string.Format(
                        "1.1.4 CodiceDestinatario diverso da 7 caratteri a fronte di 1.1.3 FormatoTrasmissione con valore {0}", 
                        Impostazioni.FormatoTrasmissione.Privati);
                    return false;
                }
            }
            if (formatoTrasmissione != null && (string)formatoTrasmissione == Impostazioni.FormatoTrasmissione.PubblicaAmministrazione) {
                if (codiceDestinatario == null || ((string)codiceDestinatario).Length != 6) {
                    Description = string.Format(
                        "1.1.4 CodiceDestinatario diverso da 6 caratteri a fronte di 1.1.3 FormatoTrasmissione con valore {0}",
                        Impostazioni.FormatoTrasmissione.PubblicaAmministrazione);
                    return false;
                }
            }
            return true;
        }
    }
}
