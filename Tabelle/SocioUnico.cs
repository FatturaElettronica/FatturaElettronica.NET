using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class SocioUnico : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[]
                {
                    new SocioUnico { Codice = "SU", Nome = "Socio unico" },
                    new SocioUnico { Codice = "SM", Nome = "Più soci" }
                };
            }
        }
    }
    
    public class SocioUnicoV2 : TabellaV2<SocioUnicoV2>
    {
        protected override ResourceManager ResourceManager => Resources.SocioUnico.ResourceManager;
    }
}