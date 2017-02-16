using System.Xml;

namespace FatturaElettronica.Common
{
    public class StabileOrganizzazione : Località
    {
        public StabileOrganizzazione() { } 
        public StabileOrganizzazione(XmlReader r) : base(r) { } 
    }
}
