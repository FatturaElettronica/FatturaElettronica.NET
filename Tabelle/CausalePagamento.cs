namespace FatturaElettronica.Tabelle
{
    public class CausalePagamento : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[] {
                    new CausalePagamento{ Codice = "A", Nome = "prestazioni di lavoro autonomo rientranti nell’esercizio di arte o professione abituale"},
                    new CausalePagamento{ Codice = "B", Nome = "utilizzazione economica, da parte dell’autore o dell’inventore, di opere dell’ingegno, di brevetti industriali e di processi, formule o informazioni relativi ad esperienze acquisite in campo industriale, commerciale o scientifico"},
                    new CausalePagamento{ Codice = "C", Nome = "utili derivanti da contratti di associazione in partecipazione e da contratti di cointeressenza, quando l’apporto è costituito esclusivamente dalla prestazione di lavoro"},
                    new CausalePagamento{ Codice = "D", Nome = "utili spettanti ai soci promotori ed ai soci fondatori delle società di capitali"},
                    new CausalePagamento{ Codice = "E", Nome = "levata di protesti cambiari da parte dei segretari comunali"},
                    new CausalePagamento{ Codice = "F", Nome = "indennità corrisposte ai giudici onorari di pace e ai vice procuratori onorari"},
                    new CausalePagamento{ Codice = "G", Nome = "indennità corrisposte per la cessazione di attività sportiva professionale"},
                    new CausalePagamento{ Codice = "H", Nome = "indennità corrisposte per la cessazione dei rapporti di agenzia delle persone fisiche e delle società di persone con esclusione delle somme maturate entro il 31 dicembre 2003, già imputate per competenza e tassate come reddito d’impresa"},
                    new CausalePagamento{ Codice = "I", Nome = "indennità corrisposte per la cessazione da funzioni notarili"},
                    new CausalePagamento{ Codice = "L", Nome = "redditi derivanti dall’utilizzazione economica di opere dell’ingegno, di brevetti industriali e di processi, formule e informazioni relativi a esperienze acquisite in campo industriale, commerciale o scientifico, che sono percepiti dagli aventi causa a titolo gratuito (ad es. eredi e legatari dell’autore e inventore)"},
                    new CausalePagamento{ Codice = "M", Nome = "prestazioni di lavoro autonomo non esercitate abitualmente"},
                    new CausalePagamento{ Codice = "N", Nome = "indennità di trasferta, rimborso forfetario di spese, premi e compensi erogati: – nell’esercizio diretto di attività sportive dilettantistiche; – in relazione a rapporti di collaborazione coordinata e continuativa di carattere amministrativo-gestionale di natura non professionale resi a favore di società e associazioni sportive dilettantistiche e di cori, bande e filodrammatiche da parte del direttore e dei collaboratori tecnici"},
                    new CausalePagamento{ Codice = "O", Nome = "prestazioni di lavoro autonomo non esercitate abitualmente, per le quali non sussiste l’obbligo di iscrizione alla gestione separata (Circ. INPS n. 104/2001)"},
                    new CausalePagamento{ Codice = "P", Nome = "compensi corrisposti a soggetti non residenti privi di stabile organizzazione per l’uso o la concessione in uso di attrezzature industriali, commerciali o scientifiche che si trovano nel territorio dello Stato ovvero a società svizzere o stabili organizzazioni di società svizzere che possiedono i requisiti di cui all’art. 15, comma 2 dell’Accordo tra la Comunità europea e la Confederazione svizzera del 26 ottobre 2004 (pubblicato in G.U.C.E. del 29 dicembre 2004 n. L385/30)"},
                    new CausalePagamento{ Codice = "Q", Nome = "provvigioni corrisposte ad agente o rappresentante di commercio monomandatario"},
                    new CausalePagamento{ Codice = "R", Nome = "provvigioni corrisposte ad agente o rappresentante di commercio plurimandatario"},
                    new CausalePagamento{ Codice = "S", Nome = "provvigioni corrisposte a commissionario"},
                    new CausalePagamento{ Codice = "T", Nome = "provvigioni corrisposte a mediatore"},
                    new CausalePagamento{ Codice = "U", Nome = "provvigioni corrisposte a procacciatore di affari"},
                    new CausalePagamento{ Codice = "V", Nome = "provvigioni corrisposte a incaricato per le vendite a domicilio; provvigioni corrisposte a incaricato per la vendita porta a porta e per la vendita ambulante di giornali quotidiani e periodici (L. 25 febbraio 1987, n. 67)"},
                    new CausalePagamento{ Codice = "W", Nome = "corrispettivi erogati nel 2017 per prestazioni relative a contratti d’appalto cui si sono resi applicabili le disposizioni contenute nell’art. 25-ter del D.P.R. n. 600 del 29 settembre 1973"},
                    new CausalePagamento{ Codice = "X", Nome = "canoni corrisposti nel 2004 da società o enti residenti ovvero da stabili organizzazioni di società estere di cui all’art. 26-quater, comma 1, lett. a) e b) del D.P.R. 600 del 29 settembre 1973, a società o stabili organizzazioni di società, situate in altro stato membro dell’Unione Europea in presenza dei requisiti di cui al citato art. 26-quater, del D.P.R. 600 del 29 settembre 1973, per i quali è stato effettuato, nell’anno 2006, il rimborso della ritenuta ai sensi dell’art. 4 del D.Lgs. 30 maggio 2005 n. 143"},
                    new CausalePagamento{ Codice = "Y", Nome = "canoni corrisposti dal 1° gennaio 2005 al 26 luglio 2005 da società o enti residenti ovvero da stabili organizzazioni di società estere di cui all’art. 26-quater, comma 1, lett. a) e b) del D.P.R. n. 600 del 29 settembre 1973, a società o stabili organizzazioni di società, situate in altro stato membro dell’Unione Europea in presenza dei requisiti di cui al citato art. 26-quater, del D.P.R. n. 600 del 29 settembre 1973, per i quali è stato effettuato, nell’anno 2006, il rimborso della ritenuta ai sensi dell’art. 4 del D.Lgs. 30 maggio 2005 n. 143"},
                    new CausalePagamento{ Codice = "L1", Nome = "redditi derivanti dall’utilizzazione economica di opere dell’ingegno, di brevetti industriali e di processi, formule e informazioni relativi a esperienze acquisite in campo industriale, commerciale o scientifico, che sono percepiti da soggetti che abbiano acquistato a titolo oneroso i diritti alla loro utilizzazione"},
                    new CausalePagamento{ Codice = "M1", Nome = "redditi derivanti dall’assunzione di obblighi di fare, di non fare o permettere"},
                    new CausalePagamento{ Codice = "M2", Nome = "prestazioni di lavoro autonomo non esercitate abitualmente per le quali sussiste l’obbligo di iscrizione alla Gestione Separata ENPAPI"},
                    new CausalePagamento{ Codice = "O1", Nome = "redditi derivanti dall’assunzione di obblighi di fare, di non fare o permettere, per le quali non sussiste l’obbligo di iscrizione alla gestione separata (Circ. INPS n. 104/2001)"},
                    new CausalePagamento{ Codice = "V1", Nome = "redditi derivanti da attività commerciali non esercitate abitualmente (ad esempio, provvigioni corrisposte per prestazioni occasionali ad agente o rappresentante di commercio, mediatore, procacciatore d’affari)"},
                    new CausalePagamento{ Codice = "ZO", Nome = "titolo diverso dai precedenti"},
                };
            }
        }
    }
}