using System.Text.Json.Serialization;
using System.Xml;
using FatturaElettronica.Common;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Semplificata.FatturaElettronicaHeader
{
    /// <summary>
    /// Dati relativi al rappresentante fiscale del cessionario / committente.
    /// </summary>
    public class RappresentanteFiscale : BaseClassSerializable
    {

        /// <summary>
        /// Dati relativi al rappresentante fiscale del cessionario / committente.
        /// </summary>
        public RappresentanteFiscale()
        {
            IdFiscaleIVA = new();
        }
        public RappresentanteFiscale(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati anagrafici del rappresentante fiscale del cedente / prestatore.
        /// </summary>
        [Core.DataProperty(order: 0)]
        public IdFiscaleIVA IdFiscaleIVA { get; set; }

        /// <summary>
        /// Gets or sets the Denominazione.
        /// </summary>
        [Core.DataProperty(order: 1)]
        public string Denominazione { get; set; }

        /// <summary>
        /// Gets or sets the Nome.
        /// </summary>
        [Core.DataProperty(order: 2)]
        public string Nome { get; set; }

        /// <summary>
        /// Gets or sets the Cognome.
        /// </summary>
        [Core.DataProperty(order: 3)]
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
