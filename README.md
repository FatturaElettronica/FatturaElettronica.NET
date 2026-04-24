# Fattura Elettronica per .NET

![Test](https://github.com/FatturaElettronica/FatturaElettronica.NET/workflows/Test/badge.svg)
[![NuGet version](https://badge.fury.io/nu/FatturaElettronica.svg)](https://badge.fury.io/nu/FatturaElettronica)

## Caratteristiche

- Lettura e scrittura nel formato XML conforme alle [specifiche tecniche ufficiali][pa].
- Convalida offline in osservanza alle specifiche tecniche.
- Fatture elettroniche ordinarie.
- Fatture elettroniche semplificate.
- De/serializzazione JSON.
- Supporto multi-lingua.
- Compatibile con [NET Standard v2.0][netstandard].

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

Fattura Elettronica è un progetto di [Nicola Iarocci][ni] per
[__Invoicetronic__][it]. È [libero][bsd], [sviluppato in pubblico][gh], aperto
alla collaborazione di tutti.

## Documentazione

- [Sito web](https://fatturaelettronicaopensource.org/)

## Powered by

[<img src="https://raw.githubusercontent.com/FatturaElettronica/FatturaElettronica.NET/master/Artwork/invoicetronic.svg" alt="Invoicetornic logo." width="298">](https://invoicetronic.com)

Realizzata dagli stessi autori di FatturaElettronica.NET, [__Invoicetronic API__][it] ti permette di integrare facilmente nella tua app l'intero ciclo della fattura elettronica: invio, ricezione, applicazione di firme digitali, convalida, notifiche via webhook e altro, il tutto su una piattaforma moderna che astrae le complessità di SDI/FatturaPA.

Invoicetronic include gli SDK per i linguaggi di programmazione più diffusi, comandi CLI per lo scripting, Web app, OpenAPI, e un completo ambiente di prova gratuita.

Visita il sito [__Invoicetronic__][it] per saperne di più.

[pa]: https://www.agenziaentrate.gov.it/portale/web/guest/specifiche-tecniche-versione-1.8
[bsd]: http://github.com/FatturaElettronica/FatturaElettronica.NET/blob/master/LICENSE.txt
[ga]: http://gestionaleamica.com
[ni]: https://nicolaiarocci.com
[nuget]: https://www.nuget.org/packages/FatturaElettronica/
[netstandard]: https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md
[rp]: http://www.kalamun.org/
[ghs]: https://github.com/sponsors/nicolaiarocci
[it]: https://invoicetronic.com
[gh]: https://github.com/FatturaElettronica/FatturaElettronica.NET