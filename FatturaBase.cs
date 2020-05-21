using System;
using System.IO;
using System.Xml;
using FatturaElettronica.Defaults;
using FatturaElettronica.Extensions;
using FatturaElettronica.Ordinaria;
using Org.BouncyCastle.Cms;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

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
            if (!string.IsNullOrEmpty(SistemaEmittente))
            {
                w.WriteAttributeString("SistemaEmittente", SistemaEmittente);
            }

            foreach (var a in RootElement.ExtraAttributes)
            {
                w.WriteAttributeString(a.Prefix, a.LocalName, a.ns, a.value);
            }

            base.WriteXml(w);
            w.WriteEndElement();
        }

        public static FatturaBase CreateInstanceFromXml(Stream stream, bool validateSignature = false)
        {
            try
            {
                return CreateInstanceFromPlainXml(stream);
            }
            catch (XmlException)
            {
                stream.Position = 0;
                return CreateInstanceFromXmlSigned(stream, validateSignature);
            }
        }

        private static FatturaBase CreateInstanceFromPlainXml(Stream stream)
        {
            FatturaBase ret;
            using (var r = XmlReader.Create(stream,
                new XmlReaderSettings
                {
                    IgnoreWhitespace = true, IgnoreComments = true, IgnoreProcessingInstructions = true
                }))
            {
                while (r.Read() && !r.LocalName.Contains("Fattura"))
                {
                }

                var att = r.GetAttribute("versione");

                if (att == FormatoTrasmissione.Semplificata)
                    ret = Semplificata.FatturaSemplificata.CreateInstance(Instance.Semplificata);
                else
                    ret = FatturaOrdinaria.CreateInstance(
                        att == FormatoTrasmissione.PubblicaAmministrazione
                            ? Instance.PubblicaAmministrazione
                            : Instance.Privati);
                stream.Position = 0;
            }

            using (var r = XmlReader.Create(stream,
                new XmlReaderSettings
                {
                    IgnoreWhitespace = true, IgnoreComments = true, IgnoreProcessingInstructions = true
                }))
            {
                ret.ReadXml(r);
            }

            return ret;
        }

        private static FatturaBase CreateInstanceFromXmlSigned(Stream stream,
            bool validateSignature = true)
        {
            try
            {
                using var parsed = SignedFileExtensions.ParseSignature(stream, validateSignature);
                var newStream = new MemoryStream();
                parsed.WriteTo(newStream);
                newStream.Position = 0;
                return CreateInstanceFromXml(newStream);
            }
            catch (CmsException)
            {
                stream.Position = 0;
                return CreateInstanceFromXmlSignedBase64(stream, validateSignature);
            }
        }

        private static FatturaBase CreateInstanceFromXmlSignedBase64(Stream stream,
            bool validateSignature = true)
        {
            byte[] converted;
            using (var reader = new StreamReader(stream))
            {
                converted = Convert.FromBase64String(reader.ReadToEnd());
            }

            return CreateInstanceFromXmlSigned(new MemoryStream(converted), validateSignature);
        }

        public string SistemaEmittente { get; set; }
        public abstract string GetFormatoTrasmissione();
        protected abstract string GetLocalName();
        protected abstract string GetNameSpace();
    }
}