using System;
using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiBeniServizi
{
    /// <summary>
    /// Blocco che consente di inserire, con riferimento ad una linea di dettaglio, diverse tipologie di informazioni utili ai fini
    /// amministrativi, gestionali, etc.
    /// </summary>
    public class AltriDatiGestionali : Common.BusinessObject
    {

        public AltriDatiGestionali() { }
        public AltriDatiGestionali(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add( new AndCompositeValidator("TipoDato", new List<Validator> {new FRequiredValidator(), new FLengthValidator(1, 10)}));
            rules.Add(new FLengthValidator("RiferimentoTesto", 1, 35));
            return rules;
        }

        #region Properties
        /// <summary>
        /// Codice che identifica la tipologia di informazione
        /// </summary>
        [DataProperty]
        public string TipoDato { get; set; }

        /// <summary>
        /// Campo in cui inserire un valore alfanumerico riferito alla tipologia di informazione.
        /// </summary>
        [DataProperty]
        public string RiferimentoTesto { get; set; }

        /// <summary>
        /// Campo in cui inserire un valore numerico riferito alla tipologia di informazione.
        /// </summary>
        [DataProperty]
        public decimal RiferimentoNumero { get; set; }

        /// <summary>
        /// Campo in cui inserire una data riferita alla tiplogia di informazione.
        /// </summary>
        [DataProperty]
        public DateTime RiferimentoData { get; set; }
        #endregion
    }
}
