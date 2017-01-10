using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronica.Validators;

namespace FatturaElettronica.Common
{

    /// <summary>
    /// Represents a Anagrafica object
    /// </summary>
    public abstract class Località : BusinessObject
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        protected Località() { }
        protected Località(XmlReader r) : base(r) { } 

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new AndCompositeValidator(
                "Indirizzo",
                new List<Validator>{
                    new FRequiredValidator(), 
                    new FLengthValidator(1, 60)}));
            rules.Add(new FLengthValidator("NumeroCivico", 1, 8));
            rules.Add(new AndCompositeValidator(
                "CAP",
                new List<Validator>{
                    new FRequiredValidator(), 
                    new FLengthValidator(5)}));
            rules.Add(new AndCompositeValidator(
                "Comune",
                new List<Validator>{
                    new FRequiredValidator(), 
                    new FLengthValidator(1, 60)}));
            rules.Add(new FProvinciaValidator("Provincia"));
            rules.Add(new AndCompositeValidator(
                "Nazione",
                new List<Validator>{
                    new FRequiredValidator(), 
                    new FCountryValidator()}));
            return rules;
        }

        #region Properties 

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Indirizzo (nome della via, piazza etc.)
        /// </summary>
        [DataProperty]
        public string Indirizzo { get; set; }

        /// <summary>
        /// Numero civico riferito all'indirizzo (non indicare se già presente nel campo indirizzo).
        /// </summary>
        [DataProperty]
        public string NumeroCivico { get; set; }

        /// <summary>
        /// Codice Avviamento Postale.
        /// </summary>
        [DataProperty]
        public string CAP { get; set; }

        /// <summary>
        /// Comune.
        /// </summary>
        [DataProperty]
        public string Comune { get; set; }

        /// <summary>
        /// Sigla della provincia di appartenenza del comune.
        /// </summary>
        [DataProperty]
        public string Provincia { get; set; }

        /// <summary>
        /// Codice della nazione espresso secondo lo standard ISO 3166-1 alpha-2 code.
        /// </summary>
        [DataProperty]
        public string Nazione { get; set; }

        #endregion
    }
}
