using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class EsigibilitaIVA : Tabella<EsigibilitaIVA>
    {
        protected override ResourceManager ResourceManager => Resources.EsigibilitaIVA.ResourceManager;
    }
}
