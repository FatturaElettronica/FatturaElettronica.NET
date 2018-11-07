namespace FatturaElettronica.Tabelle
{
    public class TipoResa : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[] {
                    new TipoResa{ Codice = "EXW", Nome = "Franco Fabbrica" },
                    new TipoResa{ Codice = "FCA", Nome = "Franco Vettore" },
                    new TipoResa{ Codice = "FAS", Nome = "Franco lungo bordo" },
                    new TipoResa{ Codice = "FOB", Nome = "Franco a bordo" },
                    new TipoResa{ Codice = "CFR", Nome = string.Empty },
                    new TipoResa{ Codice = "CIF", Nome = "Costo, assicurazione e nolo" },
                    new TipoResa{ Codice = "CPT", Nome = "Trasporto pagato fino a" },
                    new TipoResa{ Codice = "CIP", Nome = "Trasporto e assicurazione pagati fino a" },
                    new TipoResa{ Codice = "DAT", Nome = "Reso al terminal" },
                    new TipoResa{ Codice = "DAP", Nome = "Reso a luogo di destinazione" },
                    new TipoResa{ Codice = "DDP", Nome = "Reso sdoganato" },                   
                };
            } 
        }
    }
}
