using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronica.Validators;
using System.Collections.Generic;
using System.Xml;

namespace FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore
{
    /// <summary>
    /// Represents a Contatti object
    /// </summary>
    public class Contatti : Common.BusinessObject
    {
        public Contatti() { } 
        public Contatti(XmlReader r) : base(r) { } 

        //public override string XmlName { get { return "Contatti"; } }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FLengthValidator("Telefono", 5, 12));
            rules.Add(new FLengthValidator("Fax", 5, 12));
            rules.Add(new FLengthValidator("Email", 7, 256));
            return rules;
        }

        # region Properties 
        /// <summary>
        /// Contatto telefonico fisso o mobile.
        /// </summary>
        [DataProperty]
        public string Telefono { get; set; }

        /// <summary>
        /// Numero di fax.
        /// </summary>
        [DataProperty]
        public string Fax { get; set; }

        /// <summary>
        /// Indirizzo di posta elettronica.
        /// </summary>
        [DataProperty]
        public string Email { get; set; }
        # endregion

    }
}
