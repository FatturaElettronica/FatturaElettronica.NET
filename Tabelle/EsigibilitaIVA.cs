namespace FatturaElettronica.Tabelle
{
    public class EsigibilitaIVA : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[] {
                    new EsigibilitaIVA { Codice = "I", Nome = "IVA ad esigibilità immediata" },
                    new EsigibilitaIVA { Codice = "D", Nome = "IVA ad esigibilità differita" },
                    new EsigibilitaIVA { Codice = "S", Nome = "scissione dei pagamenti" },
                };
            }
        }
    }
}