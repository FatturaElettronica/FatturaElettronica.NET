using System;
using System.Collections.Generic;
using System.Xml;
using FatturaElettronica.Common;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Dati generali del documento principale ed i dati dei documenti correlati.
    /// </summary>
    public class DatiGeneraliDocumento : BaseClassSerializable
    {
        /// <summary>
        /// Dati generali del documento principale ed i dati dei documenti correlati.
        /// </summary>
        public DatiGeneraliDocumento()
        {
        }
        public DatiGeneraliDocumento(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati generali del documento principale.
        /// </summary>
        [Core.DataProperty]
        public string TipoDocumento { get; set; }

        /// <summary>
        /// Codice espresso secondo lo standard ISO 4217 alpha-3:2001 della valuta utilizzata per l'indicazione degli importi.
        /// </summary>
        [Core.DataProperty]
        public string Divisa { get; set; }

        /// <summary>
        /// Data del documento.
        /// </summary>
        [Core.DataProperty]
        public DateTime Data { get; set; }

        /// <summary>
        /// Numero progressivo del documento.
        /// </summary>
        [Core.DataProperty]
        public string Numero { get; set; }
        
        /// <summary>
        /// Bollo assolto ai sendi del decreto MEF 17 giugno 2014 (art.6).
        /// </summary>
        [Core.DataProperty]
        public string BolloVirtuale { get; set; }
    }
}
