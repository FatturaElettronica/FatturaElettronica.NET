using System.Xml;

namespace FatturaElettronica.FatturaElettronicaHeader.CessionarioCommittente
{
    public class Sede : Common.Località
    {
        public Sede() { } 
        public Sede(XmlReader r) : base(r) { } 
    }
}
