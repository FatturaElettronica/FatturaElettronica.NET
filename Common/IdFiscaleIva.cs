using System.Xml;
using FatturaElettronica.BusinessObjects;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Numero di identificazione fiscale ai fini IVA; i primi due caratteri rappresentano il paese ed i restanti il codice
    /// vero e proprio che, per i residenti in Italia, corrisponde al numero di partita IVA.
    /// </summary>
    public class IdFiscaleIVA : BusinessObject
    {
        private string _idPaese;
        private string _idCodice;

        public IdFiscaleIVA() { }
        public IdFiscaleIVA(XmlReader r) : base(r) { }

        /// <summary>
        /// Codice della nazione espresso secondo lo standard ISO 3166-1 alpha-2 code.
        /// </summary>
        [DataProperty]
        public string IdPaese {
            get { return _idPaese; }
            set {
                _idPaese = CleanString(value);
                NotifyChanged();
            }
        }

        /// <summary>
        /// Codice identificativo fiscale.
        /// </summary>
        [DataProperty]
        public string IdCodice {
            get { return _idCodice; }
            set {
                _idCodice = CleanString(value);
                NotifyChanged();
            }
        }
    }
}
