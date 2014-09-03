using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiPagamento
{
    /// <summary>
    /// Dati relativi al pagamento.
    /// </summary>
    public class DatiPagamento : Common.BusinessObject
    {
        private readonly List<DettaglioPagamento> _dettagliPagamento;

        /// <summary>
        /// Dati relativi al pagamento.
        /// </summary>
        public DatiPagamento() {
            _dettagliPagamento = new List<DettaglioPagamento>();
        }

        public DatiPagamento(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new AndCompositeValidator("CondizioniPagamento",
                new List<Validator> {new FRequiredValidator(), new FCondizioniPagamentoValidator()}));
            rules.Add(new FRequiredValidator("DettaglioPagamento"));
            return rules;
        }

        #region Properties
        /// <summary>
        /// Condizioni di pagamento.
        /// </summary>
        [DataProperty]
        public string CondizioniPagamento { get; set; }

        /// <summary>
        /// Dati di dettaglio del pagamento.
        /// </summary>
        [DataProperty]
        public List<DettaglioPagamento> DettaglioPagamento { get { return _dettagliPagamento; }}
        #endregion
    }
}
