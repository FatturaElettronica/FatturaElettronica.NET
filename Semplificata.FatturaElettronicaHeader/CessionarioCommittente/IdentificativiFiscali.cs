using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente
{
    /// <summary>
    /// Identificativi fiscali del cessionario/commitente
    /// </summary>
    /// <seealso cref="FatturaElettronica.Common.BaseClassSerializable" />
    public class IdentificativiFiscali : BaseClassSerializable
    {
        /// <summary>
        /// Dati fiscali del cessionario / committente.
        /// </summary>
        public IdentificativiFiscali()
        {
            IdFiscaleIVA = new IdFiscaleIVA();
        }
        public IdentificativiFiscali(XmlReader r) : base(r) { }

        /// <summary>
        /// Numero di identificazione fiscale ai fini IVA; i primi due caratteri rappresentano il paese ed i restanti il codice
        /// vero e proprio che, per i residenti in Italia, corrisponde al numero di partita IVA.
        /// </summary>
        [DataProperty(order: 0)]
        public IdFiscaleIVA IdFiscaleIVA { get; set; }

        /// <summary>
        /// Numero di Codice Fiscale.
        /// </summary>
        [DataProperty(order: 1)]
        public string CodiceFiscale { get; set; }

    }
}
