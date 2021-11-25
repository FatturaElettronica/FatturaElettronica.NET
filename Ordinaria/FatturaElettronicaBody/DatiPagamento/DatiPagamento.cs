using System.Collections.Generic;
using System.Xml;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiPagamento
{
    /// <summary>
    /// Dati relativi al pagamento.
    /// </summary>
    public class DatiPagamento : BaseClassSerializable
    {
        /// <summary>
        /// Dati relativi al pagamento.
        /// </summary>
        public DatiPagamento()
        {
            DettaglioPagamento = new();
        }

        public DatiPagamento(XmlReader r) : base(r) { }

        /// <summary>
        /// Condizioni di pagamento.
        /// </summary>
        [Core.DataProperty]
        public string CondizioniPagamento { get; set; }

        /// <summary>
        /// Dati di dettaglio del pagamento.
        /// </summary>
        [Core.DataProperty]
        public List<DettaglioPagamento> DettaglioPagamento { get; set; }
    }
}
