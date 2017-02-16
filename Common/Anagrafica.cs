using System.Xml;
using FatturaElettronica.BusinessObjects;

namespace FatturaElettronica.Common
{

    /// <summary>
    /// Represents a Anagrafica object
    /// </summary>
    public class Anagrafica : DenominazioneNomeCognome
    {

        public Anagrafica() { } 
        public Anagrafica(XmlReader r) : base(r) { } 

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Gets or sets the Titolo.
        /// </summary>
        [DataProperty]
        public string Titolo { get; set; }

        /// <summary>
        /// Gets or sets the CodEORI.
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public string CodEORI { get; set; }
    }
}
