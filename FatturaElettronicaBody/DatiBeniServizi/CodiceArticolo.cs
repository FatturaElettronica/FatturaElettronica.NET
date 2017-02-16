using System.Xml;
using FatturaElettronica.BusinessObjects;

namespace FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi
{
    /// <summary>
    /// Eventuale codifica dell'articolo.
    /// </summary>
    public class CodiceArticolo : Common.BusinessObject
    {
        public CodiceArticolo() { }
        public CodiceArticolo(XmlReader r) : base(r) { }

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
    }
}
