using System.Xml;

namespace FatturaElettronica.FatturaElettronicaHeader.CessionarioCommittente
{
    public class SedeCessionarioCommittente : Common.Località
    {
        public SedeCessionarioCommittente()
        {
            XmlOptions.ElementName = "Sede";
        } 

        public SedeCessionarioCommittente(XmlReader r) : base(r) { } 
    }
}
