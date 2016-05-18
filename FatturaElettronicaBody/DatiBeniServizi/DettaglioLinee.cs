using System;
using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiBeniServizi
{
    /// <summary>
    /// Linee di dettaglio del documento (i campi del blocco si ripetono per ogni riga di dettaglio).
    /// </summary>
    public class DettaglioLinee : Common.BusinessObject
    {
        private readonly List<CodiceArticolo> _codiceArticolo;
        private readonly List<Common.ScontoMaggiorazione> _scontoMaggiorazione;
        private readonly List<AltriDatiGestionali> _altriDatiGestionali;

        /// <summary>
        /// Linee di dettaglio del documento (i campi del blocco si ripetono per ogni riga di dettaglio).
        /// </summary>
        public DettaglioLinee() {
            _codiceArticolo = new List<CodiceArticolo>();
            _scontoMaggiorazione = new List<Common.ScontoMaggiorazione>();
            _altriDatiGestionali = new List<AltriDatiGestionali>();
        }

        public DettaglioLinee(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FRequiredValidator("NumeroLinea"));
            rules.Add(new FTipoCessionePrestazioneValidator("TipoCessionePrestazione"));
            rules.Add(new AndCompositeValidator("Descrizione", new List<Validator> {new FRequiredValidator(), new FLengthValidator(1, 1000)}));
            rules.Add(new FLengthValidator("UnitaMisura", 1, 10));
            rules.Add(new FRequiredValidator("PrezzoUnitario"));
            rules.Add(new FRequiredValidator("PrezzoTotale"));
            rules.Add(new FRequiredValidator("AliquotaIVA"));
            rules.Add(new FSiValidator("Ritenuta"));
            rules.Add(new FNaturaValidator("Natura"));
            rules.Add(new FLengthValidator("RiferimentoAmministrazione", 1, 20));
            rules.Add(new FPrezzoTotaleValidator("PrezzoTotale", "00423: il valore del campo PrezzoTotale non risulta calcolato secondo le regole definite nelle specifiche tecniche", ValidateAgainstErr00423));
            return rules;
        }
		/// <summary>
        /// Validate error 00423 from FatturaElettronicaPA v1.3
        /// </summary>
        /// <returns></returns>
		public bool ValidateAgainstErr00423()
        {
            decimal sconti = 0;
			decimal maggiorazioni = 0;
			foreach (var sconto in ScontoMaggiorazione) {

                if (sconto.Importo == null && sconto.Percentuale == null) continue;

                var importo = (decimal)((sconto.Percentuale == null) ? sconto.Importo : (PrezzoUnitario * sconto.Percentuale) / 100);

                if (sconto.Tipo == "SC")
                    sconti += importo;
                else
                    maggiorazioni += importo;

            }
            return (PrezzoTotale == (PrezzoUnitario - sconti + maggiorazioni) * Quantita);
        }

        #region Properties
        /// <summary>
        /// Numero della riga di dettaglio del documento.
        /// </summary>
        [DataProperty]
        public int NumeroLinea { get; set; }

        /// <summary>
        /// Da valorizzare nei soli casi di sconto, premio, abbuono, spesa accessoria.
        /// </summary>
        [DataProperty]
        public string TipoCessionePrestazione { get; set; }

        /// <summary>
        /// Eventuale codifica dell'articolo (la molteplicità N del blocco consente di gestire la presenza di più codifiche).
        /// </summary>
        [DataProperty]
        public List<CodiceArticolo> CodiceArticolo { get { return _codiceArticolo; } }

        /// <summary>
        /// Natura e quantità dell'oggetto della cessione/prestazione; può fare anche riferimento ad un precedente documento emesso
        /// a titolo di anticipo/acconto, nel qual caso il valore del campo PrezzoUnitario e PrezzoTotale sarà negativo.
        /// </summary>
        [DataProperty]
        public string Descrizione { get; set; }

        /// <summary>
        /// Numero di unità cedute / prestate.
        /// </summary>
        [DataProperty]
        public decimal? Quantita { get; set; }

        /// <summary>
        /// Unità di misura riferita alla quantità.
        /// </summary>
        [DataProperty]
        public string UnitaMisura { get; set; }

        /// <summary>
        /// Data iniziale del periodo di riferimento cui si riferisce l'eventuale servizio prestato.
        /// </summary>
        [DataProperty]
        public DateTime? DataInizioPeriodo { get; set; }

        /// <summary>
        /// Data finale del periodo di riferimento cui si riferisce l'eventuale servizio prestato.
        /// </summary>
        [DataProperty]
        public DateTime? DataFinePeriodo { get; set; }

        /// <summary>
        /// Prezzo unitario del bene/servizio; nel caso di beni ceduti a titolo di sconto, premio o abbuono, l'importo indicato rappresenta il "valore normale".
        /// </summary>
        [DataProperty]
        public decimal PrezzoUnitario { get; set; }

        /// <summary>
        /// Eventuale sconto o maggiorazione applicati (la molteciplità N del blocco consente di gestire la presenza di più sconti o 
        /// maggiorazioni a "cascata").
        /// </summary>
        [DataProperty]
        public List<Common.ScontoMaggiorazione> ScontoMaggiorazione { get { return _scontoMaggiorazione; } }

        /// <summary>
        /// Importo totale del bene/servizio (che tiene conto di eventuali sconti/maggiorazioni) IVA esclusa.
        /// </summary>
        [DataProperty]
        public decimal PrezzoTotale { get; set; }

        /// <summary>
        /// Aliquota (%) IVA applicata al bene/servizio.
        /// </summary>
        [DataProperty]
        public decimal AliquotaIVA { get; set; }

        /// <summary>
        /// Da valorizzare solo in caso di cessione/prestazione soggetta a ritenuta di acconto.
        /// </summary>
        [DataProperty]
        public string Ritenuta { get; set; }

        /// <summary>
        /// Natura dell'operazione se non rientra tra quelle imponibili (il campo Aliquota IVA deve essere valorizzato a zero).
        /// </summary>
        [DataProperty]
        public string Natura { get; set; }

        /// <summary>
        /// Codice identificativo ai fini amministrativo-contabili.
        /// </summary>
        [DataProperty]
        public string RiferimentoAmministrazione { get; set; }

        /// <summary>
        /// Blocco che consente di inserire, con riferimento ad una linea di dettaglio, diverse tipologie di informazioni utili ai 
        /// fini amministrativi, gestionali, etc.
        /// </summary>
        [DataProperty]
        public List<AltriDatiGestionali> AltriDatiGestionali { get { return _altriDatiGestionali; } }
        #endregion
    }
}
