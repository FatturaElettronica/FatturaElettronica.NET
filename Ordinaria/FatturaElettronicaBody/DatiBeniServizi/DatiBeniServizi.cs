using System.Collections.Generic;
using System.Xml;
using FatturaElettronica.Common;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi
{

    /// <summary>
    /// Blocco sempre obbligatorio contenente natura, qualità e quantità dei beni / servizi formanti oggetto dell'operazione.
    /// </summary>
    public class DatiBeniServizi : BaseClassSerializable
    {
        /// <summary>
        /// Blocco sempre obbligatorio contenente natura, qualità e quantità dei beni / servizi formanti oggetto dell'operazione.
        /// </summary>
        public DatiBeniServizi()
        {
            DettaglioLinee = new();
            DatiRiepilogo = new();
        }
        public DatiBeniServizi(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati generali del documento principale.
        /// </summary>
        [Core.DataProperty]
        public List<DettaglioLinee> DettaglioLinee { get; set; }

        /// <summary>
        /// Blocco sempre obbligatorio contenente i dati di riepilogo per ogni aliquota IVA o natura.
        /// </summary>
        [Core.DataProperty]
        public List<DatiRiepilogo> DatiRiepilogo { get; set; }
    }
}
