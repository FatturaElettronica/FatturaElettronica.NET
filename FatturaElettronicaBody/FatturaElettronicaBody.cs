using System.Collections.Generic;
using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.FatturaElettronicaBody
{
    public class Body : BaseClassSerializable
    {
        private readonly DatiGenerali.DatiGenerali _datiGenerali;
        private readonly DatiBeniServizi.DatiBeniServizi _datiBeniServizi;
        private readonly DatiVeicoli.DatiVeicoli _datiVeicoli;
        private readonly List<DatiPagamento.DatiPagamento> _datiPagamento;
        private readonly List<Allegati.Allegati> _allegati;

        /// <summary>
        /// Fattura inclusa nella conunicazione.
        /// </summary>
        public Body() {
            _datiGenerali = new DatiGenerali.DatiGenerali();
            _datiBeniServizi = new DatiBeniServizi.DatiBeniServizi();
            _datiVeicoli = new DatiVeicoli.DatiVeicoli();
            _datiPagamento = new List<DatiPagamento.DatiPagamento>();
            _allegati = new List<Allegati.Allegati>();
        }
        public Body(XmlReader r) : base(r) { }

        /// <summary>
        /// Dati generali del documento principale.
        /// </summary>
        [DataProperty]
        public DatiGenerali.DatiGenerali DatiGenerali { get { return _datiGenerali; } }

        /// <summary>
        /// Blocco semre obbligatorio contenente natura qualità e quantità dei beni/servizi oggetto dell'operazione.
        /// </summary>
        [DataProperty]
        public DatiBeniServizi.DatiBeniServizi DatiBeniServizi { get { return _datiBeniServizi; } }

        /// <summary>
        /// Dati relativi ai veicoli di cui all'art. 38 del dl 331 del 1993.
        /// </summary>
        [DataProperty]
        public DatiVeicoli.DatiVeicoli DatiVeicoli { get { return _datiVeicoli; } }

        /// <summary>
        /// Dati relativi al pagamento.
        /// </summary>
        [DataProperty]
        public List<DatiPagamento.DatiPagamento> DatiPagamento { get { return _datiPagamento; } }

        /// <summary>
        /// Dati relativi ad eventuali allegati.
        /// </summary>
        [DataProperty]
        public List<Allegati.Allegati> Allegati { get { return _allegati; } }
    }
}
