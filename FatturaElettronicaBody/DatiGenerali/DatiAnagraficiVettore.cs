using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiGenerali
{
    public class DatiAnagraficiVettore : Common.DatiAnagrafici
    {
        public DatiAnagraficiVettore() { }
        public DatiAnagraficiVettore(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules()
        {
            var rules = base.CreateRules();
            rules.Add(new FRequiredValidator("IdFiscaleIVA"));
            rules.Add(new FLengthValidator("NumeroLicenzaGuida", 1, 20));
            return rules;
        }

        #region Properties 
        /// <summary>
        /// Numero identificativo della licenza di guida (es. numero patente).
        /// </summary>
        [DataProperty]
        public string NumeroLicenzaGuida { get; set; }
        #endregion
    }
}
