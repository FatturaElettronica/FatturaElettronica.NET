using System.Xml;
using FatturaElettronica.Common;
using FatturaElettronica.Defaults;

namespace FatturaElettronica
{
    public abstract class FatturaBase : BaseClassSerializable
    {
        public override void ReadXml(XmlReader r)
        {
            r.MoveToContent();
            base.ReadXml(r);
        }

        public override void WriteXml(XmlWriter w)
        {
            w.WriteStartElement(RootElement.Prefix, GetLocalName(), RootElement.NameSpace);
            w.WriteAttributeString("versione", GetFormatoTrasmissione());
            foreach (var a in RootElement.ExtraAttributes)
            {
                w.WriteAttributeString(a.Prefix, a.LocalName, a.ns, a.value);
            }
            base.WriteXml(w);
            w.WriteEndElement();
        }

        protected abstract string GetFormatoTrasmissione();
        protected abstract string GetLocalName();
    }
}
