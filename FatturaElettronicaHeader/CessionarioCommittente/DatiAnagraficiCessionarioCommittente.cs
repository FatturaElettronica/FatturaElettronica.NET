using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.FatturaElettronicaHeader.CessionarioCommittente
{
    public class DatiAnagraficiCessionarioCommittente : DatiAnagrafici
    {
        /// <summary>
        /// Dati anagrafici, professionali e fiscali del cessionario / committente.
        /// </summary>
        public DatiAnagraficiCessionarioCommittente() { }
        public DatiAnagraficiCessionarioCommittente(XmlReader r) : base(r) { }
    }
}
