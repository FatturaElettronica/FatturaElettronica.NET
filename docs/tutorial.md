# Guida all'uso

Sono supportate sie fatture ordinarie che seplificate. Qui
viene usata una `FatturaOrdinaria`, ma gli esempi sono validi quasi sempre
anche per una instanza di `FatturaSemplificata`.

## Instanziare la fattura

```cs
    var fattura = new FatturaOrdinaria();

    // In alternativa usare CreateInstance() per ottenere una istanza già tipizzata.
    // Questa chiamata restituisce fattura con CodiceDestinatario = "0000000"
    // FormatoTrasmissione = "FPR12":
    fattura = FatturaOrdinaria.CreateInstance(Instance.Privati);
```

## Caricare la fattura da XML

```cs
    // Lettura da file XML
    var readerSettings = new XmlReaderSettings
    {
        IgnoreWhitespace = true,
        IgnoreComments = true
    };
    using (var r = XmlReader.Create("IT01234567890_12345.xml", readerSettings))
    {
        fattura.ReadXml(r);
    }
```

## Consultare la fattura

```cs
    // Ogni file di fattura contiene un array di elementi FatturaElettronicaBody.
    Console.WriteLine($"Numero documenti: {fattura.FatturaElettronicaBody.Count}.");

    // Iterazione documenti presenti nel file.
    Console.WriteLine("Documenti inclusi nel file FatturaPA:");
    foreach (var doc in fattura.FatturaElettronicaBody)
    {
        var datiDocumento = doc.DatiGenerali.DatiGeneraliDocumento;
        Console.WriteLine($"Numero: {datiDocumento.Numero}");
        Console.WriteLine($"Data: {datiDocumento.Data.ToShortDateString()}");
        Console.WriteLine($"Importo totale: {datiDocumento.ImportoTotaleDocumento}");
        Console.WriteLine();
    }
```

## Convalidare la fattura

```cs
    // Convalida del documento.
    var validator = new FatturaOrdinariaValidator();
    var result = validator.Validate(fattura);
    Console.WriteLine(result.IsValid);

    // Introspezione errori di convalida.
    foreach (var error in result.Errors)
    {
        Console.WriteLine(error.PropertyName);
        Console.WriteLine(error.ErrorMessage);

        // ErrorCode conterrà il codice errore (es: "00423").
        Console.WriteLine(error.ErrorCode);
    }

    // Per brevità è possibile usare un extension method.
    result = fattura.Validate();
    Console.WriteLine(result.IsValid);

    // Sono disponibili validatori per ogni classe esposta da FatturaElettronica.
    var anagrafica = new DatiAnagraficiCedentePrestatore();
    var anagraficaValidator = new DatiAnagraficiCedentePrestatoreValidator();
    Console.WriteLine(anagraficaValidator.Validate(anagrafica).IsValid);

    // Oppure, come già visto:
    Console.WriteLine(anagrafica.Validate().IsValid);
```

## Modificare e aggiungere elementi alla fattura

```cs
    // Modifica proprietà Header.
    var header = fattura.FatturaElettronicaHeader;
    header.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione = "Bianchi Srl";

    //  Modifica proprietà Body
    var body = fattura.FatturaElettronicaBody[0];
    body.DatiGenerali.DatiGeneraliDocumento.Numero = "12345";

    // Aggiunta di un nuovo elemento Body.
    body = new FatturaElettronicaBody();
    body.DatiGenerali.DatiGeneraliDocumento.Numero = "99";
    fattura.FatturaElettronicaBody.Add(body);
```

## Salvare la fattura su XML

```cs
    // Serializzazione XML
    var writerSettings = new XmlWriterSettings { Indent = true };
    using (var w = XmlWriter.Create("IT01234567890_FPA01.xml", writerSettings))
    {
        fattura.WriteXml(w);
    }
```

## Scrittura e lettura da JSON

```cs
    // Serializzazione JSON.
    var json = fattura.ToJson(JsonOptions.Indented);
    Console.WriteLine(json);

    // Deserializzazione da JSON.
    var fatturaFromJson = new FatturaOrdinaria();
    fatturaFromJson.FromJson(new JsonTextReader(new StringReader(json)));
```

## Esempio completo

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
            var readerSettings = new XmlReaderSettings
            {
                IgnoreWhitespace = true,
                IgnoreComments = true
            };
            using (var r = XmlReader.Create("IT01234567890_12345.xml", readerSettings))
            {
                fattura.ReadXml(r);
            }

            // Ogni file di fattura contiene un array di elementi FatturaElettronicaBody.
            Console.WriteLine($"Numero documenti: {fattura.FatturaElettronicaBody.Count}.");

            // Iterazione documenti presenti nel file.
            Console.WriteLine("Documenti inclusi nel file FatturaPA:");
            foreach (var doc in fattura.FatturaElettronicaBody)
            {
                var datiDocumento = doc.DatiGenerali.DatiGeneraliDocumento;
                Console.WriteLine($"Numero: {datiDocumento.Numero}");
                Console.WriteLine($"Data: {datiDocumento.Data.ToShortDateString()}");
                Console.WriteLine($"Importo totale: {datiDocumento.ImportoTotaleDocumento}");
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

                // ErrorCode conterrà il codice errore (es: "00423").
                Console.WriteLine(error.ErrorCode);
            }

            // Per brevità è possibile usare un extension method.
            result = fattura.Validate();
            Console.WriteLine(result.IsValid);

            // Sono disponibili validatori per ogni classe esposta da FatturaElettronica.
            var anagrafica = new DatiAnagraficiCedentePrestatore();
            var anagraficaValidator = new DatiAnagraficiCedentePrestatoreValidator();
            Console.WriteLine(anagraficaValidator.Validate(anagrafica).IsValid);

            // Oppure, come già visto:
            Console.WriteLine(anagrafica.Validate().IsValid);

            // Modifica proprietà Header.
            var header = fattura.FatturaElettronicaHeader;
            header.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione = "Bianchi Srl";

            //  Modifica proprietà Body
            var body = fattura.FatturaElettronicaBody[0];
            body.DatiGenerali.DatiGeneraliDocumento.Numero = "12345";

            // Aggiunta di un nuovo elemento Body.
            body = new FatturaElettronicaBody();
            body.DatiGenerali.DatiGeneraliDocumento.Numero = "99";
            fattura.FatturaElettronicaBody.Add(body);

            // Serializzazione XML
            var writerSettings = new XmlWriterSettings { Indent = true };
            using (var w = XmlWriter.Create("IT01234567890_FPA01.xml", writerSettings))
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