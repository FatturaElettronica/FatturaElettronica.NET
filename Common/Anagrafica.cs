using System.Xml;

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
        [Core.DataProperty(order: 3)]
        public string Titolo { get; set; }

        /// <summary>
        /// Gets or sets the CodEORI.
        /// </summary>
        [Core.DataProperty(order: 4)]
        // ReSharper disable once InconsistentNaming
        public string CodEORI { get; set; }
    }
}
