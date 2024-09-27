using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class CausalePagamento : Tabella<CausalePagamento>
    {
        protected override ResourceManager ResourceManager => Resources.CausalePagamento.ResourceManager;
    }
}
