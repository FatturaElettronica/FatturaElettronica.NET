# Fattura Elettronica per piattaforme .NET [![Build status](https://ci.appveyor.com/api/projects/status/gft4hjbct0xgwogq?svg=true)](https://ci.appveyor.com/project/nicolaiarocci/fatturaelettronica-net)

## Caratteristiche

- Lettura e scrittura nel formato XML conforme alle [specifiche tecniche ufficiali][pa].
- Convalida offline in osservanza alle specifiche tecniche.
- Supporto sia per fatture elettroniche tra privati che verso la Pubblica Amministrazione.
- Supporto per de/serializzazione JSON.

## Utilizzo

```cs
using FatturaElettronica;
using FatturaElettronica.Common;
using FatturaElettronica.Defaults;
using FatturaElettronica.Validators;
using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;
using FatturaElettronica.FatturaElettronicaBody;

using System;
using System.Xml;
using System.IO;

using Newtonsoft.Json;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var fattura = new Fattura();
            // In alternativa usare CreateInstance() per ottenere una istanza già tipizzata.
            // Questa chiamata restituisce fattura con CodiceDestinatario = "0000000"
            // FormatoTrasmissione = "FPR12":
            fattura = Fattura.CreateInstance(Instance.Privati);

            // Lettura da file XML
            using (var r = XmlReader.Create("/Users/Nicola/Downloads/test-sconti.xml", new XmlReaderSettings { IgnoreWhitespace = true, IgnoreComments = true }))
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
            var validator = new FatturaValidator();
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
            var fatturaFromJson = new Fattura();
            fatturaFromJson.FromJson(new JsonTextReader(new StringReader(json)));
        }
    }
}
```

### Limitazioni

In convalida non sono supportati gli errori di tipo `3xx` in quanto risultato dei riscontri fatti da PA sui propri server.

## Portabilità

FatturaElettronica supporta .NET Standard v1.1 cosa che le permette di supportare un [ampio numero di piattaforme][netstandard].

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

## Estensioni

[FatturaElettronica.Extensions][fex] aggiunge features a FatturaElettronica.NET, come la lettura e creazione di file firmati digitalmente (.p7m).

## Licenza

FatturaElettronica è un progetto open source di [Nicola Iarocci][ni] e [Gestionale Amica][ga] rilasciato sotto licenza [BSD][bsd].
Artwork by [Kalamun][rp]

[pa]: https://www.agenziaentrate.gov.it/wps/content/Nsilib/Nsi/Schede/Comunicazioni/Fatture+e+corrispettivi/Fatture+e+corrispettivi+ST/ST+invio+di+fatturazione+elettronica/?page=ivacomimp
[bo]: http://github.com/FatturaElettronica/BusinessObjects
[bsd]: http://github.com/FatturaElettronica/FatturaElettronica.NET/blob/master/LICENSE
[ga]: http://gestionaleamica.com
[ni]: https://nicolaiarocci.com
[nuget]: https://www.nuget.org/packages/FatturaElettronica/
[netstandard]: https://github.com/dotnet/standard/blob/master/docs/versions/netstandard1.1.md
[fex]: http://github.com/FatturaElettronica/FatturaElettronica.Extensions
[rp]: http://www.kalamun.org/