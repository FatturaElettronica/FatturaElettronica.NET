namespace FatturaElettronica.Tabelle
{
    public class EsigibilitaIVA : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[]
                {
                    new EsigibilitaIVA { Codice = "I", Nome = Resources.EsigibilitaIVA.I },
                    new EsigibilitaIVA { Codice = "D", Nome = Resources.EsigibilitaIVA.D },
                    new EsigibilitaIVA { Codice = "S", Nome = Resources.EsigibilitaIVA.S },
                };
            }
        }
    }
}