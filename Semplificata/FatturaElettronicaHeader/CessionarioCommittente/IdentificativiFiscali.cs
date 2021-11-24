using System.Xml;
using FatturaElettronica.Common;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente
{
    /// <summary>
    /// Identificativi fiscali del cessionario/commitente
    /// </summary>
    public class IdentificativiFiscali : BaseClassSerializable
    {
        /// <summary>
        /// Dati fiscali del cessionario / committente.
        /// </summary>
        public IdentificativiFiscali()
        {
            IdFiscaleIVA = new();
        }
        public IdentificativiFiscali(XmlReader r) : base(r) { }

        /// <summary>
        /// Numero di identificazione fiscale ai fini IVA; i primi due caratteri rappresentano il paese ed i restanti il codice
        /// vero e proprio che, per i residenti in Italia, corrisponde al numero di partita IVA.
        /// </summary>
        [Core.DataProperty(order: 0)]
        public IdFiscaleIVA IdFiscaleIVA { get; set; }

        /// <summary>
        /// Numero di Codice Fiscale.
        /// </summary>
        [Core.DataProperty(order: 1)]
        public string CodiceFiscale { get; set; }

    }
}
