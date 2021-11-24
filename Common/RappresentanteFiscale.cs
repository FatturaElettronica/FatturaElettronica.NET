using System.Xml;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Dati relativi al rappresentante fiscale del cedente / prestatore.
    /// </summary>
    public abstract class RappresentanteFiscale : Core.BaseClassSerializable
    {

        /// <summary>
        /// Dati relativi al rappresentante fiscale del cedente / prestatore.
        /// </summary>
        public RappresentanteFiscale()
        {
            DatiAnagrafici = new();
        }
        public RappresentanteFiscale(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati anagrafici del rappresentante fiscale del cedente / prestatore.
        /// </summary>
        [Core.DataProperty]
        public DatiAnagrafici DatiAnagrafici { get; set; }
    }
}
