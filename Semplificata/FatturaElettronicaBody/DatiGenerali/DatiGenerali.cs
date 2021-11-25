using System.Xml;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Dati generali del documento principale e dati dei documenti correlati.
    /// </summary>
    public class DatiGenerali : BaseClassSerializable
    {
        /// <summary>
        /// Dati generali del documento principale e dati dei documenti correlati.
        /// </summary>
        public DatiGenerali()
        {
            DatiGeneraliDocumento = new();
            DatiFatturaRettificata = new();
        }
        public DatiGenerali(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati generali del documento principale.
        /// </summary>
        [Core.DataProperty]
        public DatiGeneraliDocumento DatiGeneraliDocumento { get; set; }

        /// <summary>
        /// Blocco contenente le informazioni relative alla fattura rettificata. 
        /// Vale per le fatture emesse ai sensi dell'articolo 26 DPR 633/72
        /// </summary>
        [Core.DataProperty]
        public DatiFatturaRettificata DatiFatturaRettificata { get; set; }
    }
}
