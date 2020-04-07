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
                    new TipoDocumento { Codice = "TD01", Nome = "fattura" },
                    new TipoDocumento { Codice = "TD02", Nome = "acconto/anticipo su fattura" },
                    new TipoDocumento { Codice = "TD03", Nome = "acconto/anticipo su parcella" },
                    new TipoDocumento { Codice = "TD04", Nome = "nota di credito" },
                    new TipoDocumento { Codice = "TD05", Nome = "nota di debito" },
                    new TipoDocumento { Codice = "TD06", Nome = "parcella" },
                    new TipoDocumento { Codice = "TD16", Nome = "integrazione fattura reverse charge interno" },
                    new TipoDocumento { Codice = "TD17", Nome = "integrazione/autofattura per acquisto servizi dall'estero" },
                    new TipoDocumento { Codice = "TD18", Nome = "integrazione per acquisto di beni intracomunitari" },
                    new TipoDocumento { Codice = "TD19", Nome = "integrazione/autofattura per acquisto di beni ex art. 17 c.2 DPR 633/72" },
                    new TipoDocumento { Codice = "TD20", Nome = "autofattura per regolarizzazione e integrazione delle fatture (ex art.6 c.8 d.lgs. 471/97  o  art.46 c.5 D.L. 331/93)" },
                    new TipoDocumento { Codice = "TD21", Nome = "autofattura per splafonamento" },
                    new TipoDocumento { Codice = "TD22", Nome = "estrazione beni da Deposito IVA" },
                    new TipoDocumento { Codice = "TD23", Nome = "estrazione beni da Deposito IVA con versamento dell'IVA" },
                    new TipoDocumento { Codice = "TD24", Nome = "fattura differita di cui all'art. 21, comma 4, lett. a)" },
                    new TipoDocumento { Codice = "TD25", Nome = "fattura differita di cui all'art. 21, comma 4, terzo periodo lett. b)" },
                    new TipoDocumento { Codice = "TD26", Nome = "cessione di beni ammortizzabili e per passaggi interni (ex art.36 DPR 633/72)" },
                    new TipoDocumento { Codice = "TD27", Nome = "fattura per autoconsumo o per cessioni gratuite senza rivalsa" },
                };

            }
        }
    }
}