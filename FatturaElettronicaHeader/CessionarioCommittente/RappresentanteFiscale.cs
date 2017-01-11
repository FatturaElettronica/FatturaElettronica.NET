using System.Xml;
using BusinessObjects;
using FatturaElettronica.Common;

namespace FatturaElettronica.FatturaElettronicaHeader.CessionarioCommittente
{
    /// <summary>
    /// Represents a CessionarioCommittente.RappresentanteFiscale object.
    /// </summary>
    public class RappresentanteFiscale : DenominazioneNomeCognome
    {
        private readonly IdFiscaleIVA _idFiscaleIva;

        public RappresentanteFiscale() {
            _idFiscaleIva = new IdFiscaleIVA();
        }
        public RappresentanteFiscale(XmlReader r) : base(r) { }

        # region Properties 
        /// <summary>
        /// Numero di identificazione fiscale ai fini IVA; i primi due caratteri rappresentano il paese ed i restanti il codice
        /// vero e proprio che, per i residenti in Italia, corrisponde al numero di partita IVA.
        /// </summary>
        [DataProperty]
        public IdFiscaleIVA IdFiscaleIVA { 
            get { return _idFiscaleIva; }
        }
        # endregion

    }
}
