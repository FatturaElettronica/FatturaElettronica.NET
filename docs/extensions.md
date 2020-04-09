# Extensions

Il namespace `FatturaElettronica.Extensions` mette a disposizione una serie di extension method che aggiungono
funzionalità o semplificano il lavoro quotidiano con le fatture elettroniche.

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

> [!note]
> A partire dalla v3 di FatturaElettronica le Extensions sono incluse nel package principale e non più rilasciate come package a parte.

*Extensions utilizza BouncyCastle, Copyright (c) 2000 - 2017 The Legion of the Bouncy Castle Inc. ([licenza][bc]).*

[bc]: http://www.bouncycastle.org/csharp/licence.html