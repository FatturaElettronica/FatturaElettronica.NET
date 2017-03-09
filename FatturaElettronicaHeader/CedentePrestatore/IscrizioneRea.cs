using FatturaElettronica.Common;
using System.Xml;

namespace FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore
{
    /// <summary>
    /// Represents a DatiAnagrafici object
    /// </summary>
    public class IscrizioneREA : BaseClassSerializable
    {
        public IscrizioneREA() { } 
        public IscrizioneREA(XmlReader r) : base(r) { } 

        /// <summary>
        /// Sigla della provincia dell'Ufficio del registro delle imprese presso il quale è registata la società.
        /// </summary>
        [DataProperty]
        public string Ufficio { get; set; }

        /// <summary>
        /// Numero di iscrizione al registro delle imprese.
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public string NumeroREA { get; set; }

        /// <summary>
        /// Nei soli casi di società di capitali (Spa, SApA, SRL), il campo va valorizzato per indicare il capitale sociale.
        /// </summary>
        [DataProperty]
        public decimal? CapitaleSociale { get; set; }

        /// <summary>
        /// Nei soli casi di SRL, il campo va valorizzato per indicare se vi è un socio unico oppure se vi sono più soci.
        /// </summary>
        [DataProperty]
        public string SocioUnico { get; set; }

        /// <summary>
        /// Indica se la Società si trova in stato di liquidazione oppure no.
        /// </summary>
        [DataProperty]
        public string StatoLiquidazione { get; set; }
    }
}
