using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Dati relativi alla ritenuta.
    /// </summary>
    public class DatiRitenuta : Common.BusinessObject
    {
        public DatiRitenuta() { }
        public DatiRitenuta(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new AndCompositeValidator("TipoRitenuta", new List<Validator>{new FRequiredValidator(), new FTipoRitenutaValidator()}));
            rules.Add(new FRequiredValidator("ImportoRitenuta"));
            rules.Add(new FRequiredValidator("AliquotaRitenuta"));
            rules.Add(new FSiValidator());
            rules.Add(new AndCompositeValidator("CausalePagamento", new List<Validator>{new FRequiredValidator(), new FCausalePagamentoValidator()}));
            return rules;
        }

        #region Properties

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Tipologia della ritenuta.
        /// </summary>
        [DataProperty]
        public string TipoRitenuta { get; set; }
        
        /// <summary>
        /// Importo dellla ritenuta.
        /// </summary>
        [DataProperty]
        public decimal? ImportoRitenuta { get; set; }
        
        /// <summary>
        /// Aliquota (%) della ritenuta.
        /// </summary>
        [DataProperty]
        public decimal? AliquotaRitenuta { get; set; }
        
        /// <summary>
        /// Causale del pagamento (quella del modello 770).
        /// </summary>
        [DataProperty]
        public string CausalePagamento { get; set; }
        #endregion
    }
}
