using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Dati relativi al bollo.
    /// </summary>
    public class DatiBollo : BaseClassSerializable
    {
        public DatiBollo() { }
        public DatiBollo(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Bollo virtuale.
        /// </summary>
        [DataProperty]
        public string BolloVirtuale { get; set; }
        

        /// <summary>
        /// Importo del bollo.
        /// </summary>
        [DataProperty]
        public decimal? ImportoBollo { get; set; }
    }
}
