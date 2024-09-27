using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class StatoLiquidazione : Tabella<StatoLiquidazione>
    {
        protected override ResourceManager ResourceManager => Resources.StatoLiquidazione.ResourceManager;
    }
}
