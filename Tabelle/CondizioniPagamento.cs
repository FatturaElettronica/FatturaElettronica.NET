using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class CondizioniPagamento : Tabella<CondizioniPagamento>
    {
        protected override ResourceManager ResourceManager => Resources.CondizioniPagamento.ResourceManager;
    }
}
