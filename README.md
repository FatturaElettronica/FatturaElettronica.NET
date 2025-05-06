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

Fattura Elettronica è un progetto di [Nicola Iarocci][ni] e
[__Invoicetronic__][it]. È [libero][bsd], [sviluppato in pubblico][gh], aperto
alla collaborazione di tutti.

## Documentazione

- [Sito web](https://fatturaelettronicaopensource.org/)

## API moderne per la fattura elettronica in Italia

[__Invoicetronic API__][it] ti consente di integrare facilmente l'intero ciclo di gestione della fattura elettronica: __invio__, __ricezione__, applicazione di __firme digitali__, __validazione__ preventiva, notifiche __webhook__, __log__ degli eventi, varie __opzioni di upload__ e molto altro, il tutto su una piattaforma moderna che astrae le complessità di SDI.

Invoicetronic include __client SDK__ open-source per i linguaggi di programmazione più diffusi, __comandi CLI__ per lo
scripting, una completa __documentazione OpenAPI__ e un ambiente __Sandbox gratuito__.

Vai su [__Invoicetronic__][it] per saperne di più.

## Powered by

[![JetBrains logo.](https://resources.jetbrains.com/storage/products/company/brand/logos/jetbrains.svg)](https://jb.gg/OpenSourceSupport)

[pa]: https://www.agenziaentrate.gov.it/portale/web/guest/specifiche-tecniche-versione-1.8
[bsd]: http://github.com/FatturaElettronica/FatturaElettronica.NET/blob/master/LICENSE.txt
[ga]: http://gestionaleamica.com
[ni]: https://nicolaiarocci.com
[nuget]: https://www.nuget.org/packages/FatturaElettronica/
[netstandard]: https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md
[rp]: http://www.kalamun.org/
[ghs]: https://github.com/sponsors/nicolaiarocci
[it]: https://www.invoicetronic.com
[gh]: https://github.com/FatturaElettronica/FatturaElettronica.NET