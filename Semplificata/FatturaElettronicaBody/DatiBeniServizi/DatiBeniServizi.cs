namespace FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi
{
    using System.Xml;
    using FatturaElettronica.Common;

    /// <summary>
    /// Blocco sempre obbligatorio contenente natura, qualità e quantità dei beni / servizi formanti oggetto dell'operazione.
    /// </summary>
    public class DatiBeniServizi : BaseClassSerializable
    {
        /// <summary>
        /// Blocco sempre obbligatorio contenente natura, qualità e quantità dei beni / servizi formanti oggetto dell'operazione.
        /// </summary>
        public DatiBeniServizi()
        {
            DatiIVA = new DatiIVA();
        }
        public DatiBeniServizi(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Natura e quantità dell'oggetto della cessione/prestazione
        /// </summary>
        [DataProperty]
        public string Descrizione { get; set; }

        /// <summary>
        /// Ammontare complessivo (comprensivo di imposta).
        /// </summary>
        [DataProperty]
        public decimal Importo { get; set; }

        /// <summary>
        /// Dati relativi all'imposta sul valore aggiunto.
        /// </summary>
        [DataProperty]
        public DatiIVA DatiIVA { get; set; }

        /// <summary>
        /// L'elemento serve per indicare il motivo (Natura dell'operazione) per il quale l'emittente della fattura non indica aliquota IVA.
        /// </summary>
        [DataProperty]
        public string Natura { get; set; }

        /// <summary>
        /// Norma di riferimento.
        /// </summary>
        [DataProperty]
        public string RiferimentoNormativo { get; set; }
    }
}
