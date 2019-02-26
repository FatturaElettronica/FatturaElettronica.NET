namespace FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente
{
    using System.Xml;

    public class SedeCessionarioCommittente : Common.Località
    {
        public SedeCessionarioCommittente() { } 

        public SedeCessionarioCommittente(XmlReader r) : base(r) { } 
    }
}
