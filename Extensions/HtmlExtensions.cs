using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace FatturaElettronica.Extensions
{
    public static class HtmlExtensions
    {
        public static void WriteHtml(this FatturaBase fattura, string outPath, string xslPath)
        {
            if (outPath == null)
            {
                throw new ArgumentNullException(nameof(outPath));
            }
            
            if (xslPath == null)
            {
                throw new ArgumentNullException(nameof(xslPath));
            }

            var xt = new XslCompiledTransform();
            xt.Load(xslPath);
            
            using (var memoryStream = new MemoryStream())
            {
                using (var w = new XmlTextWriter(memoryStream, Encoding.UTF8) {Formatting = Formatting.Indented})
                {
                    fattura.WriteXml(w);
                    w.Flush();
                    
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    var xPathDocument = new XPathDocument(memoryStream);
                    using (var writer = File.OpenWrite(outPath))
                    {
                        xt.Transform(xPathDocument, null, writer);
                    }
                }
            }
        }
    }
}