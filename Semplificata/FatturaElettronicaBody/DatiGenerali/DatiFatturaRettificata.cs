using System;
using System.Collections.Generic;
using System.Xml;
using FatturaElettronica.Common;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Dati relativi alla fattura rettificata.
    /// </summary>
    public class DatiFatturaRettificata : BaseClassSerializable
    {
        /// <summary>
        /// Dati generali del documento principale ed i dati dei documenti correlati.
        /// </summary>
        public DatiFatturaRettificata()
        {
        }
        public DatiFatturaRettificata(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Numero progressivo della fattura rettificata.
        /// </summary>
        [Core.DataProperty]
        public string NumeroFR { get; set; }

        /// <summary>
        /// Data della fattura rettificata.
        /// </summary>
        [Core.DataProperty]
        public DateTime? DataFR { get; set; }

        /// <summary>
        /// Indicazioni specifiche degli elelementi oggetto di rettifica.
        /// </summary>
        [Core.DataProperty]
        public string ElementiRettificati { get; set; }
    }
}
