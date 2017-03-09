using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.FatturaElettronicaHeader.DatiTrasmissione
{
    /// <summary>
    /// Represents a ContattiTrasmittente object
    /// </summary>
    public class ContattiTrasmittente : BaseClassSerializable
    {
        private string _telefono;
        private string _email;

        public ContattiTrasmittente() { }
        public ContattiTrasmittente(XmlReader r) : base(r) { }

        /// <summary>
        /// Contatto telefonico fisso o mobile.
        /// </summary>
        [DataProperty]
        public string Telefono {
            get { return _telefono; }
            set {
                _telefono = CleanString(value);
                NotifyChanged();
            }
        }

        /// <summary>
        /// Indirizzo di posta elettronica.
        /// </summary>
        [DataProperty]
        public string Email {
            get { return _email; }
            set {
                _email = CleanString(value);
                NotifyChanged();
            }
        }
    }
}
