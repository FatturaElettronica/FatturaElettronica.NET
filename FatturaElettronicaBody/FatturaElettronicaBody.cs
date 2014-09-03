using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody
{
    public class FatturaElettronicaBody : Common.BusinessObject
    {
        private readonly DatiGenerali.DatiGenerali _datiGenerali;
        private readonly DatiBeniServizi.DatiBeniServizi _datiBeniServizi;
        private readonly DatiVeicoli.DatiVeicoli _datiVeicoli;
        private readonly List<DatiPagamento.DatiPagamento> _datiPagamento;
        private readonly List<Allegati.Allegati> _allegati;

        /// <summary>
        /// Fattura inclusa nella conunicazione.
        /// </summary>
        public FatturaElettronicaBody() {
            _datiGenerali = new DatiGenerali.DatiGenerali();
            _datiBeniServizi = new DatiBeniServizi.DatiBeniServizi();
            _datiVeicoli = new DatiVeicoli.DatiVeicoli();
            _datiPagamento = new List<DatiPagamento.DatiPagamento>();
            _allegati = new List<Allegati.Allegati>();
        }
        public FatturaElettronicaBody(XmlReader r) : base(r) { } 

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FRequiredValidator("DatiGenerali"));
            rules.Add(new FRequiredValidator("DatiBeniServizi"));
            return rules;
        }

        #region Properties 
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
        #endregion
    }
}
