namespace FatturaElettronica.Tabelle
{
    public class StatoLiquidazione : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[] {
                    new StatoLiquidazione { Codice = "LS", Nome = "In liquidazione" },
                    new StatoLiquidazione { Codice = "LN", Nome = "Non in liquidazione" }
                };
            }
        }
    }
}