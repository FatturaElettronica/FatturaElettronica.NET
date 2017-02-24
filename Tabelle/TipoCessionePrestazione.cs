namespace FatturaElettronica.Tabelle
{
    public class TipoCessionePrestazione : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[] {
                    new TipoCessionePrestazione { Codice = "SC", Nome = "sconto"},
                    new TipoCessionePrestazione { Codice = "PR", Nome = "premio"},
                    new TipoCessionePrestazione { Codice = "AB", Nome = "abbuono"},
                    new TipoCessionePrestazione { Codice = "AC", Nome = "spesa accessoria"},
                };
            } 
        }
    }
}