using System.ComponentModel;
using System.Xml;

namespace FatturaElettronica.Common
{

    /// <summary>
    /// Represents a Anagrafica object
    /// </summary>
    public abstract class Località : Core.BaseClassSerializable
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        protected Località() { }
        protected Località(XmlReader r) : base(r) { } 

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Indirizzo (nome della via, piazza etc.)
        /// </summary>
        [Core.DataProperty]
        public string Indirizzo { get; set; }

        /// <summary>
        /// Numero civico riferito all'indirizzo (non indicare se già presente nel campo indirizzo).
        /// </summary>
        [Core.DataProperty]
        public string NumeroCivico { get; set; }

        /// <summary>
        /// Codice Avviamento Postale.
        /// </summary>
        [Core.DataProperty]
        public string CAP { get; set; }

        /// <summary>
        /// Comune.
        /// </summary>
        [Core.DataProperty]
        public string Comune { get; set; }

        /// <summary>
        /// Sigla della provincia di appartenenza del comune.
        /// </summary>
        [Core.DataProperty]
        public string Provincia { get; set; }

        /// <summary>
        /// Codice della nazione espresso secondo lo standard ISO 3166-1 alpha-2 code.
        /// </summary>
        [Core.DataProperty]
        [DefaultValue("IT")]
        public string Nazione { get; set; }
    }
}
