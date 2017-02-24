using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.FatturaElettronicaBody.Allegati
{
    /// <summary>
    /// Dati relativi ad eventuale allegato.
    /// </summary>
    public class Allegati : BaseClassSerializable
    {
        public Allegati() { }
        public Allegati(XmlReader r) : base(r) { }

        /// <summary>
        /// Nome dell'allegato.
        /// </summary>
        [DataProperty]
        public string NomeAttachment { get; set; }

        /// <summary>
        /// Algoritmo usato per comprimere l'attachment (ad es. ZIP, RAR, ...)
        /// </summary>
        [DataProperty]
        public string AlgoritmoCompressione { get; set; }

        /// <summary>
        /// Formato dell'attachment (ad es: TXT, XML, DOC, PDF, ...)
        /// </summary>
        [DataProperty]
        public string FormatoAttachment { get; set; }

        /// <summary>
        /// Descrizione del documento.
        /// </summary>
        [DataProperty]
        public string DescrizioneAttachment { get; set; }

        /// <summary>
        /// Contiene il documento allegato alla fattura; il contenuto è demandato agli accordi tra PA e fornitore.
        /// </summary>
        [DataProperty]
        public byte[] Attachment { get; set; }
    }
}
