using System.Xml;

namespace FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente
{
    public class SedeCessionarioCommittente : Common.Località
    {
        public SedeCessionarioCommittente() { } 

        public SedeCessionarioCommittente(XmlReader r) : base(r) { } 
    }
}
