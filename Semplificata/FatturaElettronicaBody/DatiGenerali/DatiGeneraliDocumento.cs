﻿using System;
using System.Collections.Generic;
using System.Xml;
using FatturaElettronica.Common;

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
        [DataProperty]
        public string TipoDocumento { get; set; }

        /// <summary>
        /// Codice espresso secondo lo standard ISO 4217 alpha-3:2001 della valuta utilizzata per l'indicazione degli importi.
        /// </summary>
        [DataProperty]
        public string Divisa { get; set; }

        /// <summary>
        /// Data del documento.
        /// </summary>
        [DataProperty]
        public DateTime Data { get; set; }

        /// <summary>
        /// Numero progressivo del documento.
        /// </summary>
        [DataProperty]
        public string Numero { get; set; }
    }
}
