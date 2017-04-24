using System;
using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronica.Validators;

namespace FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore
{
    public class CedentePrestatoreDatiAnagrafici : Common.DatiAnagrafici
    {
        /// <summary>
        /// Dati anagrafici, professionali e fiscali del cedente / prestatore.
        /// </summary>
        public CedentePrestatoreDatiAnagrafici() { }
        public CedentePrestatoreDatiAnagrafici(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules()
        {
            XmlOptions.ElementName = "DatiAnagrafici";

            var rules = base.CreateRules();
            rules.Add(new FRequiredValidator("IdFiscaleIVA"));
            rules.Add(new FLengthValidator("AlboProfessionale", 1, 60));
            rules.Add(new FProvinciaValidator("ProvinciaAlbo"));
            rules.Add(new FLengthValidator("NumeroIscrizioneAlbo", 1, 60));
            rules.Add(new AndCompositeValidator("RegimeFiscale",
                new List<Validator>
                {
                    new FRequiredValidator(),
                    new FRegimeFiscaleValidator()
                }));
            return rules;
        }

        #region Properties 
        /// <summary>
        /// Nome dell'albo professionale.
        /// </summary>
        [DataProperty (order:10)]
        public string AlboProfessionale { get; set; }

        /// <summary>
        /// Sigla della provincia di competenza dell'albo professionale.
        /// </summary>
        [DataProperty (order:11)]
        public string ProvinciaAlbo { get; set; }

        /// <summary>
        /// Numero di iscrizione all'albo professionale.
        /// </summary>
        [DataProperty (order:12)]
        public string NumeroIscrizioneAlbo { get; set; }

        /// <summary>
        /// Data di iscrizione all'albo professionale. 
        /// </summary>
        [DataProperty (order:13)]
        public DateTime? DataIscrizioneAlbo { get; set; }

        /// <summary>
        /// Regime fiscale.
        /// </summary>
        [DataProperty (order:14)]
        public string RegimeFiscale { get; set; }
        #endregion
    }
}
