# Fattura Elettronica per .NET

![Test](https://github.com/FatturaElettronica/FatturaElettronica.NET/workflows/Test/badge.svg)
[![NuGet version](https://badge.fury.io/nu/FatturaElettronica.svg)](https://badge.fury.io/nu/FatturaElettronica)

## Caratteristiche

- Lettura e scrittura nel formato XML conforme alle [specifiche tecniche ufficiali][pa].
- Convalida offline in osservanza alle specifiche tecniche.
- Fatture elettroniche ordinarie.
- Fatture elettroniche semplificate.
- De/serializzazione JSON.
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

FatturaElettronica è un progetto open source di [Nicola Iarocci][ni] e [Gestionali Amica][ga] rilasciato sotto licenza [BSD][bsd].
Artwork by [Kalamun][rp].

### Sponsorship

Se usi FatturaElettronica.NET o qualcun altro dei miei progetti in un
prodotto che genera profitto, buon senso vorrebbe che tu sponsorizzassi la
mia attività open source. Contribuiresti a far sì che il progetto su cui si
basa il tuo prodotto rimanga sano, attivo, e mantenuto nel tempo. Avresti
inoltre, se lo desideri, un premio in visibilità per te o la tua azienda.
Ogni singola sottoscrizione ha un impatto significante.

Scopri come puoi partecipare sulla mia pagina [GitHub Sponsors][ghs]

## Documentazione

- [Sito web](https://fatturaelettronicaopensource.org/)

[pa]: https://www.agenziaentrate.gov.it/portale/web/guest/specifiche-tecniche-versione-1.6.1
[bsd]: http://github.com/FatturaElettronica/FatturaElettronica.NET/blob/master/LICENSE.txt
[ga]: http://gestionaleamica.com
[ni]: https://nicolaiarocci.com
[nuget]: https://www.nuget.org/packages/FatturaElettronica/
[netstandard]: https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md
[rp]: http://www.kalamun.org/
[ghs]: https://github.com/sponsors/nicolaiarocci
