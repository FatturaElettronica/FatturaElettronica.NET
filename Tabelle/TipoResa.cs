namespace FatturaElettronica.Tabelle
{
    public class TipoResa : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                // TODO: add appropriate values for Nome
                return new Tabella[] {
                    new TipoResa{ Codice = "EXW", Nome = string.Empty },
                    new TipoResa{ Codice = "FCA", Nome = string.Empty },
                    new TipoResa{ Codice = "FAS", Nome = string.Empty },
                    new TipoResa{ Codice = "FOB", Nome = string.Empty },
                    new TipoResa{ Codice = "CFR", Nome = string.Empty },
                    new TipoResa{ Codice = "CIF", Nome = string.Empty },
                    new TipoResa{ Codice = "CPT", Nome = string.Empty },
                    new TipoResa{ Codice = "CIP", Nome = string.Empty },
                    new TipoResa{ Codice = "DAT", Nome = string.Empty },
                    new TipoResa{ Codice = "DAP", Nome = string.Empty },
                    new TipoResa{ Codice = "DDP", Nome = string.Empty },                   
                };
            } 
        }
    }
}
