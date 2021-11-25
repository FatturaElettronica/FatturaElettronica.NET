using System.Xml;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaHeader.DatiTrasmissione
{
    /// <summary>
    /// Represents a ContattiTrasmittente object
    /// </summary>
    public class ContattiTrasmittente : BaseClassSerializable
    {
        public ContattiTrasmittente() { }
        public ContattiTrasmittente(XmlReader r) : base(r) { }

        /// <summary>
        /// Contatto telefonico fisso o mobile.
        /// </summary>
        [Core.DataProperty]
        public string Telefono { get; set; }

        /// <summary>
        /// Indirizzo di posta elettronica.
        /// </summary>
        [Core.DataProperty]
        public string Email { get; set; }
    }
}
