# Fattura Elettronica per piattaforme .NET
[![Build status](https://ci.appveyor.com/api/projects/status/gft4hjbct0xgwogq?svg=true)](https://ci.appveyor.com/project/nicolaiarocci/fatturaelettronica-net)

## Features
- Lettura e scrittura nel [formato standard v1.2][pa] (XML).
- Supporta sia fatture elettroniche tra privati che con la Pubblica Amministrazione.
- Convalida in osservanza delle specifiche tecniche ufficiali.
- Supporto per la serializzazione in formato JSON

## Esempio
```cs
    // instanzia una nuova fattura elettronica
    var fattura = new FatturaElettronica.CreateInstance(Instance.PubblicaAmministrazione)

    // lettura da file XML compatibile con formato SDI 1.2
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

    // serializzazione XML secondo lo standard SDI 1.2
    var s = new XmlWriterSettings { Indent = true };

    XmlWriter w;
    using (w = XmlWriter.Create("IT01234567890_11111.xml", s)) {
	    fattura.WriteXml(w);
    }
```

## Portable Class Library
La libreria gira senza modifiche sui seguenti ambienti:

- NET Framework 4.5 e superiori,
- NET Core 1.0
- Windows 8
- Windows Phone Silverlight 8
- Xamarin.Android
- Xamarin.iOS
- Xamarin.iOS (Classic)

Un file .snk è fornito per la firma dell'assembly, in modo che possa essere usato in contesti in cui lo *strong naming* sia necessario.

## Installazione
FatturaElettronica è su [NuGet][nuget] quindi tutto quel che serve è eseguire:

```
	PM> Install-Package FatturaElettronica
```
dalla Package Console, oppure usare il comando equivalente in Visual Studio.

## Dipendenze
L'unica dipendenza è il progetto [BusinessObjects][bo] anch'esso reperibile su GitHub. 

## Licenza
FatturaElettronica è un progetto open source [Gestionale Amica][ga] rilasciato sotto licenza [BSD][bsd].

[pa]: http://www.fatturapa.gov.it/export/fatturazione/sdi/Specifiche_tecniche_del_formato_FatturaPA_v1.2.pdf 
[bo]: http://github.com/FatturaElettronica/BusinessObjects 
[bsd]: http://github.com/FatturaElettronica/FatturaElettronica.NET/blob/master/LICENSE
[ga]: http://gestionaleamica.com
[nuget]: https://www.nuget.org/packages/FatturaElettronica/