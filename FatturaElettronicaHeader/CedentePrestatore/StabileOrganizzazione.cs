using System.Xml;

namespace FatturaElettronicaPA.FatturaElettronicaHeader.CedentePrestatore
{
    public class StabileOrganizzazione : Common.Località
    {
        public StabileOrganizzazione() { } 
        public StabileOrganizzazione(XmlReader r) : base(r) { } 
    }
}
