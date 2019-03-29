# Fattura Elettronica per .NET 

[![Build Status](https://dev.azure.com/FatturaElettronicaNET/FatturaElettronica/_apis/build/status/FatturaElettronica.FatturaElettronica.NET?branchName=master)](https://dev.azure.com/FatturaElettronicaNET/FatturaElettronica/_build/latest?definitionId=1&branchName=master) [![Dependabot Status](https://api.dependabot.com/badges/status?host=github&repo=FatturaElettronica/FatturaElettronica.NET)](https://dependabot.com)

## Caratteristiche

- Lettura e scrittura nel formato XML conforme alle [specifiche tecniche ufficiali][pa].
- Convalida offline in osservanza alle specifiche tecniche.
- Fatture elettroniche ordinarie.
- Fatture elettroniche semplificate.
- De/serializzazione JSON.
- Compatibile con [NET Standard v1.1][netstandard].

## Installazione

FatturaElettronica è su [NuGet][nuget].

Dalla command line, con .NET Core:

```Shell
    dotnet add package FatturaElettronica
```

Dalla Package Console, in Visual Studio:

```PowerShell
    PM> Install-Package FatturaElettronica
```

Oppure usare il comando equivalente nella UI di Visual Studio.

## Licenza

FatturaElettronica è un progetto open source di [Nicola Iarocci][ni] e [Gestionali Amica][ga] rilasciato sotto licenza [BSD][bsd].
Artwork by [Kalamun][rp]

## Utilizzo

```cs
using FatturaElettronica.Ordinaria;
using FatturaElettronica.Common;
using FatturaElettronica.Defaults;
using FatturaElettronica.Validators;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody;
using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CedentePrestatore;

using System;
using System.Xml;
using System.IO;

using Newtonsoft.Json;
using FatturaElettronica;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var fattura = new FatturaOrdinaria();
            // In alternativa usare CreateInstance() per ottenere una istanza già tipizzata.
            // Questa chiamata restituisce fattura con CodiceDestinatario = "0000000"
            // FormatoTrasmissione = "FPR12":
            fattura = FatturaOrdinaria.CreateInstance(Instance.Privati);

            // Lettura da file XML
            using (var r = XmlReader.Create("IT01234567890_12345.xml", new XmlReaderSettings { IgnoreWhitespace = true, IgnoreComments = true }))
            {
                fattura.ReadXml(r);
            }

            // Ogni file di fattura contiene un array di elementi FatturaElettronicaBody.
            Console.WriteLine($"Numero di documenti: {fattura.FatturaElettronicaBody.Count}.");
            Console.WriteLine("Documenti inclusi nel file FatturaPA:");
            foreach (var doc in fattura.FatturaElettronicaBody)
            {
                Console.WriteLine($"Numero: {doc.DatiGenerali.DatiGeneraliDocumento.Numero}");
                Console.WriteLine($"Data: {doc.DatiGenerali.DatiGeneraliDocumento.Data.ToShortDateString()}");
                Console.WriteLine($"Totale documento: {doc.DatiGenerali.DatiGeneraliDocumento.ImportoTotaleDocumento}");
                Console.WriteLine();

            }

            // Convalida del documento.
            var validator = new FatturaOrdinariaValidator();
            var result = validator.Validate(fattura);
            Console.WriteLine(result.IsValid);

            // Introspezione errori di convalida.
            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.PropertyName);
                Console.WriteLine(error.ErrorMessage);
                // Nei casi di errore 2xx e 4xx ErrorCode conterrà il codice errore (es: "00423").
                Console.WriteLine(error.ErrorCode);
            }

            // Per brevità è possibile usare un extension method.
            result = fattura.Validate();
            Console.WriteLine(result.IsValid);

            // Sono disponibili validatori per ogni classe esposta da FatturaElettronica.
            var anagrafica = new DatiAnagraficiCedentePrestatore();
            var anagraficaValidator = new DatiAnagraficiCedentePrestatoreValidator();
            Console.WriteLine(anagraficaValidator.Validate(anagrafica).IsValid);
            // Oppure come già visto:
            Console.WriteLine(anagrafica.Validate().IsValid);

            // Modifica proprietà Header.
            fattura.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione = "Bianchi Srl";
            //  Modifica proprietà Body
            fattura.FatturaElettronicaBody[0].DatiGenerali.DatiGeneraliDocumento.Numero = "12345";

            // Aggiunta di un nuovo elemento Body.
            var body = new FatturaElettronicaBody();
            body.DatiGenerali.DatiGeneraliDocumento.Numero = "99";
            fattura.FatturaElettronicaBody.Add(body);

            // Serializzazione XML
            using (var w = XmlWriter.Create("IT01234567890_FPA01.xml", new XmlWriterSettings { Indent = true }))
            {
                fattura.WriteXml(w);
            }

            // Serializzazione JSON.
            var json = fattura.ToJson(JsonOptions.Indented);
            Console.WriteLine(json);

            // Deserializzazione da JSON.
            var fatturaFromJson = new FatturaOrdinaria();
            fatturaFromJson.FromJson(new JsonTextReader(new StringReader(json)));
        }
    }
}
```

## Limitazioni

In convalida non sono supportati gli errori di tipo `3xx` in quanto risultato dei riscontri fatti da PA sui propri server.

[pa]: https://www.agenziaentrate.gov.it/wps/content/Nsilib/Nsi/Schede/Comunicazioni/Fatture+e+corrispettivi/Fatture+e+corrispettivi+ST/ST+invio+di+fatturazione+elettronica/?page=ivacomimp
[bsd]: http://github.com/FatturaElettronica/FatturaElettronica.NET/blob/master/LICENSE
[ga]: http://gestionaleamica.com
[ni]: https://nicolaiarocci.com
[nuget]: https://www.nuget.org/packages/FatturaElettronica/
[netstandard]: https://github.com/dotnet/standard/blob/master/docs/versions/netstandard1.1.md
[fex]: http://github.com/FatturaElettronica/FatturaElettronica.Extensions
[rp]: http://www.kalamun.org/