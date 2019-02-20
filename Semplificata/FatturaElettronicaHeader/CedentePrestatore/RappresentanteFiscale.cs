using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.Semplificata.FatturaElettronicaHeader
{
    /// <summary>
    /// Dati relativi al rappresentante fiscale del cedente / prestatore.
    /// </summary>
    public class RappresentanteFiscale : BaseClassSerializable
    {

        /// <summary>
        /// Dati relativi al rappresentante fiscale del cedente / prestatore.
        /// </summary>
        public RappresentanteFiscale()
        {
            IdFiscaleIVA = new IdFiscaleIVA();
        }
        public RappresentanteFiscale(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati anagrafici del rappresentante fiscale del cedente / prestatore.
        /// </summary>
        [DataProperty(order: 0)]
        public IdFiscaleIVA IdFiscaleIVA { get; set; }

        /// <summary>
        /// Gets or sets the Denominazione.
        /// </summary>
        [DataProperty(order: 1)]
        public string Denominazione { get; set; }

        /// <summary>
        /// Gets or sets the Nome.
        /// </summary>
        [DataProperty(order: 2)]
        public string Nome { get; set; }

        /// <summary>
        /// Gets or sets the Cognome.
        /// </summary>
        [DataProperty(order: 3)]
        public string Cognome { get; set; }
    }
}
