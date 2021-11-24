using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente
{
    /// <summary>
    /// Represents a CessionarioCommittente.RappresentanteFiscale object.
    /// </summary>
    public class RappresentanteFiscaleCessionarioCommittente : DenominazioneNomeCognome
    {
        public RappresentanteFiscaleCessionarioCommittente()
        {
            IdFiscaleIVA = new();
        }
        public RappresentanteFiscaleCessionarioCommittente(XmlReader r) : base(r) { }

        /// <summary>
        /// Numero di identificazione fiscale ai fini IVA; i primi due caratteri rappresentano il paese ed i restanti il codice
        /// vero e proprio che, per i residenti in Italia, corrisponde al numero di partita IVA.
        /// </summary>
        [Core.DataProperty(order: -1)]
        public IdFiscaleIVA IdFiscaleIVA { get; set; }
    }
}
