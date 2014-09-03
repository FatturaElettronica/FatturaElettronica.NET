using System.Xml;

namespace FatturaElettronicaPA.FatturaElettronicaHeader.CessionarioCommittente
{
    public class Sede : Common.Località
    {
        public Sede() { } 
        public Sede(XmlReader r) : base(r) { } 
    }
}
