# Fattura Elettronica per .NET [![Build Status](https://dev.azure.com/FatturaElettronicaNET/FatturaElettronica/_apis/build/status/FatturaElettronica.FatturaElettronica.NET?branchName=master)](https://dev.azure.com/FatturaElettronicaNET/FatturaElettronica/_build/latest?definitionId=1&branchName=master) [![Dependabot Status](https://api.dependabot.com/badges/status?host=github&repo=FatturaElettronica/FatturaElettronica.NET)](https://dependabot.com)

## Caratteristiche

- Lettura e scrittura nel formato XML conforme alle [specifiche tecniche ufficiali][pa].
- Convalida offline in osservanza alle specifiche tecniche.
- Fatture elettroniche ordinarie.
- Fatture elettroniche semplificate.
- De/serializzazione JSON.

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

## FatturaElettronica.Extensions

[FatturaElettronica.Extensions][fex] estende FatturaElettronica.NET aggiungendo per esempio la lettura e creazione di file firmati digitalmente (.p7m).

NOTA BENE: A differenza di FatturaElettronica.NET che supporta anche NetStandard 1.1, Extensions supporta solo NetStandard v2.0.

### XML

- `ReadXml(string filePath)`: deserializza da file XML;
- `ReadXml(Stream stream)`: deserializza da stream;
- `ReadXmlSigned(string filePath)`: deserializza da XML firmato con algoritmo CADES (.p7m). Supporta anche file codificati Base64;
- `ReadXmlSigned(Stream stream)`: deserializza da stream firmato con algoritmo CADES (.p7m). Supporta anche file codificati Base64;
- `ReadXmlSignedBase64(string filePath)`: consigliato quando si sa in anticipo che il file è codificato Base64;
- `WriteXml(string filePath)`: serializza su file XML non firmato;
- `WriteXmlSigned(string pfxFile, string pfxPassword, string p7mFilePath)`: serializza su file XML, firmando con algoritmo CADES (.p7m);

### HTML

- `WriteHtml(string outPath, string xslPath)`: crea un HTML con rappresentazione della fattura, usando un foglio di stile;

### JSON

- `FromJson(string json)`: deserializza da JSON;

### Altro

- `FatturaElettronicaFileNameGenerator`: classe per la generazione di nomi file conformi allo standard fattura elettronica.

### Utilizzo di FatturaElettronica.Extensions

```cs
using System;
using System.Xml;
using System.IO;
using FatturaElettronica;
using FatturaElettronica.Common;
using FatturaElettronica.Extensions;
using FatturaElettronica.Defaults;


namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var fattura = FatturaOrdinaria.CreateInstance(Instance.Privati);

            // Lettura diretta da XML (senza necessità di uno stream aperto)
            fattura.ReadXml("IT02182030391_32.xml");
            // Lettura da stream
            fattura.ReadXml(File.OpenRead("IT02182030391_32.xml"));

            // Firma digitale del file xml con file pfx
            fattura.WriteXmlSigned("idsrv3test.pfx", "idsrv3test", @"IT02182030391_32.xml.pm7");

            // Legge file con firma digitale. Solleva eccezione se firma invalida.
            fattura.ReadXmlSigned("IT02182030391_31.xml.p7m");
            // Legge file con firma digitale evitando di convalidarne la firma.
            fattura.ReadXmlSigned("IT02182030391_31.xml.p7m", validateSignature: false);
            // Deserializza da stream con firma digitale. Solleva eccezione se firma non valida.
            fattura.ReadXmlSigned(someStream);
            // Deserializza da stream evitando di convalidare la firma.
            fattura.ReadXmlSigned(someStream, validateSignature: false);

            // Scrive direttamente su XML (senza necessità passare uno stream)
            fattura.WriteXml("Copia di IT02182030391_31.xml");

            // Crea HTML della fattura. Usa foglio di stile PA
            // (https://www.fatturapa.gov.it/export/fatturazione/sdi/fatturapa/v1.2.1/fatturaPA_v1.2.1.xsl)
            fattura.WriteHtml("fattura.htm", "fatturaPA_v1.2.1.xsl");

            // Serializza fattura in JSON.
            var json = fattura.ToJson();

            var copia = FatturaOrdinaria.CreateInstance(Instance.Privati);

            // Deserializza da JSON
            copia.FromJson(json);
            // Le due fatture sono uguali.
            Console.WriteLine($"{fattura.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario}");
            Console.WriteLine($"{copia.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario}");

            GetNextFileName();
        }

        /// Ottiene e stampa un nome di file valido per fattura elettronica
        static void GetNextFileName()
        {
            // Generare il nome del file
            var fileNameGenerator = new FatturaElettronicaFileNameGenerator(
                new IdFiscaleIVA() { IdPaese = "IT", IdCodice = "0123456789" }
            );
            var fileName = fileNameGenerator.GetNextFileName(lastBillingNumber: 100);

            // IT0123456789_0002T.xml
            Console.WriteLine(fileName);
            // 101
            Console.WriteLine(fileNameGenerator.CurrentIndex);
        }
    }
}

```

### Installazione di FatturaElettronica.Extensions

FatturaElettronica.Extensions è su [NuGet][nuget].

Dalla command line, con .NET Core:

```Shell
    dotnet add package FatturaElettronica.Extensions
```

Dalla Package Console, in Visual Studio:

```PowerShell
    PM> Install-Package FatturaElettronica.Extensions
```

Oppure usare il comando equivalente nella UI di Visual Studio.

## Licenza

FatturaElettronica e FatturaElettronica.Extensions sono progetti open source di [Nicola Iarocci][ni] e [Gestionali Amica][ga] rilasciati sotto licenza [BSD][bsd].
Artwork by [Kalamun][rp]

[pa]: https://www.agenziaentrate.gov.it/wps/content/Nsilib/Nsi/Schede/Comunicazioni/Fatture+e+corrispettivi/Fatture+e+corrispettivi+ST/ST+invio+di+fatturazione+elettronica/?page=ivacomimp
[bsd]: http://github.com/FatturaElettronica/FatturaElettronica.NET/blob/master/LICENSE
[ga]: http://gestionaleamica.com
[ni]: https://nicolaiarocci.com
[nuget]: https://www.nuget.org/packages/FatturaElettronica/
[netstandard]: https://github.com/dotnet/standard/blob/master/docs/versions/netstandard1.1.md
[fex]: http://github.com/FatturaElettronica/FatturaElettronica.Extensions
[rp]: http://www.kalamun.org/