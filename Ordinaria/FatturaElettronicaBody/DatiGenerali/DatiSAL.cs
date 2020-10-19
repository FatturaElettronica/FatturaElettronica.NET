using System.Xml;
using FatturaElettronica.Common;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Da valorizzare nei casi di fattura per stato di avanzamento.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class DatiSAL : BaseClassSerializable
    {
        public DatiSAL() { }
        public DatiSAL(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.
        
        /// <summary>
        /// Fase dello stato di avanzamento cui il documento si riferisce.
        /// </summary>
        [Core.DataProperty]
        public int RiferimentoFase { get; set; }
    }
}
