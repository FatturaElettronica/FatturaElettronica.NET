using System.Xml;
using FatturaElettronica.BusinessObjects;

namespace FatturaElettronica.FatturaElettronicaHeader.CessionarioCommittente
{
    public class DatiAnagraficiCessionarioCommittente : Common.DatiAnagrafici
    {
        /// <summary>
        /// Dati anagrafici, professionali e fiscali del cessionario / committente.
        /// </summary>
        public DatiAnagraficiCessionarioCommittente()
        {
            XmlOptions.ElementName = "DatiAnagrafici";
        }
        public DatiAnagraficiCessionarioCommittente(XmlReader r) : base(r) { }
    }
}
