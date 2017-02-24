using System.Collections.Generic;
using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.FatturaElettronicaBody.DatiPagamento
{
    /// <summary>
    /// Dati relativi al pagamento.
    /// </summary>
    public class DatiPagamento : BaseClassSerializable
    {
        private readonly List<DettaglioPagamento> _dettagliPagamento;

        /// <summary>
        /// Dati relativi al pagamento.
        /// </summary>
        public DatiPagamento() {
            _dettagliPagamento = new List<DettaglioPagamento>();
        }

        public DatiPagamento(XmlReader r) : base(r) { }

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
    }
}
