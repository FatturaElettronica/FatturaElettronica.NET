using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronica.Validators;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Represents a DatiAnagrafici object
    /// </summary>
    public class DatiAnagrafici : BusinessObject
    {
        private readonly IdFiscaleIVA _idFiscaleIva;
        private readonly Anagrafica _anagrafica;

        /// <summary>
        /// Dati anagrafici, professionali e fiscali
        /// </summary>
        public DatiAnagrafici() {
            _idFiscaleIva = new IdFiscaleIVA();
            _anagrafica = new Anagrafica();
        }
        public DatiAnagrafici(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FLengthValidator("CodiceFiscale", 11,16));
            rules.Add(new FRequiredValidator("Anagrafica"));
            return rules;
        }

        # region Properties 
        /// <summary>
        /// Numero di identificazione fiscale ai fini IVA; i primi due caratteri rappresentano il paese ed i restanti il codice
        /// vero e proprio che, per i residenti in Italia, corrisponde al numero di partita IVA.
        /// </summary>
        [DataProperty(order:0)]
        public IdFiscaleIVA IdFiscaleIVA { 
            get { return _idFiscaleIva; }
        }

        /// <summary>
        /// Numero di Codice Fiscale.
        /// </summary>
        [DataProperty(order:1)]
        public string CodiceFiscale { get; set; }

        /// <summary>
        /// Dati anagrafici identificativi del soggetto. 
        /// </summary>
        [DataProperty(order:2)]
        public Anagrafica Anagrafica { 
            get { return _anagrafica; }
        }

        # endregion

    }
}
