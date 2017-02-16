using System.Xml;
using FatturaElettronica.BusinessObjects;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Represents a DatiAnagrafici object
    /// </summary>
    public class DatiAnagrafici : BusinessObject
    {
        private readonly IdFiscaleIVA _idFiscaleIva;
        private readonly Anagrafica _anagrafica;

        /// <summary>
        /// Dati anagrafici, professionali e fiscali
        /// </summary>
        public DatiAnagrafici() {
            _idFiscaleIva = new IdFiscaleIVA();
            _anagrafica = new Anagrafica();
        }
        public DatiAnagrafici(XmlReader r) : base(r) { }

        /// <summary>
        /// Numero di identificazione fiscale ai fini IVA; i primi due caratteri rappresentano il paese ed i restanti il codice
        /// vero e proprio che, per i residenti in Italia, corrisponde al numero di partita IVA.
        /// </summary>
        [DataProperty(order:0)]
        public IdFiscaleIVA IdFiscaleIVA { 
            get { return _idFiscaleIva; }
        }

        /// <summary>
        /// Numero di Codice Fiscale.
        /// </summary>
        [DataProperty(order:1)]
        public string CodiceFiscale { get; set; }

        /// <summary>
        /// Dati anagrafici identificativi del soggetto. 
        /// </summary>
        [DataProperty(order:2)]
        public Anagrafica Anagrafica { 
            get { return _anagrafica; }
        }
    }
}
