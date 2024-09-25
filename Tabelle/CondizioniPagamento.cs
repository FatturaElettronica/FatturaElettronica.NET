using System.Resources;

namespace FatturaElettronica.Tabelle
{
    public class CondizioniPagamento : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[] {
                    new CondizioniPagamento { Codice = "TP01", Nome = "pagamento a rate" },
                    new CondizioniPagamento { Codice = "TP02", Nome = "pagamento completo" },
                    new CondizioniPagamento { Codice = "TP03", Nome = "anticipo" },
                };
            }
        }
    }
    
    public class CondizioniPagamentoV2 : TabellaV2<CondizioniPagamentoV2>
    {
        protected override ResourceManager ResourceManager => Resources.CondizioniPagamento.ResourceManager;
    }
}