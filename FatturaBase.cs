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
            w.WriteStartElement(RootElement.Prefix, GetLocalName(), GetNameSpace());
            w.WriteAttributeString("versione", GetFormatoTrasmissione());
            foreach (var a in RootElement.ExtraAttributes)
            {
                w.WriteAttributeString(a.Prefix, a.LocalName, a.ns, a.value);
            }
            base.WriteXml(w);
            w.WriteEndElement();
        }

        public static FatturaBase CreateInstanceFromXml(System.IO.Stream stream)
        {
            FatturaBase ret;
            using (var r = XmlReader.Create(stream, new XmlReaderSettings
            {
                IgnoreWhitespace = true,
                IgnoreComments = true,
                IgnoreProcessingInstructions = true
            }))
            {
                while (r.Read() && !r.LocalName.Contains("Fattura"))
                {

                }
                var att = r.GetAttribute("versione");

                if (att == FormatoTrasmissione.Semplificata)
                    ret = Semplificata.FatturaSemplificata.CreateInstance(Instance.Semplificata);
                else
                    ret = Ordinaria.FatturaOrdinaria.CreateInstance(
                        att == FormatoTrasmissione.PubblicaAmministrazione ? Instance.PubblicaAmministrazione : Instance.Privati);
                stream.Position = 0;
            }
            using (var r = XmlReader.Create(stream, new XmlReaderSettings
            {
                IgnoreWhitespace = true,
                IgnoreComments = true,
                IgnoreProcessingInstructions = true
            }))
            {

                ret.ReadXml(r);
            }

            return ret;
        }

        public abstract string GetFormatoTrasmissione();
        protected abstract string GetLocalName();
        protected abstract string GetNameSpace();
    }
}
