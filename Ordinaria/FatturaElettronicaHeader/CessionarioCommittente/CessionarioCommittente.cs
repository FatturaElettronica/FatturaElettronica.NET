using System.Xml;
using FatturaElettronica.Common;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CessionarioCommittente
{

    /// <summary>
    /// Dati relativi al cessionario/ committente.
    /// </summary>
    public class CessionarioCommittente : BaseClassSerializable
    {
        /// <summary>
        /// Dati relativi al cessionario / committente.
        /// </summary>
        public CessionarioCommittente()
        {
            DatiAnagrafici = new DatiAnagraficiCessionarioCommittente();
            Sede = new SedeCessionarioCommittente();
            StabileOrganizzazione = new StabileOrganizzazione();
            RappresentanteFiscale = new RappresentanteFiscaleCessionarioCommittente();
        }
        public CessionarioCommittente(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati anagrafici, professionali e fiscali del cessionario / committente.
        /// </summary>
        [Core.DataProperty]
        public DatiAnagraficiCessionarioCommittente DatiAnagrafici { get; set; }

        /// <summary>
        /// Dati della sede del cessionario / committente.
        /// </summary>
        [Core.DataProperty]
        public SedeCessionarioCommittente Sede { get; set; }

        /// <summary>
        /// Blocco da valorizzare se e solo se l'elemento informativo 1.1.3 FormatoTrasmissione = "FPR12" (fattura tra privati), nel caso di cessionario/committente non residente e con stabile organizzazione in Italia.
        /// </summary>
        [Core.DataProperty]
        public StabileOrganizzazione StabileOrganizzazione { get; set; }

        /// <summary>
        /// Blocco da valorizzare se e solo se l'elemento informativo 1.1.3 FormatoTrasmissione = "FPR12" (fattura tra privati), nel caso di cessionario/committente che si avvale di rappresentante fiscale in Italia.
        /// </summary>
        [Core.DataProperty]
        public RappresentanteFiscaleCessionarioCommittente RappresentanteFiscale { get; set; }
    }
}
