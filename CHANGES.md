Changelog
=========

In Development
--------------

- New: FatturaBase.CreateInstanceFromXml() restituisce una istanza di FatturaOrdinaria o FatturaSemplificata ([#240][240])
- Fix: Semplificata.DatiBeniServizi.DatiIVA: Aliquota o Importo obbligatori ([#238][238])
- Fix: Semplificata.CessionarioCommittente.IdFiscaleIva va convalidato se valorizzato ([#242][242])

[240]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/240
[238]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/238
[242]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/242

v2.0.8
------

Released on December 2m 2019

- Fix: convalida fattura semplificata, importo massimo portato a 400 euro ([#233][233])

v2.0.7
------

Released on November 28, 2019

- Fix: errore nell'ordine dei campi CedentePrestatore in fattura semplificata ([#220][220])
- Test suite aggiornata a NetCore 3.0
- Fix: refuso in TOC.md ([#221][221])
- Fix: Aggiunto il Kosovo alla tabella IdPaese ([#214][214])
- Tutorial: Aggiunto `IgnoreProcessingInstructions` a `XmlReaderSettings` per evitare crash quando
  nodi "processing instructions" (es: `xml-stylesheet`) sono presenti nel XML. ([#209][209])

[233]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/233
[220]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/220
[221]: https://github.com/FatturaElettronica/FatturaElettronica.NET/pull/221
[214]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/214
[209]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/209

v2.0.6
------

Released on May 24, 2019

- Fix: FatturaSemplificata convalidata con TipoDocumento valido per Ordinaria ([#205][205])
- Fix: FatturaSemplificata convalidata con Natura valida per Ordinaria ([#205][205])
- Fix: Validazione AltriDatiIdentificativi in FatturaSemplificata ([#203][203])
- Fix: UnitaMisura vuota deve sollevare errore di validazione ([#204][204])
- Fix: DatiFatturaRettificata.DataFR dovrebe essere nullabile ([#200][200])
- Fix: CausalePagamento: ZO e M2 sostituiti rispettivamente da Z e M ([#191][191c])

[205]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/205
[203]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/203
[204]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/204
[200]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/200
[191c]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/191#issuecomment-493911791

v2.0.5
------

Released on April 23, 2019

- Fix: validatore CausalePagamento da aggiornare per unico 2019 ([#191][191])
- Test refactoring and cleanup.

[191]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/191

v2.0.4
------

Released on April 16, 2019

- Fix: falso errore 00418 "Data antecedente a data fattura rettificata" ([#190][190])
- Aggiunto badge NuGet al README ([#188][188])
- `LatinBaseValidator` ora indica quali sono i caratteri non accettati ([#185][185])

[190]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/190
[188]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/188
[185]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/185

v2.0.3
------

Released on April 8, 2019

- Fix: errore validazione DettaglioLinee.TotalPrice ([#181][181])
- Refactoring: classe Allegati spostata in FatturaElettronica.Common ([#179][179])
- Docs: aggiunto folder `docs` con documentazione progetto.

[181]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/181
[179]: https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/179

v2.0.2
------

Released on March 19, 2019

- Fix: il root node della fattura semplificata ha il namespace sbagliato. Addresses #176.

v2.0.1
------

Released on March 19, 2019

- Fix: il root node della fattura semplificata ha il nome sbagliato. Closes #176.

v2.0
----

Released on March 13, 2019

- New: Supporto per fattura semplificata (Gaetano Pizzol). Closes #137.
- BREAKING: classe Fattura (Fattura.cs) rinominata FatturaOrdinaria (Ordinaria/FatturaOrdinaria.cs).
- BREAKING: gerarchia di classi per fattura ordinaria spostata nel namespace FatturaElettronica.Ordinaria.

- Fix: warning NU5125: The 'licenseUrl' element will be deprecated. Closes #166.
- Fix: Proprietà di tipo oggetto opzionali sollevano "Object reference not set to an instance of an object" quando nulle. Closes #165.
- Fix: DatiTrasporto.PesoLordo e DatiTrasporto.PesoNetto non possono superare il valore 9999.99m. Closes #157.

- Bump FatturaElettronica.Core a 2.0.
- Bump Microsoft.NET.Test.Sdk to 16.0.1.
- Bump FluentValidation to 8.1.3.
- Bump Newtonsoft.Json to 12.0.1.
- Bump MSTest.TestAdapter to 1.4.0
- Bump MSTest.TestFramework to 1.4.0

- Switch CI da AppVeyor ad Azure Pipelines.

v1.1.5
-------

Released on February 2, 2019

- Fix: Tabella CausalePagamento aggiornata al 2019. Closes #151.

v1.1.4
-------

Released on January 31, 2019

- Fix: ScontoMaggiorazione può accettare sia Importo che Percentuale. Closes #146.
- Fix: IdPaese.Irlanda è duplicato mentre Islanda è assente. Closes #144.
- README: aggiunto esempio di inserimento elemento Body. Addresses #141.

v1.1.3
------

Released on January 23, 2019

- New: nuovo logo per il progetto FatturaElettronica, by Roberto "Kalamun" Pasini. Closes 101.
- Fix: Link obsoleto alle specifiche tecniche ufficiali. Closes #139.
- Fix: ScontoMaggiorazione deve accettare Importo o Percentuale a 0. Addresses #136.
- Fix: ScontoMaggiorazione non deve accettare Importo e Percentuale entrambi valorizzati. Addresses #136.

v1.1.2
------

Released on January 21, 2019

- Fix: Validazione ScontoMaggiorazione dovrebbe accettare Importo o Percentuale a 0. Closes #136.

v1.1.1
------

Released on January 17, 2019

- Fix: Tabella CausalePagamento completata coi nomi di ogni pagamento (Michael Mairegger). Pull #127.
- Fix: Convalida Provincia non conforme ai controlli lato AgEntrate. Closes #129.
- Fix: CessionarioCommittente.RappresentanteFiscale, errore "sequenza tag errata". Closes #133.
- Fix: Supporto per 8 decimali nel PrezzoUnitario (Claudio Lepri). Pull #130; Closes #125.
- Bump FatturaElettronica.Core a 1.1.1.

v1.1
----

Released on January 6, 2019

- New: NetStandard 2.0 aggiunto ai target framework (Federico Dipuma). Closes #119.
- New: costruttore classe Fattura ora è pubblico. Closes #99.
- New: performance migliorata (Federico Dipuma). See #120.
- Fix: Quantità non può assumere valore negativo. Closes #115.
- Fix: Small typos. Closes #116.

v1.0.4
------

Released on January 2, 2019

- Fix: Aggiunta "Sud Sardegna" alla lista provincie (Massimo Linossi). Pull #111.

v1.0.3
------

Released on December 30, 2018

- Fix: UnitaMisura è opzionale. Addresses #102.

v1.0.2
------

Released on December 20, 2018.

- Fix: Titolo e CodEORI ignorano ordinamento. Closes #103.
- Fix: controllo UnitaMisura consente campo vuoto. Closes #102.

v1.0.1
------

Released on November 9, 2018.

- Bump: FatturaElettronica.Core to 1.0.

v1.0
----

Released on November 9, 2018.

- BREAKING: proprietà Fattura.Header rinominata in FatturaElettronicaHeader. Closes #83.
- BREAKING: proprietà Fattura.Body rinominata in FatturaElettronicaBody. Closes #83.
- BREAKING: namespace FatturaElettronica.Impostazioni rinominato FatturaElettronica.Defaults.

- Fix: Aggiornati codici INCOTERMS (Marco Tessitore). Pull #89; Pull #91.
- Fix: Rimosso controllo 00426 su campo PECDestinatario (Gaetano Pizzol). Pull #88.
- Fix: Anagrafica.CognomeNome non deve essere serializzato in JSON. Closes #86.
- Fix: DettaglioPagamento.IBAN deve essere formalmente corretto. Closes #84.
- Fix: Campo RiferimentoNumero dovrebbe essere opzionale (Gaetano Pizzol). Pull #82.
- Fix: Aggiunto setter mancante a DettaglioLinee.AltriDatiGestionali. Addresses #81.
- Fix: Header e Body vanno JSON-serializzati come FatturaElettronicaHeader e FatturaElettronicaBody. Closes #83.

- Bump: FatturaElettronica.Core to 0.5.
- Bump: Newtonsoft.Json to 11.0.2.
- Bump: MSTest.TestFramework to 1.3.2.
- Bump: MSTest.TestAdapter to 1.3.2.
- Bump: Microsoft.NET.Test.Sdk to 15.9.0.

v0.9
----

Released on October 26, 2018.

- New: FromJson() de-serializza stream JSON.
- Fix: PECDestinatario può essere vuoto quando CodiceDestinatario è 0000000. Closes #75.
- Fix: Le proprietà di tipo Class non sono scrivibili. Closes #76.
- Fix: ToJson() serializza proprietà che non dovrebbero comparire nel JON.
- I test ora girano come app NetCore 2.1. Addresses FatturaElettronica/FatturaElettronica.Core#4.

v0.8.5
------

Released on October 16, 2018.

- New: Validazione errore 00426 per campo 1.1.6 PECDestinatario. Closes #74.
- Fix: errore descrizione in RegimeFiscale "RF17". Closes #72.
- Fix: "Nullable object must have a value" in validazione di blocco ScontoMaggiorazione con Importo = 0. Closes #71.

v0.8.4
------

Released on October 4, 2018.

- Upgrade: FluentValidation to v8.0.100.

v0.8.3
------

Released on October 2, 2018.

- Fix: DettaglioLineeValidator: 00423 non supporta tolleranca di 1 centesimo. Closes #66.

v0.8.2
------

Released on October 1, 2018.

- FatturaElettronica.Core dependency bumped to v0.2.
- Cleanup and refactoring: use auto-properties; remove unnecessary usings.

v0.8.1
------

Rilasciata il 4.7.2018

- Fix: errore lunghezza PECDestinatario in v0.8. Closes #58.

v0.8
----

Rilasciata il 3.7.2018

- Recepite specifiche tecniche Allegato A del 22.6.2018. Closes #52.
- New: rimossi controlli su campo PECDestinatario. Addresses #52.
- New: supporto per TipoDocumento TD020 autofattura. Addresses #52
- Passata la test suite da NET461 a NETCore. Closes #57.

v0.7
----

Rilasciata il 4.10.2017

- Spostata serializzazione su package indipendente FatturaElettronica.Core.
- Abbandonato il profilo PCL in favore di NetStandard 1.1.

v0.6.3
------

Rilasciata il 17.7.2017

- Fix: RappresentanteFiscale viene erroneamente serializzato come 'Rappresentante' causando errore convalida 200
  da parte del sistema PA. Closes #49.
- README: Aggiunta opzione IgnoreComments a XmlReader per evitare crash nel caso di commenti nel XML. Closes #45.

v0.6.2
------

Rilasciata il 23.5.2017.

- Fix: Falso errore di convalida 00423 quando PrezzoTotale � valorizzato con piu di due decimali. Closes #45.

v0.6.1
------

Rilasciata il 5.5.2017.

- Fix: Falso errore di convalida 00415 quando DatiCassaPrevidenziale � valorizzato ma non ha Ritenuta="SI". Closes #44.

v0.6.0
------

Rilasciata il 27.4.2017.

- Assembly non pi� strong-named. Closes #41.
- README: aggiunti esempi di introspezione e modifica degli elementi FatturaElettronicaBody. Closes #38.

v0.5.1
------

Rilasciata il 26.4.2017.

- Fix: Errore 00421 non tiene conto della tolleranza garantita di 0.01 centesimi. Closes #43.

v0.5.0
------

Rilasciata il 30.3.2017.

Questa versione recepisce le modifiche introdotte con la v1.2.1 delle specifiche tecniche PA.

- Regime Fiscale RF03 � abrogato. Viene restituito errore 00459 se utilizzato.
- Natura N5: descrizione aggiornata a "regime del margine / IVA non esposta in fattura".
- Le propriet� Codice e Nome della classe astratta Tabella non sono pi� protette in scrittura.

v0.4.3
------

Rilasciata il 23.3.2017.

- Fix: Validazione conformit� ai gruppi IsBasicLatin e IsLatin-1Supplement. Closes #29.
- Fix: Non includere il folder Artwork nel package NuGet. Closes #37.

v0.4.2
------

Rilascata il 17.3.2017.

- Fix: Convalida DatiCassaPrevidenziale.Natura va fatta solo quando Aliquota uguale a
  zero. Closes #36.

v0.4.1
------

Rilasciata il 14.3.2017.

- Fix: Nomi delle nazioni ISO-3166 Alpha 2 sono in Inglese. Closes #35.
- Fix: Elementi FatturaElettronicaBody sono serializzati come 'Body'. Closes #34.
- Aggiunto file .editconfig

v0.4.0
------

Rilasciata il 9.3.2017.

- Rinominata classe FatturaElettronica in Fattura.
- Rinominata classe FatturaElettronicaHeader in Header.
- Rinominata classe FatturaElettronicaBody in Body.
- Rinominata propriet� Fattura.FatturaElettronicaHeader in Fattura.Header.
- Rinominata propriet� Fattura.FatturaElettronicaBody in Fattura.Body.
- Alcune classi spostate da FatturaElettronica.Common a FatturaElettronica.Tabelle
- Classe BusinessObjects.BusinessObjectBase rinominata FatturaElettronica.BaseClass.
- Classe BusinessObjects.BusinessObject rinominata FatturaElettronica.BaseClassSerializable.
- Classe FatturaElettronica.Common.BusinessObject eliminata.
- Persa dipendenza dal package BusinessObjects.
- Acquisita dipendenza dal package FluentValidation.
- Aggiunto namespace FatturaElettronica.Validators.
- Aggiunta serie di classi dedicate alla convalida (FatturaValidator; HeaderValidator; ecc.)
- Rimosso metodo IsValid(). Al suo posto usare propriet� ValidationResult.IsValid.
- Rimossa propriet� Error. Al suo posto usare ValidationFailure.Errors.
- Nuovo extension method Fattura.Validate(). Equivalente a FatturaValidator.Validate() (shortcut).
- Consultare il README per esempi di codice aggiornati.

v0.3.7
------

Rilasciata il 7.3.2017.

- Fix: Errore in convalida del campo Riferimento Testo: sono consentiti fino
  a 60 caratteri. Closes #33.

v0.3.6
------

Rilasciata il 10.2.2017.

- Aggiunto supporto per .NET Core.
- Abbandonato supporto per .NET Framework 4.0 e Silverlight.
- Fix: Falso negativo (errore 423) in convalida DettaglioLinee. Closes #31.
- Fix: Correzione messaggio di errore per Divisa non corretta (Fabio Calvigioni).

v0.3.5
------

Rilasciata il 2.2.2017.

- Fix: Crash con ScontoMaggiorazione.Importo non impostato (null). Closes #28.

v0.3.4
------

Rilasciata il 1.2.2017.

- Fix: Crash quando ScontoMaggiorazione.Importo ha valore negativo. Closes #27.

v0.3.3
------

Rilasciata il 18.1.2017.

- Fix: Consenti serializzazione di valori numerici fino a 5 decimali (minimo 2).
- Fix: Arrotonda valori numerici fino a 5 decimali (minimo 2).

v0.3.2
------

Rilasciata il 17.1.2017.

- Fix: Convalida errore 00415. Se almeno un DatiCassaPrevidenziale ha Ritenuta = "SI", allora DatiRitenuta deve essere valorizzato. Closes #22.
- Fix: Convalida errore 00411. Se almeno un DettaglioLinee ha Ritenuta = "SI", allora DatiRitenuta deve essere valorizzato. Closes #22.
- Fix: Convalida errore 00423 nel caso di campo Quantit� a null. Closes #20.

v0.3.1
------

Rilasciata il 16.1.2017.

- New: aggiunte propriet� Sigla e Sigle[] alla classe FormatoTrasmissione
- New: aggiunta propriet� Descrizione alla classe FormatoTrasmissione

v0.3
-----

Rilasciata il 13.1.2017

BREAKING CHANGES
----------------

Questa release introduce una serie di cambianti importanti che rompono la
compatibilit� con l'API precedente.

- Il package NuGet cambia nome. Ora si chiama FatturaElettronica (era FatturaElettronicaPA).
- Il namespace diventa FatturaElettronica (era FatturaElettronicaPA)
- Il package FatturaElettronicaPA verr� marcato come obsoleto su NuGet.
- Il costruttore della classe FatturaElettronica � ora protetto.
- Usare il factory method CreateInstance() per ottenere una istanza della classe.
- CreateInstance() consente di scegliere se ottenere una fattura tra soggetti privati o per la Pubblica Amministrazione.
- La fattura restituita da CreateInstance() ha gi� il campo FormatoTrasmissione correttamente impostato a FPA12 o FPR12.
- Nel caso di fattura tra privati, per default la fattura ha il CodiceDestinatario impostato a "0000000" (sar� cura del utente impostare in seguito il nuovo campo PECDestinatario o aggiornare il CodiceDestinatario col codice canale del destinatario)

Altre modifiche
---------------

- New: attributo xmlns:ds nel root elemento del documento xml.
- New: attributo xmlns:xsi nel root elemento del documento xml.
- New: attributo xsi:schemaLocation nel root elemento del documento xml.
- New: campo 1.4.4 RappresentanteFiscale.
- New: campo 1.4.3 StabileOrganizzazione.
- New: campo 1.1.6 PECDestinatario e relavite convalide.
- Fix: modificato campo 2.4.2.13 IBAN per recepire da 15 a 34 caratteri.
- Fix: aggiunto valore N7 ai campi 2.2.2.2 e 2.1.1.7.7 Natura.
- Fix: aggiunto valore MP22 al campo 2.4.2.2 ModalitaPagamento.
- Fix: campo 1.1.4 FormatoTrasmissione supporta valori FPA12 (Pubblica Amministrazione) e FPR12 (Privati)
- Fix: campo 1.1.4 CodiceDestinatario, adeguate le convalide per tenere conto del FormatoTrasmissione impostato.
- Aggiunta la test suite. Mancano test delle convalide implementate prima della v0.3.

v0.2.6
------

Rilasciata il 13.1.2017

- Questa release serve solo a segnalare su NuGet che FatturaElettronicaPA � obsoleto.
- Scaricare e installare il package FatturaElettronica v0.3 e successivi da ora in poi.

v0.2.5
------

Rilasciata il 17.6.2016

- Fix: PrezzoTotale ora prevede tolleranza "accettabile" su seconda cifra
  decimale. Closes #19.

v0.2.4
------

Rilasciata il 25.5.2016

- Fix: Validazione 00423: calcolo in base a percentuale sconto. Closes #18.

v0.2.3
------

Rilasciata il 24.5.2016

- Fix: Serializzare valori decimali con piu' di 2 decimali.

v0.2.2
------

Rilasciata il 24.5.2016

- New: Errore 00400 aggiunto alla convalida.
- New: Errore 00401 aggiunto alla convalida.
- Fix: Errore 00424 non consente aliquota IVA impostata al valore 1.

v0.2.1
------

Rilasciata il 23.5.2016

- New: Errore 00422, aggiunta tolleranza di 1 Euro come da specifiche PA
  aggiornate.

v0.2
----

Rilasciata il 20.5.2016

- New: Errore 00418 aggiunto alla convalida. Addresses #16.
- New: Errore 00419 aggiunto alla convalida. Addresses #16.
- New: Errore 00420 aggiunto alla convalida. Addresses #16.
- New: Errore 00421 aggiunto alla convalida. Addresses #16.
- New: Errore 00422 aggiunto alla convalida. Addresses #16.
- New: Errore 00423 aggiunto alla convalida. Closes #17. Addresses #16.
- New: Errore 00424 aggiunto alla convalida. Addresses #16.
- New: Errore 00425 aggiunto alla convalida. Addresses #16.

v0.1.8
------

Rilasciata il 24.8.2015

- Fix: 2.1.8.3 RiferimentoNumeroLinea in deserializzazione manda applicazione in loop. Closes #14.

v0.1.7
------

Rilasciata il 7.8.2015

- Fix: 2.1.9.4 NumeroColli in deserializzazione si ha errore conversione Nullable. Closes #12.
- Fix: 2.4.2.4 GiorniTerminiPagamento in deserializzazione si ha errore conversione Nullable. Closes #12.
- Upgrade to BusinessObjects v0.1.4

v0.1.6
------

Rilasciata il 31.7.2015

- Upgrade to BusinessObjects v0.1.3
- New: Convalida per 2.1.1.11 Causale.
- Fix: 2.1.2.1 RiferimentoNumeroLinea non gestito come lista 0..N, ma come valore singolo.
- Fix: 2.1.2.1 RiferimentoNumeroLinea in deserializzazione si ha errore conversione Nullable. Closes #9.
- Fix: 2.1.1.11 Causale. Se sono presenti 2+ righe allora il codice va in loop. Closes #8.
- Fix: Crash in deserializzazione di tag XML vuoti (es: `<ContattiTrasmittente />`). Closes #7.
- Fix: 2.1.9.13 DataOraConsegna serializza a MinValue quando non valorizzato. Closes #10.
- Fix: 2.2.1.16.4 RiferimentoData serializza a MinValue quando non valorizzato.
- Fix: 2.4.2.5 DataScadenzaPagamento serializza a MinValue quando non valorizzato. Closes #10.
- Fix: 2.4.2.18 DataLimitePagamentoAnticipato � di tipo errato (decimal? invece di DateTime?).

v0.1.5
------

Rilasciata il 15.7.2015

- Fix: 2.2.1.10.1 ScontoMaggiorazione.Tipo: convalida valori corretti SC e MG.
- Fix: 2.4.2.2 ModalitaPagamento: non veniva convalidato valore MP05.

v0.1.4
------

Rilasciata il 14.7.2015

- Upgrade to BusinessObject v0.1.2
- Fix: Convalida di FatturaElettronicaBody. Chiude #4.

v0.1.3
------

Rilasciata il 7.4.2015

- Upgrade to BusinessObject v0.1.1
- Upgrade to Json.NET v6.0.8
- Fix: ReadXML crash su valori Decimal?

v0.1.2
------

Rilasciata il 16.2.2015

- Supporto per valori L1, M1, O1, V1 per DatiRitenuta.CausalePagamento.
- Risolto problema col validatore di DatiRitenuta.CausalePagamento.
- Supporto per valore RF19 per campo RegimeFiscale.

v0.1.1
------

Rilasciata il 16.2.2015

- Supporto per Split Payment.

v0.1
----

Rilasciata il 9.2.2015

- Release iniziale.
