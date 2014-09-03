using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.Common
{
    /// <summary>
    /// Numero di identificazione fiscale ai fini IVA; i primi due caratteri rappresentano il paese ed i restanti il codice
    /// vero e proprio che, per i residenti in Italia, corrisponde al numero di partita IVA.
    /// </summary>
    public class IdFiscaleIVA : BusinessObject
    {
        private string _idPaese;
        private string _idCodice;

        public IdFiscaleIVA() { }
        public IdFiscaleIVA(XmlReader r) : base(r) { }

        /// <summary>
        /// Codice della nazione espresso secondo lo standard ISO 3166-1 alpha-2 code.
        /// </summary>
        [DataProperty]
        public string IdPaese {
            get { return _idPaese; }
            set {
                _idPaese = CleanString(value);
                NotifyChanged();
            }
        }

        /// <summary>
        /// Codice identificativo fiscale.
        /// </summary>
        [DataProperty]
        public string IdCodice {
            get { return _idCodice; }
            set {
                _idCodice = CleanString(value);
                NotifyChanged();
            }
        }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            // IdPaese
            rules.Add(
                new AndCompositeValidator(
                    "IdPaese", 
                    new List<Validator> { new FRequiredValidator(), new FCountryValidator() }));
            rules.Add(
                new AndCompositeValidator( 
                    "IdCodice", 
                    new List<Validator> { new FRequiredValidator(), new FLengthValidator(1, 28) }));
            return rules;
        }
    }
}
