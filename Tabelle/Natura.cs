namespace FatturaElettronica.Tabelle
{
    public class Natura : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                // TODO add appropriate values for Nome
                return new Tabella[] {
                    new Natura { Codice = "N1", Nome = string.Empty },
                    new Natura { Codice = "N2", Nome = string.Empty },
                    new Natura { Codice = "N3", Nome = string.Empty },
                    new Natura { Codice = "N4", Nome = string.Empty },
                    new Natura { Codice = "N5", Nome = string.Empty },
                    new Natura { Codice = "N6", Nome = string.Empty },
                    new Natura { Codice = "N7", Nome = string.Empty }
                };
            } 
        }
    }
}