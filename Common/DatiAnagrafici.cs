using System.Xml;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Represents a DatiAnagrafici object
    /// </summary>
    public class DatiAnagrafici : Core.BaseClassSerializable
    {
        /// <summary>
        /// Dati anagrafici, professionali e fiscali
        /// </summary>
        public DatiAnagrafici()
        {
            IdFiscaleIVA = new();
            Anagrafica = new();
        }
        public DatiAnagrafici(XmlReader r) : base(r) { }

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

        /// <summary>
        /// Dati anagrafici identificativi del soggetto. 
        /// </summary>
        [Core.DataProperty(order: 2)]
        public Anagrafica Anagrafica { get; set; }

    }
}
