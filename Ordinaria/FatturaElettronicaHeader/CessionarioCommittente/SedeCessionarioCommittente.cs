using System.Xml;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CessionarioCommittente
{
    public class SedeCessionarioCommittente : Common.Località
    {
        public SedeCessionarioCommittente() { } 

        public SedeCessionarioCommittente(XmlReader r) : base(r) { } 
    }
}
