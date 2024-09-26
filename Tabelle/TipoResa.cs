using System.Resources;

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
                    new TipoResa{ Codice = "CFR", Nome = "Costo e Nolo" },
                    new TipoResa{ Codice = "CIF", Nome = "Costo, assicurazione e nolo" },
                    new TipoResa{ Codice = "CPT", Nome = "Trasporto pagato fino a" },
                    new TipoResa{ Codice = "CIP", Nome = "Trasporto e assicurazione pagati fino a" },
                    new TipoResa{ Codice = "DPU", Nome = "Reso al luogo di destinazione scaricato" },
                    new TipoResa{ Codice = "DAP", Nome = "Reso a luogo di destinazione" },
                    new TipoResa{ Codice = "DDP", Nome = "Reso sdoganato" },                   
                };
            } 
        }
    }
    
    public class TipoResaV2 : TabellaV2<TipoResaV2>
    {
        protected override ResourceManager ResourceManager => Resources.TipoResa.ResourceManager;
    }
}
