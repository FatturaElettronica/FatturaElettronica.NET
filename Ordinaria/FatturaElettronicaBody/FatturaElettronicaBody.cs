using System.Collections.Generic;
using System.Xml;
using FatturaElettronica.Common;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody
{
    public class FatturaElettronicaBody : BaseClassSerializable
    {
        /// <summary>
        /// FatturaOrdinaria inclusa nella conunicazione.
        /// </summary>
        public FatturaElettronicaBody()
        {
            DatiGenerali = new();
            DatiBeniServizi = new();
            DatiVeicoli = new();
            DatiPagamento = new();
            Allegati = new();
        }
        public FatturaElettronicaBody(XmlReader r) : base(r) { }

        /// <summary>
        /// Dati generali del documento principale.
        /// </summary>
        [Core.DataProperty]
        public DatiGenerali.DatiGenerali DatiGenerali { get; set; }

        /// <summary>
        /// Blocco sempre obbligatorio contenente natura qualità e quantità dei beni/servizi oggetto dell'operazione.
        /// </summary>
        [Core.DataProperty]
        public DatiBeniServizi.DatiBeniServizi DatiBeniServizi { get; set; }

        /// <summary>
        /// Dati relativi ai veicoli di cui all'art. 38 del dl 331 del 1993.
        /// </summary>
        [Core.DataProperty]
        public DatiVeicoli.DatiVeicoli DatiVeicoli { get; set; }

        /// <summary>
        /// Dati relativi al pagamento.
        /// </summary>
        [Core.DataProperty]
        public List<DatiPagamento.DatiPagamento> DatiPagamento { get; set; }

        /// <summary>
        /// Dati relativi ad eventuali allegati.
        /// </summary>
        [Core.DataProperty]
        public List<Allegati> Allegati { get; set; }
    }
}
