namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody
{
    using System.Collections.Generic;
    using System.Xml;
    using FatturaElettronica.Common;

    public class FatturaElettronicaBody : BaseClassSerializable
    {
        /// <summary>
        /// FatturaOrdinaria inclusa nella conunicazione.
        /// </summary>
        public FatturaElettronicaBody()
        {
            DatiGenerali = new DatiGenerali.DatiGenerali();
            DatiBeniServizi = new DatiBeniServizi.DatiBeniServizi();
            DatiVeicoli = new DatiVeicoli.DatiVeicoli();
            DatiPagamento = new List<DatiPagamento.DatiPagamento>();
            Allegati = new List<Allegati.Allegati>();
        }
        public FatturaElettronicaBody(XmlReader r) : base(r) { }

        /// <summary>
        /// Dati generali del documento principale.
        /// </summary>
        [DataProperty]
        public DatiGenerali.DatiGenerali DatiGenerali { get; set; }

        /// <summary>
        /// Blocco sempre obbligatorio contenente natura qualità e quantità dei beni/servizi oggetto dell'operazione.
        /// </summary>
        [DataProperty]
        public DatiBeniServizi.DatiBeniServizi DatiBeniServizi { get; set; }

        /// <summary>
        /// Dati relativi ai veicoli di cui all'art. 38 del dl 331 del 1993.
        /// </summary>
        [DataProperty]
        public DatiVeicoli.DatiVeicoli DatiVeicoli { get; set; }

        /// <summary>
        /// Dati relativi al pagamento.
        /// </summary>
        [DataProperty]
        public List<DatiPagamento.DatiPagamento> DatiPagamento { get; set; }

        /// <summary>
        /// Dati relativi ad eventuali allegati.
        /// </summary>
        [DataProperty]
        public List<Allegati.Allegati> Allegati { get; set; }
    }
}
