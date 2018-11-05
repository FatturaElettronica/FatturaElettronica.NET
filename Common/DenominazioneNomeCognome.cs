using System.Xml;
using Newtonsoft.Json;

namespace FatturaElettronica.Common
{

    /// <summary>
    /// Represents a Anagrafica object
    /// </summary>
    public class DenominazioneNomeCognome : BaseClassSerializable
    {

        public DenominazioneNomeCognome() { }
        public DenominazioneNomeCognome(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Gets or sets the Denominazione.
        /// </summary>
        [DataProperty]
        public string Denominazione { get; set; }

        /// <summary>
        /// Gets or sets the Nome.
        /// </summary>
        [DataProperty]
        public string Nome { get; set; }

        /// <summary>
        /// Gets or sets the Cognome.
        /// </summary>
        [DataProperty]
        public string Cognome { get; set; }

        /// <summary>
        /// Returns Cognome and Nome as a single value.
        /// </summary>
        /// <remarks>This is not a OrderedDataProperty so it will not be serialized to XML.</remarks>
        [JsonIgnore]
        public string CognomeNome
        {
            get
            {
                var r = ((Cognome ?? string.Empty) + " " + (Nome ?? string.Empty)).Trim();
                return string.IsNullOrEmpty(r) ? null : r;
            }
        }
    }
}
