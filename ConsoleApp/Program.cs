using System.Diagnostics;
using FatturaElettronica.Validators;
using FatturaElettronica.Impostazioni;
using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;
using FatturaElettronica;
using System.Xml;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanzia una nuova fattura elettronica.
            var fattura = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.PubblicaAmministrazione);

            // Lettura da file XML compatibile con formato SDI 1.2.
            var r = XmlReader.Create("IT01234567890_11111.xml", new XmlReaderSettings { IgnoreWhitespace = true });
            fattura.ReadXml(r);

            // Modifica valore.
            fattura.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione = "Bianchi Srl";

            // Convalida del documento.
            var validator = new FatturaElettronicaValidator();
            var result = validator.Validate(fattura);
            Debug.WriteLine(result.IsValid);

            // Introspezione errori di convalida.
            foreach (var error in result.Errors)
            {
                Debug.WriteLine(error.PropertyName);
                Debug.WriteLine(error.ErrorMessage);
                Debug.WriteLine(error.ErrorCode);
            }

            // Per brevità è possibile usare un extension method.
            result = fattura.Validate();
            Debug.WriteLine(result.IsValid);

            // Sono disponibili validatori per ogni classe esposta da FatturaElettronica.
            var anagrafica = new DatiAnagraficiCedentePrestatore();
            var anagraficaValidator = new DatiAnagraficiCedentePrestatoreValidator();
            Debug.WriteLine(anagraficaValidator.Validate(anagrafica).IsValid);
            // Oppure come già visto:
            Debug.WriteLine(anagrafica.Validate().IsValid);

            // Serializzazione XML in osservanza allo standard SDI 1.2.
            using (var w = XmlWriter.Create("IT01234567890_11111.xml", new XmlWriterSettings { Indent = true }))
            {
                fattura.WriteXml(w);
            }

            // Serializzazione JSON.
            var json = fattura.ToJson(JsonOptions.Indented);
            Debug.WriteLine(json);
        }
    }
}
