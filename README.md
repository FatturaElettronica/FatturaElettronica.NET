# Fattura Elettronica per .NET

## Features
- Lettura e scrittura nel [formato standard v1.3 PA][pa] (XML).
- Convalida in osservanza delle specifiche tecniche ufficiali.
- Supporto per la serializzazione in formato JSON

## Esempio
```cs
    // instanzia una nuova fattura elettronica
    FatturaElettronica fattura = new FatturaElettronica();

    // lettura da file XML compatibile con formato SDI1.1
    var s = new XmlReaderSettings {IgnoreWhitespace = true};
    var r = XmlReader.Create("IT01234567890_11111.xml", s);
    fattura.ReadXml(r);

    // convalida documento
    if (!fattura.IsValid) {
	    Debug.WriteLine(fattura.Error);
    }

    // serializzazione JSON
    var json = fattura.ToJson(JsonOptions.Indented);
    Debug.WriteLine(json);

    // modifica valore
    fattura.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici.RegimeFiscale = "RF11";

    // serializzazione XML secondo lo standard SDI 1.1
    var s = new XmlWriterSettings { Indent = true };

    XmlWriter w;
    using (w = XmlWriter.Create("IT01234567890_11111.xml", s)) {
	    fattura.WriteXml(w);
    }
```

## Portable Class Library
La libreria gira senza modifiche sui seguenti ambienti:

- .NET Framework 4.0 e superiori,
- Xamarin.iOS
- Xamarin.Android
- Windows Phone 8
- Windows Store apps (Windows 8)
- Silverlight 5.0

Un file .snk è fornito per la firma dell'assembly, in modo che possa essere usato in contesti in cui lo *strong naming* sia necessario.

## Installazione
FatturaElettronica.NET è su [NuGet][nuget] quindi tutto quel che serve è eseguire:

```
	PM> Install-Package FatturaElettronica
```
dalla Package Console, oppure usare il comando equivalente in Visual Studio.

## Dipendenze
L'unica dipendenza è il progetto [BusinessObjects][bo], anch'esso reperibile su GitHub. 

## Licenza
FatturaElettronica.NET è un progetto open source [Gestionale Amica][ga] rilasciato sotto licenza [BSD][bsd].

[pa]: http://www.fatturapa.gov.it/export/fatturazione/sdi/Specifiche_tecniche_SdI_v1.3.pdf
[bo]: http://github.com/FatturaElettronicaPA/BusinessObjects 
[bsd]: http://github.com/FatturaElettronicaPA/FatturaElettronica.NET/blob/master/LICENSE
[ga]: http://gestionaleamica.com
[nuget]: https://www.nuget.org/packages/FatturaElettronica/