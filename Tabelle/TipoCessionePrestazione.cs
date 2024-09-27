using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class TipoCessionePrestazione : Tabella<TipoCessionePrestazione>
    {
        protected override ResourceManager ResourceManager => Resources.TipoCessionePrestazione.ResourceManager;
    }
}
