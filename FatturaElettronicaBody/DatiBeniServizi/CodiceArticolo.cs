using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiBeniServizi
{
    /// <summary>
    /// Eventuale codifica dell'articolo.
    /// </summary>
    public class CodiceArticolo : Common.BusinessObject
    {

        public CodiceArticolo() { }
        public CodiceArticolo(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add( new AndCompositeValidator("CodiceTipo", new List<Validator> {new FRequiredValidator(), 
                new FLengthValidator(1, 35)}));
            rules.Add( new AndCompositeValidator("CodiceValore", new List<Validator> {new FRequiredValidator(), 
                new FLengthValidator(1, 35)}));
            return rules;
        }

        #region Properties
        /// <summary>
        /// Indica la tipologia di codice articolo (TARIC, CPV, EAN, SSC, ...)
        /// </summary>
        [DataProperty]
        public string CodiceTipo { get; set; }

        /// <summary>
        /// Indica il valore del codice articolo corrispondente alla tipologia riportata nel campo CodiceTipo.
        /// </summary>
        [DataProperty]
        public string CodiceValore { get; set; }
        #endregion
    }
}
