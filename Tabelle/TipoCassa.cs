using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class TipoCassa : Tabella<TipoCassa>
    {
        protected override ResourceManager ResourceManager => Resources.TipoCassa.ResourceManager;
    }
}
