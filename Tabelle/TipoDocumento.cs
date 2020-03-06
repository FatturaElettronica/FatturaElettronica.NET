namespace FatturaElettronica.Tabelle
{
    public class TipoDocumento : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[]
                {
                    new TipoDocumento { Codice = "TD01", Nome = "Fattura" },
                    new TipoDocumento { Codice = "TD02", Nome = "Acconto/Anticipo su fattura" },
                    new TipoDocumento { Codice = "TD03", Nome = "Acconto/Anticipo su parcella" },
                    new TipoDocumento { Codice = "TD04", Nome = "Nota di Credito" },
                    new TipoDocumento { Codice = "TD05", Nome = "Nota di Debito" },
                    new TipoDocumento { Codice = "TD06", Nome = "Parcella" },
                    new TipoDocumento { Codice = "TD16", Nome = "Integrazione fattura reverse charge interno" },
                    new TipoDocumento { Codice = "TD17", Nome = "Integrazione/autofattura per acquisto servizi dall’estero" },
                    new TipoDocumento { Codice = "TD18", Nome = "Integrazione per acquisto di beni intracomunitari" },
                    new TipoDocumento { Codice = "TD19", Nome = "Integrazione/autofattura per acquisto di beni ex art.17 c.2 DPR 633/72" },
                    new TipoDocumento { Codice = "TD20", Nome = "Autofattura per regolarizzazione e integrazione delle fatture (art.6 c.8 d.lgs. 471/97 o art.46 c.5 D.L. 331/93)" },
                    new TipoDocumento { Codice = "TD21", Nome = "Autofattura per splafonamento" },
                    new TipoDocumento { Codice = "TD22", Nome = "Estrazione beni da Deposito IVA" },
                    new TipoDocumento { Codice = "TD23", Nome = "Estrazione beni da Deposito IVA con versamento dell’IVA" },
                    new TipoDocumento { Codice = "TD24", Nome = "Fattura differita di cui all’art.21, comma 4, lett. a)" },
                    new TipoDocumento { Codice = "TD25", Nome = "Fattura differita di cui all’art.21, comma 4, terzo periodo lett. b)" },
                    new TipoDocumento { Codice = "TD26", Nome = "Cessione di beni ammortizzabili e per passaggi interni (ex art.36 DPR 633/72)" },
                    new TipoDocumento { Codice = "TD27", Nome = "Fattura per autoconsumo o per cessioni gratuite senza rivalsa" }
                };

            }
        }
    }
}