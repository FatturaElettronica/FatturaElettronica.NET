namespace FatturaElettronica.Tabelle
{
    public class TipoDocumentoSemplificata : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[]
                {
                    new TipoDocumentoSemplificata { Codice = "TD07", Nome = "fattura semplificata" },
                    new TipoDocumentoSemplificata { Codice = "TD08", Nome = "nota di credito semplificata" },
                    new TipoDocumentoSemplificata { Codice = "TD09", Nome = "nota di debito semplificata" },
                };

            }
        }
    }
}