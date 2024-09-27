using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class ModalitaPagamento : Tabella<ModalitaPagamento>
    {
        protected override ResourceManager ResourceManager => Resources.ModalitaPagamento.ResourceManager;
    }
}
