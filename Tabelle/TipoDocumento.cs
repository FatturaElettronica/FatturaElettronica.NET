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
                    new TipoDocumento { Codice = "TD06", Nome = "parcella" }
                };

            }
        }
    }
}