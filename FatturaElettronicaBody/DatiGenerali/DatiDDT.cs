using System;
using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronica.Validators;

namespace FatturaElettronica.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Nei casi di fattura differita per indicare il documento con cui è stato consegnato il bene.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class DatiDDT : Common.BusinessObject
    {

        private readonly List<int> _riferimentoNumeroLinea;

        /// <summary>
        /// Nei casi di fattura differita per indicare il documento con cui è stato consegnato il bene.
        /// </summary>
        public DatiDDT() {
            _riferimentoNumeroLinea = new List<int>();
        }


        public DatiDDT(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new AndCompositeValidator("NumeroDDT", new List<Validator>{new FRequiredValidator(), new FLengthValidator(1,20)}));
            rules.Add(new FRequiredValidator("DataDDT"));
            return rules;
        }

        #region Properties

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.
        
        /// <summary>
        /// Numero del documento di trasporto.
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public string NumeroDDT { get; set; }

        /// <summary>
        /// Data del documento di trasporto.
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public DateTime DataDDT { get; set; }

        /// <summary>
        /// Linea di dettaglio della fattura cui si riferisce il DDT (non viene valorizzato se il riferimento è all'intera fattura).
        /// </summary>
        [DataProperty]
        public List<int> RiferimentoNumeroLinea { get { return _riferimentoNumeroLinea; }}
        #endregion
    }
}
