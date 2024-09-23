using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class EsigibilitaIVA : TabellaV2<EsigibilitaIVA>
    {
        protected override ResourceManager ResourceManager => Resources.EsigibilitaIVA.ResourceManager;
    }
}
