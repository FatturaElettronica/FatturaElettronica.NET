using System;
using System.Collections.Generic;
using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Informazioni relative ad un documento a cui si fa riferimento.
    /// </summary>
    public abstract class DatiDocumento : BaseClassSerializable
    {
        private readonly List<int> _riferimentoNumeroLinea;

        protected DatiDocumento()
        {
            _riferimentoNumeroLinea = new List<int>();
        }
        protected DatiDocumento(XmlReader r) : base(r) { }

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
    }
}
