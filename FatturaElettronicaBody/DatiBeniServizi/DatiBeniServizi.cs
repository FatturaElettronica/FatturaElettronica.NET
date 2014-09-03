using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiBeniServizi
{

    /// <summary>
    /// Blocco sempre obbligatorio contenente natura, qualità e quantità dei beni / servizi formanti oggetto dell'operazione.
    /// </summary>
    public class DatiBeniServizi : Common.BusinessObject
    {
        private readonly List<DettaglioLinee> _dettaglioLinee;
        private readonly List<DatiRiepilogo> _datiRiepilogo;

        /// <summary>
        /// Blocco sempre obbligatorio contenente natura, qualità e quantità dei beni / servizi formanti oggetto dell'operazione.
        /// </summary>
        public DatiBeniServizi() {
            _dettaglioLinee = new List<DettaglioLinee>();
            _datiRiepilogo = new List<DatiRiepilogo>();
        }
        public DatiBeniServizi(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FRequiredValidator("DettaglioLinee"));
            rules.Add(new FRequiredValidator("DatiRiepilogo"));
            return rules;
        }

        #region Properties 

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati generali del documento principale.
        /// </summary>
        [DataProperty]
        public List<DettaglioLinee> DettaglioLinee { get { return _dettaglioLinee; } }

        /// <summary>
        /// Blocco sempre obbligatorio contenente i dati di riepilogo per ogni aliquota IVA o natura.
        /// </summary>
        [DataProperty]
        public List<DatiRiepilogo> DatiRiepilogo { get { return _datiRiepilogo; } }
        #endregion
        }
}
