# Fattura Elettronica per piattaforme .NET
[![Build status](https://ci.appveyor.com/api/projects/status/gft4hjbct0xgwogq?svg=true)](https://ci.appveyor.com/project/nicolaiarocci/fatturaelettronica-net)

## Caratteristiche
- Lettura e scrittura nel [formato standard v1.2][pa] (XML).
- Supporta sia fatture elettroniche tra privati che con la Pubblica Amministrazione.
- Convalida in osservanza delle specifiche tecniche ufficiali.
- Supporto per la serializzazione in formato JSON

## Utilizzo
```cs
    using FatturaElettronica;
    using FatturaElettronica.Validators;
    using FatturaElettronica.Impostazioni;
    using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;
    using System.Xml;
    using System.Diagnostics;

    // Usare il factory method CreateInstance() per ottenere una istanza di Fattura.
    var fattura = Fattura.CreateInstance(Instance.PubblicaAmministrazione);

    // Lettura da file XML compatibile con formato SDI 1.2.
    var r = XmlReader.Create("IT01234567890_11111.xml", new XmlReaderSettings { IgnoreWhitespace = true });
    fattura.ReadXml(r);

    // Modifica valore.
    fattura.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione = "Bianchi Srl";

    // Convalida del documento.
    var validator = new FatturaValidator();
    var result = validator.Validate(fattura);
    Debug.WriteLine(result.IsValid);

    // Introspezione errori di convalida.
    foreach (var error in result.Errors)
    {
        Debug.WriteLine(error.PropertyName);
        Debug.WriteLine(error.ErrorMessage);
        // Nei casi di errore 2xx e 4xx ErrorCode conterrà il codice errore (es: "00423").
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
```
### Limitazioni
In convalida non sono supportati gli errori di tipo `3xx` in quanto risultato dei riscontri fatti da PA sui propri server. 

## Portable Class Library
La libreria gira senza modifiche sui seguenti ambienti:

- NET Framework 4.5 e superiori,
- NET Core 1.0 (*)
- Windows 8
- Windows Phone Silverlight 8
- Xamarin.Android
- Xamarin.iOS
- Xamarin.iOS (Classic)

Un file .snk è fornito per la firma dell'assembly, in modo che possa essere usato in contesti in cui lo *strong naming* sia necessario.

(*) Il package è compatibile con NETCore. Una delle sue dipendenze, FluentValidation, purtroppo non lo è ancora.

## Installazione
FatturaElettronica è su [NuGet][nuget] quindi tutto quel che serve è eseguire:

```
	PM> Install-Package FatturaElettronica
```
dalla Package Console, oppure usare il comando equivalente in Visual Studio.

## Licenza
FatturaElettronica è un progetto open source di [Nicola Iarocci][ni] e [Gestionale Amica][ga] rilasciato sotto licenza [BSD][bsd].

[pa]: http://www.fatturapa.gov.it/export/fatturazione/sdi/Specifiche_tecniche_del_formato_FatturaPA_v1.2.pdf 
[bo]: http://github.com/FatturaElettronica/BusinessObjects 
[bsd]: http://github.com/FatturaElettronica/FatturaElettronica.NET/blob/master/LICENSE
[ga]: http://gestionaleamica.com
[ni]: https://nicolaiarocci.com
[nuget]: https://www.nuget.org/packages/FatturaElettronica/