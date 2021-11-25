using System.Xml;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi
{
    /// <summary>
    /// Dati relativi all'imposta sul valore aggiunto.
    /// </summary>
    public class DatiIVA : BaseClassSerializable
    {
        /// <summary>
        /// Dati relativi all'imposta sul valore aggiunto.
        /// </summary>
        public DatiIVA() { }
        public DatiIVA(XmlReader r) : base(r) { }

        /// <summary>
        /// Ammontare dell'imposta. Si può indicare in alternativa all'elemento informativo 2,2,3,2
        /// </summary>
        [Core.DataProperty]
        public decimal? Imposta { get; set; }

        /// <summary>
        /// Aliquota (%) IVA applicata. Si può indicare in alternativa all'elemento informativo 2,2,3,1
        /// </summary>
        [Core.DataProperty]
        public decimal? Aliquota { get; set; }
    }
}
