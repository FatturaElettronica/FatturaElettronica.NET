using FatturaElettronica.Common;
using System.Xml;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Semplificata.FatturaElettronicaHeader.CedentePrestatore
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
        [Core.DataProperty]
        public string Ufficio { get; set; }

        /// <summary>
        /// Numero di iscrizione al registro delle imprese.
        /// </summary>
        [Core.DataProperty]
        // ReSharper disable once InconsistentNaming
        public string NumeroREA { get; set; }

        /// <summary>
        /// Nei soli casi di società di capitali (Spa, SApA, SRL), il campo va valorizzato per indicare il capitale sociale.
        /// </summary>
        [Core.DataProperty]
        public decimal? CapitaleSociale { get; set; }

        /// <summary>
        /// Nei soli casi di SRL, il campo va valorizzato per indicare se vi è un socio unico oppure se vi sono più soci.
        /// </summary>
        [Core.DataProperty]
        public string SocioUnico { get; set; }

        /// <summary>
        /// Indica se la Società si trova in stato di liquidazione oppure no.
        /// </summary>
        [Core.DataProperty]
        public string StatoLiquidazione { get; set; }
    }
}
