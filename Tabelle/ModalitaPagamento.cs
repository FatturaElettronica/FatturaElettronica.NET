namespace FatturaElettronica.Tabelle
{
    public class ModalitaPagamento : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[] {
                    new ModalitaPagamento { Codice = "MP01", Nome = "contanti" },
                    new ModalitaPagamento { Codice = "MP02", Nome = "assegno" },
                    new ModalitaPagamento { Codice = "MP03", Nome = "assegno circolare" },
                    new ModalitaPagamento { Codice = "MP04", Nome = "contanti presso Tesoreria" },
                    new ModalitaPagamento { Codice = "MP05", Nome = "bonifico" },
                    new ModalitaPagamento { Codice = "MP06", Nome = "vaglia cambiario" },
                    new ModalitaPagamento { Codice = "MP07", Nome = "bollettino bancario" },
                    new ModalitaPagamento { Codice = "MP08", Nome = "carta di pagamento" },
                    new ModalitaPagamento { Codice = "MP09", Nome = "RID" },
                    new ModalitaPagamento { Codice = "MP10", Nome = "RID utenze" },
                    new ModalitaPagamento { Codice = "MP11", Nome = "RID veloce" },
                    new ModalitaPagamento { Codice = "MP12", Nome = "RIBA" },
                    new ModalitaPagamento { Codice = "MP13", Nome = "MAV" },
                    new ModalitaPagamento { Codice = "MP14", Nome = "quietanza erario" },
                    new ModalitaPagamento { Codice = "MP15", Nome = "giroconto su conti di contabilità speciale" },
                    new ModalitaPagamento { Codice = "MP16", Nome = "domiciliazione bancaria" },
                    new ModalitaPagamento { Codice = "MP17", Nome = "domiciliazione postale" },
                    new ModalitaPagamento { Codice = "MP18", Nome = "bollettino di c/c postale" },
                    new ModalitaPagamento { Codice = "MP19", Nome = "SEPA Direct Debit" },
                    new ModalitaPagamento { Codice = "MP20", Nome = "SEPA Direct Debit CORE" },
                    new ModalitaPagamento { Codice = "MP21", Nome = "SEPA Direct Debit B2B" },
                    new ModalitaPagamento { Codice = "MP22", Nome = "Trattenuta su somme già riscosse" }
                };
            }
        }
    }
}