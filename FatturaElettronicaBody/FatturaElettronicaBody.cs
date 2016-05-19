using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            rules.Add(new DelegateValidator("DatiBeniServizi.DatiRiepilogo", "00419: è presente nel documento un’aliquota IVA per la quale non esiste il relativo blocco DatiRiepilogo.", ValidateAgainstErr00419));
            rules.Add(new DelegateValidator("DatiBeniServizi.DatiRiepilogo.ImponibileImporto", "00422:  il valore del campo ImponibileImporto non risulta calcolato secondo le regole definite nelle specifiche tecniche.", ValidateAgainstErr00422));
            return rules;
        }

        /// <summary>
        /// Validate error 00423 from FatturaElettronicaPA v1.3
        /// </summary>
        /// <returns></returns>
        private bool ValidateAgainstErr00419()
        {
            var hash = new HashSet<decimal>();
            foreach (var cp in DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale)
            {
                if (!hash.Contains(cp.AliquotaIVA)) hash.Add(cp.AliquotaIVA);
            }
            foreach (var l in DatiBeniServizi.DettaglioLinee)
            {
                if (!hash.Contains(l.AliquotaIVA)) hash.Add(l.AliquotaIVA);
            }
            return DatiBeniServizi.DatiRiepilogo.Count >= hash.Count;
        }

        /// <summary>
        /// Validate error 00422 from FatturaElettronicaPA v1.3
        /// </summary>
        /// <returns></returns>
        private bool ValidateAgainstErr00422()
        {
            var totals = new Dictionary<decimal, Totals>();

            foreach (var r in DatiBeniServizi.DatiRiepilogo)
            {
                if (!totals.ContainsKey(r.AliquotaIVA))
                    totals.Add(r.AliquotaIVA, new Totals());

                totals[r.AliquotaIVA].ImponibileImporto += r.ImponibileImporto;
                totals[r.AliquotaIVA].Arrotondamento += (decimal)((r.Arrotondamento != null) ? r.Arrotondamento : 0);
            }
            foreach (var l in DatiBeniServizi.DettaglioLinee)
            {
                if (!totals.ContainsKey(l.AliquotaIVA))
                    totals.Add(l.AliquotaIVA, new Totals());

                totals[l.AliquotaIVA].PrezzoTotale += l.PrezzoTotale;
            }
            foreach (var c in DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale)
            {
                if (!totals.ContainsKey(c.AliquotaIVA))
                    totals.Add(c.AliquotaIVA, new Totals());

                totals[c.AliquotaIVA].ImportoContrCassa += c.ImportoContributoCassa;
            }

			foreach (var t in totals.Values)
            {
                if (t.ImponibileImporto != t.PrezzoTotale + t.ImportoContrCassa + t.Arrotondamento) return false;
            }
            return true;
        }

        internal class Totals
        {
            public decimal ImponibileImporto;
            public decimal PrezzoTotale;
            public decimal Arrotondamento;
            public decimal ImportoContrCassa;
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
