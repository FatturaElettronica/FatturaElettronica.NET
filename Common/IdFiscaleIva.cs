using System.Xml;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Numero di identificazione fiscale ai fini IVA; i primi due caratteri rappresentano il paese ed i restanti il codice
    /// vero e proprio che, per i residenti in Italia, corrisponde al numero di partita IVA.
    /// </summary>
    public class IdFiscaleIVA : BaseClassSerializable
    {
        public IdFiscaleIVA() { }
        public IdFiscaleIVA(XmlReader r) : base(r) { }

        /// <summary>
        /// Codice della nazione espresso secondo lo standard ISO 3166-1 alpha-2 code.
        /// </summary>
        [DataProperty]
        public string IdPaese { get; set; }

        /// <summary>
        /// Codice identificativo fiscale.
        /// </summary>
        [DataProperty]
        public string IdCodice { get; set; }

        public override string ToString()
        {
            return IdPaese + IdCodice;
        }
    }
}
