# Fattura Elettronica per la Pubblica Amministrazione

## Features
- Lettura e scrittura nel [formato standard v1.0 PA][pa] (XML).
- Convalida in osservanza delle specifiche tecniche ufficiali.
- Supporto per la serializzazione in formato JSON

## Portable Class Library
La libreria gira senza modifiche sui seguenti ambienti:

- .NET Framework 4.0 e superiori,
- Xamarin.iOS
- Xamarin.Android
- Windows Phone 8
- Windows Store apps (Windows 8)
- Silverlight 5.0

Un file .snk è fornito per la firma dell'assembly, in modo che possa essere usato in contesti in cui lo *strong naming* sia necessario.

## Dipendenze
L'unica dipendenza è il progetto [BusinessObjects][bo], anch'esso reperibile su GitHub. 

## Licenza
FatturaElettronicaPA è un progetto open source [Gestionale Amica][ga] rilasciato sotto licenza [BSD][bsd].

[pa]: http://www.fatturapa.gov.it/export/fatturazione/sdi/Specifiche_tecniche_del_formato_FatturaPA_v1.0.pdf
[bo]: http://github.com/FatturaElettronicaPA/BusinessObjects 
[bsd]: http://github.com/FatturaElettronicaPA/BusinessObjects/blob/master/LICENSE
[ga]: http://gestionaleamica.com
