using System;
using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronica.Validators;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Informazioni relative ad un documento a cui si fa riferimento.
    /// </summary>
    public abstract class DatiDocumento : BusinessObject
    {
        private readonly List<int> _riferimentoNumeroLinea;

        protected DatiDocumento()
        {
            _riferimentoNumeroLinea = new List<int>();
        }
        protected DatiDocumento(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            // TODO validazione per RiferimentoNumeroLinea 2.1.2.1 che è una List<int> ma
            // deve avere len 1..4 come fosse stringa.
            //rules.Add(new FLengthValidator("RiferimentoNumeroLinea", 1, 4));
            rules.Add(new AndCompositeValidator("IdDocumento", new List<Validator>{new FRequiredValidator(), new FLengthValidator(1, 20)}));
            rules.Add(new FLengthValidator("NumItem", 1, 20));
            rules.Add(new FLengthValidator("CodiceCommessaConvenzione", 1, 100));
            rules.Add(new FLengthValidator("CodiceCUP", 1, 15));
            rules.Add(new FLengthValidator("CodiceCIG", 1, 15));
            return rules;
        }

        #region Properties

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Linee di dettaglio della fattura a cui si fa riferimento.
        /// </summary>
        /// <remarks>Se il riferimento è all'intera fattura non viene valorizzato.</remarks>
        [DataProperty]
        public List<int> RiferimentoNumeroLinea { get { return _riferimentoNumeroLinea; }}
        
        /// <summary>
        /// Numero del documento a cui si fa riferimento.
        /// </summary>
        [DataProperty]
        public string IdDocumento { get; set; }
        
        /// <summary>
        /// Data del documento a cui si fa riferimento.
        /// </summary>
        [DataProperty]
        public DateTime? Data { get; set; }
        
        /// <summary>
        /// Identificativo della singola voce all'interno del documento 
        /// (ad esempio, nel caso di ordine di acquisto, è il numero della linea dell'ordine di acquisto, oppure, nel caso di 
        /// contratto, è il numero della linea del contratto, etc.)
        /// </summary>
        [DataProperty]
        public string NumItem { get; set; }

        /// <summary>
        /// Codice della commessa o della convenzione.
        /// </summary>
        [DataProperty]
        public string CodiceCommessaConvenzione { get; set; }

        /// <summary>
        /// Codice gestito dal CIPE che caratterizza ogni progetto di investimento pubblico (Codice Unitario Progetto).
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public string CodiceCUP { get; set; }

        /// <summary>
        /// Codice Identificativo della Gara.
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public string CodiceCIG { get; set; }
        #endregion
    }
}
