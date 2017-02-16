using System.Xml;
using FatturaElettronica.BusinessObjects;

namespace FatturaElettronica.FatturaElettronicaHeader.DatiTrasmissione
{
    /// <summary>
    /// Represents a ContattiTrasmittente object
    /// </summary>
    public class ContattiTrasmittente : Common.BusinessObject
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
