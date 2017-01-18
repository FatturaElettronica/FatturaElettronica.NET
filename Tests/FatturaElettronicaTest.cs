using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;
using FatturaElettronica.Impostazioni;
using System;

namespace Tests
{
    [TestClass]
    public class FatturaElettronicaTest
    {
        [TestMethod]
        public void CreateInstancePubblicaAmministrazione()
        {
            var f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.PubblicaAmministrazione);
            Assert.AreEqual(FormatoTrasmissione.PubblicaAmministrazione, f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
        }
        [TestMethod]
        public void CreateInstancePrivati()
        {
            var f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.Privati);
            Assert.AreEqual(FormatoTrasmissione.Privati, f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione);
            Assert.AreEqual(new string('0', 7), f.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario);
        }

        [TestMethod]
        public void ValidateFormatoTrasmissione()
        {
            var f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.Privati);
            f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione = "test";
            Assert.IsTrue(f.Error.Contains("DatiTrasmissione.FormatoTrasmissione"));
            Assert.IsTrue(f.Error.Contains(FormatoTrasmissione.Privati));
            f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione =FormatoTrasmissione.Privati;
            Assert.IsFalse(f.Error.Contains("DatiTrasmissione.FormatoTrasmissione"));

            f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.PubblicaAmministrazione);
            f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione = "test";
            Assert.IsTrue(f.Error.Contains("DatiTrasmissione.FormatoTrasmissione"));
            Assert.IsTrue(f.Error.Contains(FormatoTrasmissione.PubblicaAmministrazione));
            f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione = FormatoTrasmissione.PubblicaAmministrazione;
            Assert.IsFalse(f.Error.Contains("DatiTrasmissione.FormatoTrasmissione"));
        }

        [TestMethod]
        public void ValidateCodiceDestinatario()
        {
            var f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.Privati);

            // CodiceDestinatario è obbligatorio
            Assert.IsTrue(f.Error.Contains("CodiceDestinatario"));

            // Nelle fatture tra privati CodiceDestinatario deve essere 7 caratteri.
            f.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario = "123456";
            Assert.IsTrue(f.Error.Contains("CodiceDestinatario"));
            f.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario = "12345678";
            Assert.IsTrue(f.Error.Contains("CodiceDestinatario"));
            f.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario = "1234567";
            Assert.IsFalse(f.Error.Contains("CodiceDestinatario"));

            f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.PubblicaAmministrazione);

            // CodiceDestinatario è obbligatorio
            Assert.IsTrue(f.Error.Contains("CodiceDestinatario"));

            // Nelle fatture PA CodiceDestinatario deve essere 6 caratteri.
            f.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario = "12345";
            Assert.IsTrue(f.Error.Contains("CodiceDestinatario"));
            f.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario = "1234567";
            Assert.IsTrue(f.Error.Contains("CodiceDestinatario"));
            f.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario = "123456";
            Assert.IsFalse(f.Error.Contains("CodiceDestinatario"));

        }


        [TestMethod]
        public void ValidatePECDestinatario()
        {
            var f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.Privati);

            // Nelle fatture tra privati, poiché il default per CodiceDestinatario è 0000000,
            // è necessario impostare un valore per PECDestinatario.
            Assert.IsTrue(f.Error.Contains("PECDestinatario"));

            // PECDestinatario deve essere tra 7 e 256 caratteri.
            f.FatturaElettronicaHeader.DatiTrasmissione.PECDestinatario = "123456";
            Assert.IsTrue(f.Error.Contains("PECDestinatario"));
            f.FatturaElettronicaHeader.DatiTrasmissione.PECDestinatario = new string('n', 257);
            Assert.IsTrue(f.Error.Contains("PECDestinatario"));
            f.FatturaElettronicaHeader.DatiTrasmissione.PECDestinatario = "1234567";
            Assert.IsFalse(f.Error.Contains("PECDestinatario"));

            // Se CodiceDestinatario è diverso da 0000000, allora PECDestinatario non deve essere
            // valorizzato.
            f.FatturaElettronicaHeader.DatiTrasmissione.CodiceDestinatario = "test";
            Assert.IsTrue(f.Error.Contains("PECDestinatario"));
            f.FatturaElettronicaHeader.DatiTrasmissione.PECDestinatario = null;
            Assert.IsFalse(f.Error.Contains("PECDestinatario"));
        }

        [TestMethod]
        public void StabileOrganizzazione()
        {
            var f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.PubblicaAmministrazione);

            // StabileOrganizzazione è disponibile sia in CedentePrestatore...
            f.FatturaElettronicaHeader.CedentePrestatore.StabileOrganizzazione.Indirizzo = "indirizzo1";
            // ...che in CommissionarioCommittente.
            f.FatturaElettronicaHeader.CessionarioCommittente.StabileOrganizzazione.Indirizzo = "indirizzo2";

        }

        [TestMethod]
        public void CessionarioCommittenteRappresentanteFiscale()
        {
            var f = FatturaElettronica.FatturaElettronica.CreateInstance(Instance.Privati);

            f.FatturaElettronicaHeader.CessionarioCommittente.RappresentanteFiscale.Denominazione = "denominazione1";
            f.FatturaElettronicaHeader.CessionarioCommittente.RappresentanteFiscale.Nome = "Nome";
            f.FatturaElettronicaHeader.CessionarioCommittente.RappresentanteFiscale.Cognome = "Cognome";
            Assert.IsTrue(f.Error.Contains("[Denominazione, CognomeNome]"));
            f.FatturaElettronicaHeader.CessionarioCommittente.RappresentanteFiscale.Denominazione = null;
            Assert.IsFalse(f.Error.Contains("[Denominazione, CognomeNome]"));

        }

        [TestMethod]
        public void ValidateModalitàPagamento()
        {
            FatturaElettronica.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento dp;
            const int max = 22;

            for (var i=1; i<=max; i++)
            {
                dp = new FatturaElettronica.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento();
                dp.ModalitaPagamento = string.Format("MP{0}", (i<10) ? "0"+i.ToString() : i.ToString());
                Assert.IsTrue(dp.IsValid);
            }

            dp = new FatturaElettronica.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento();
            dp.ModalitaPagamento = string.Format("MP{0}", max+1);
            Assert.IsFalse(dp.IsValid);

            dp = new FatturaElettronica.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento();
            dp.ModalitaPagamento = "test";
            Assert.IsFalse(dp.IsValid);

        }

        [TestMethod]
        public void ValidateNatura()
        {
            const int max = 7;

            // DatiGenerali.DatiCassaPrevidenziale.Natura.
            FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiCassaPrevidenziale dc;
            for (var i=1; i<=max; i++)
            {
                dc = new FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiCassaPrevidenziale();
                dc.Natura = string.Format("N{0}", i.ToString());
                Assert.IsFalse(dc.Error.Contains("Natura"));
            }
            dc = new FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiCassaPrevidenziale();
            dc.Natura = string.Format("N{0}", max+1);
            Assert.IsTrue(dc.Error.Contains("Natura"));
            dc = new FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiCassaPrevidenziale();
            dc.Natura = "test";
            Assert.IsTrue(dc.Error.Contains("Natura"));

            // DatiBeniServizi.DatiRiepilogo.Natura.
            FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo dr;
            for (var i=1; i<=max; i++)
            {
                dr = new FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo();
                dr.Natura = string.Format("N{0}", i.ToString());
                Assert.IsTrue(dr.IsValid);
            }
            dr = new FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo();
            dr.Natura = string.Format("N{0}", max+1);
            Assert.IsFalse(dr.IsValid);
            dr = new FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo();
            dr.Natura = "test";
            Assert.IsFalse(dr.IsValid);

        }

        [TestMethod]
        public void ValidateIBAN()
        {
            const int min = 15;
            const int max = 34;

            FatturaElettronica.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento dp;
            for (var i=min; i<=max; i++)
            {
                dp = new FatturaElettronica.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento();
                dp.IBAN = new string('n', i);
                Assert.IsFalse(dp.Error.Contains("IBAN"));
            }
            dp = new FatturaElettronica.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento();
            dp.IBAN = new string('n', max + 1);
            Assert.IsTrue(dp.Error.Contains("IBAN"));
            dp = new FatturaElettronica.FatturaElettronicaBody.DatiPagamento.DettaglioPagamento();
            dp.IBAN = new string('n', min - 1);
            Assert.IsTrue(dp.Error.Contains("IBAN"));
        }

        [TestMethod]
        public void ValidatePrezzoTotaleConQuantitaANull()
        {
            // Testa che #20 sia risolto
            // https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/20

            var l = new FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee();
            l.PrezzoUnitario = 10;
            l.PrezzoTotale = 10;
            Assert.IsNull(l.Quantita);
            Assert.IsTrue(l.ValidateAgainstErr00423());
        }

        [TestMethod]
        public void ValidateDatiRitenutaOnDatiCassaPrevidenziale()
        {
            // Testa che #22 sia risolto
            // https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/22

            var b = new FatturaElettronica.FatturaElettronicaBody.FatturaElettronicaBody();
            var cp = new FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiCassaPrevidenziale();
            b.DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Add(cp);

            // Se non ci sono DatiCassaPrevidenziale con Ritenuta = "SI", è accettabile che DatiRitenuta non sia valorizzato.
            Assert.IsNull(cp.Ritenuta);
            Assert.IsNull(b.DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.TipoRitenuta);
            Assert.IsTrue(b.ValidateAgainstErr00415());

            // Se almeno un DatiCassaPrevidenziale ha Ritenuta = "SI", allora DatiRitenuta deve essere valorizzato.
            cp.Ritenuta = "SI";
            Assert.IsFalse(b.ValidateAgainstErr00415());

            cp.Ritenuta = null;
            Assert.IsTrue(b.ValidateAgainstErr00415());
        }

        [TestMethod]
        public void ValidateDatiRitenutaOnDettaglioLinee()
        {
            // Testa che #22 sia risolto
            // https://github.com/FatturaElettronica/FatturaElettronica.NET/issues/22

            var b = new FatturaElettronica.FatturaElettronicaBody.FatturaElettronicaBody();

            var dl = new FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee();
            b.DatiBeniServizi.DettaglioLinee.Add(dl);

            // Se non ci sono DettaglioLinee con Ritenuta = "SI", è accettabile che DatiRitenuta non sia valorizzato.
            Assert.IsNull(b.DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.TipoRitenuta);
            Assert.IsNull(dl.Ritenuta);
            Assert.IsTrue(b.ValidateAgainstErr00411());

            // Se almeno un DettaglioLinee ha Ritenuta = "SI", allora DatiRitenuta deve essere valorizzato.
            dl.Ritenuta = "SI";
            Assert.IsFalse(b.ValidateAgainstErr00411());

            dl.Ritenuta = null;
            Assert.IsTrue(b.ValidateAgainstErr00411());
        }

        [TestMethod]
        public void ArrotondamentoImportiUnitariConMoltiDecimali()
        {
            var dl = new FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee();
            dl.PrezzoUnitario = 13.4426m;
            dl.Quantita = 2;
            dl.Descrizione = "description";
            dl.PrezzoTotale = 26.89m;
            dl.AliquotaIVA = 22.0m;
            Assert.IsTrue(dl.IsValid);

            dl = new FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee();
            dl.PrezzoUnitario = 3.0246m;
            dl.Quantita = 5;
            dl.Descrizione = "description";
            dl.PrezzoTotale = 15.12m;
            dl.AliquotaIVA = 22.0m;
            Assert.IsTrue(dl.IsValid);

            dl = new FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee();
            dl.PrezzoUnitario = 5.7377m;
            dl.Quantita = 0.2m;
            dl.Descrizione = "description";
            dl.PrezzoTotale = 1.15m;
            dl.AliquotaIVA = 22.0m;
            Assert.IsTrue(dl.IsValid);

            dl = new FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee();
            dl.PrezzoUnitario = 0.0492m;
            dl.Quantita = 4;
            dl.Descrizione = "description";
            dl.PrezzoTotale = 0.20m;
            dl.AliquotaIVA = 22.0m;
            Assert.IsTrue(dl.IsValid);

            dl = new FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee();
            dl.PrezzoUnitario = 22;
            dl.Quantita = 4;
            dl.Descrizione = "description";
            dl.PrezzoTotale = 88;
            dl.AliquotaIVA = 22.0m;
            Assert.IsTrue(dl.IsValid);

            // Make sure we Round AwayFromZero (PCL has no overload for it)
            dl = new FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee();
            dl.PrezzoUnitario = 9.2425m;
            dl.Quantita = 4;
            dl.Descrizione = "description";
            dl.PrezzoTotale = 36.97m;
            dl.AliquotaIVA = 22.0m;
            Assert.IsTrue(dl.IsValid);

            dl = new FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee();
            dl.PrezzoUnitario = 12.235m;
            dl.Quantita = 1;
            dl.Descrizione = "description";
            dl.PrezzoTotale = 12.24m;
            dl.AliquotaIVA = 22.0m;
            Assert.IsTrue(dl.IsValid);
        }

    }
}
