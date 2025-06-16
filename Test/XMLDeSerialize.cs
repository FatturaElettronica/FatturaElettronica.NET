using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Xml;
using FatturaElettronica.Defaults;
using FatturaElettronica.Extensions;
using FatturaElettronica.Ordinaria;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test
{
    [TestClass]
    public class XMLDeSerialize
    {
        [TestMethod]
        public void SerializePrivatiHeader()
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);

            Assert.IsNull(f.SistemaEmittente);
            SerializeAndAssertRootElementAttributes(f);

            f.SistemaEmittente = "sistema emittente";
            SerializeAndAssertRootElementAttributes(f);
        }

        [TestMethod]
        public void SerializePubblicaAmministrazioneHeader()
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.PubblicaAmministrazione);

            Assert.IsNull(f.SistemaEmittente);
            SerializeAndAssertRootElementAttributes(f);

            f.SistemaEmittente = "sistema emittente";
            SerializeAndAssertRootElementAttributes(f);
        }

        [TestMethod]
        public void DeserializeAndThenSerializeOfficialPASample()
        {
            // Deserialize from an official example file 
            // (downloaded from http://www.fatturapa.gov.it/export/fatturazione/it/normativa/f-2.htm)
            DeserializeAndThenSerialize("Samples/IT01234567890_FPA02.xml", FormatoTrasmissione.PubblicaAmministrazione);
        }

        [TestMethod]
        public void DeserializeAndThenSerializeOfficialPRSample()
        {
            // Deserialize from an official example file 
            // (downloaded from http://www.fatturapa.gov.it/export/fatturazione/it/normativa/f-2.htm)
            DeserializeAndThenSerialize("Samples/IT01234567890_FPR02.xml", FormatoTrasmissione.Privati);
        }

        [TestMethod]
        public void DeserializeShouldRewindStreams()
        {
            using var signedStream = new FileStream("Samples/IT02182030391_31.xml.p7m", FileMode.Open, FileAccess.Read);
            signedStream.Position = 283; //Assumption is reading would fail if the stream were not rewound
            var invoice = FatturaBase.CreateInstanceFromXml(signedStream, false);
            Assert.IsTrue(invoice.Validate().IsValid && invoice.GetFormatoTrasmissione() == FormatoTrasmissione.Privati);
        
            using var baseEncodedStream = new FileStream("Samples/IT02182030391_31.Base64.xml.p7m", FileMode.Open, FileAccess.Read);
            baseEncodedStream.Position = 283;//Assumption is reading would fail if the stream were not rewound
            var baseEncodedInvoice = FatturaBase.CreateInstanceFromXml(baseEncodedStream, false);
            Assert.IsTrue(baseEncodedInvoice.Validate().IsValid && baseEncodedInvoice.GetFormatoTrasmissione() == FormatoTrasmissione.Privati);
        }

        [TestMethod]
        public void DeserializeAnyType()
        {
            
            var f = DeserializeAny("Samples/IT01234567890_FPA02.xml");
            Assert.IsTrue(f.Validate().IsValid &&
                          f.GetFormatoTrasmissione() == FormatoTrasmissione.PubblicaAmministrazione);
            Assert.AreEqual("abc", f.SistemaEmittente);
            
            f = DeserializeAny("Samples/IT01234567890_FPR02.xml");
            Assert.IsTrue(f.Validate().IsValid && f.GetFormatoTrasmissione() == FormatoTrasmissione.Privati);
            Assert.AreEqual("abc", f.SistemaEmittente);
            
            f = DeserializeAny("Samples/IT01234567890_FSM10.xml");
            Assert.IsTrue(f.Validate().IsValid && f.GetFormatoTrasmissione() == FormatoTrasmissione.Semplificata);
            Assert.AreEqual("abc", f.SistemaEmittente);
            
            f = DeserializeAny("Samples/IT02182030391_31.xml.p7m");
            Assert.IsTrue(f.Validate().IsValid && f.GetFormatoTrasmissione() == FormatoTrasmissione.Privati);
            f = DeserializeAny("Samples/IT02182030391_31.Base64.xml.p7m");
            Assert.IsTrue(f.Validate().IsValid && f.GetFormatoTrasmissione() == FormatoTrasmissione.Privati);
        }

        private void DeserializeAndThenSerialize(string filename, string expectedFormat)
        {
            var f = Deserialize(filename);

            Assert.IsTrue(f.Validate().IsValid);
            ValidateInvoice(f, expectedFormat);

            // Serialize it back to disk, to another file
            using (var w = XmlWriter.Create("challenge.xml", new() {Indent = true}))
            {
                f.WriteXml(w);
            }

            // Deserialize the new file and validate it
            var f2 = Deserialize("challenge.xml");

            Assert.IsTrue(f2.Validate().IsValid);
            ValidateInvoice(f2, expectedFormat);

            File.Delete("challenge.xml");
        }

        private FatturaOrdinaria Deserialize(string fileName)
        {
            var f = FatturaOrdinaria.CreateInstance(Instance.Privati);
            using (var r = XmlReader.Create(fileName, new() {IgnoreWhitespace = true}))
            {
                f.ReadXml(r);
            }

            return f;
        }

        private FatturaBase DeserializeAny(string fileName)
        {
            using var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            return FatturaBase.CreateInstanceFromXml(fileStream);
        }

        private void ValidateInvoice(FatturaOrdinaria f, string expectedFormat)
        {
            var header = f.FatturaElettronicaHeader;

            // DatiTrasmissione
            Assert.AreEqual("00001", header.DatiTrasmissione.ProgressivoInvio);
            Assert.AreEqual((expectedFormat == FormatoTrasmissione.Privati) ? "0000000" : "AAAAAA",
                header.DatiTrasmissione.CodiceDestinatario);

            Assert.AreEqual("IT", header.DatiTrasmissione.IdTrasmittente.IdPaese);
            Assert.AreEqual("01234567890", header.DatiTrasmissione.IdTrasmittente.IdCodice);
            Assert.AreEqual((expectedFormat == FormatoTrasmissione.Privati) ? "betagamma@pec.it" : null,
                header.DatiTrasmissione.PECDestinatario);

            // CedentePrestatore
            Assert.AreEqual("IT", header.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdPaese);
            Assert.AreEqual("01234567890", header.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice);
            Assert.AreEqual("SOCIETA' ALPHA SRL", header.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione);
            Assert.AreEqual("Titolo", header.CedentePrestatore.DatiAnagrafici.Anagrafica.Titolo);
            Assert.AreEqual("RF01", header.CedentePrestatore.DatiAnagrafici.RegimeFiscale);
            Assert.AreEqual("VIALE ROMA 543", header.CedentePrestatore.Sede.Indirizzo);
            Assert.AreEqual("07100", header.CedentePrestatore.Sede.CAP);
            Assert.AreEqual("SASSARI", header.CedentePrestatore.Sede.Comune);
            Assert.AreEqual("IT", header.CedentePrestatore.Sede.Nazione);
            // CessionarioCommittente
            Assert.AreEqual("09876543210", header.CessionarioCommittente.DatiAnagrafici.CodiceFiscale);
            Assert.AreEqual((expectedFormat == FormatoTrasmissione.Privati) ? "BETA GAMMA" : "AMMINISTRAZIONE BETA",
                header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Denominazione);
            Assert.AreEqual("Titolo", header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Titolo);
            Assert.AreEqual("VIA TORINO 38-B", header.CessionarioCommittente.Sede.Indirizzo);
            Assert.AreEqual("00145", header.CessionarioCommittente.Sede.CAP);
            Assert.AreEqual("ROMA", header.CessionarioCommittente.Sede.Comune);
            Assert.AreEqual("RM", header.CessionarioCommittente.Sede.Provincia);
            Assert.AreEqual("IT", header.CessionarioCommittente.Sede.Nazione);

            var body = f.FatturaElettronicaBody[0];
            // DatiGeneraliDocumento
            Assert.AreEqual("TD01", body.DatiGenerali.DatiGeneraliDocumento.TipoDocumento);
            Assert.AreEqual("EUR", body.DatiGenerali.DatiGeneraliDocumento.Divisa);
            Assert.AreEqual(new(2014, 12, 18), body.DatiGenerali.DatiGeneraliDocumento.Data);
            Assert.AreEqual("123", body.DatiGenerali.DatiGeneraliDocumento.Numero);
            Assert.AreEqual(
                "LA FATTURA FA RIFERIMENTO AD UNA OPERAZIONE AAAA BBBBBBBBBBBBBBBBBB CCC DDDDDDDDDDDDDDD E FFFFFFFFFFFFFFFFFFFF GGGGGGGGGG HHHHHHH II LLLLLLLLLLLLLLLLL MMM NNNNN OO PPPPPPPPPPP QQQQ RRRR SSSSSSSSSSSSSS",
                body.DatiGenerali.DatiGeneraliDocumento.Causale[0]);
            Assert.AreEqual(
                "SEGUE DESCRIZIONE CAUSALE NEL CASO IN CUI NON SIANO STATI SUFFICIENTI 200 CARATTERI AAAAAAAAAAA BBBBBBBBBBBBBBBBB",
                body.DatiGenerali.DatiGeneraliDocumento.Causale[1]);
            // DatiOrdineAcquisto
            Assert.AreEqual(1, body.DatiGenerali.DatiOrdineAcquisto[0].RiferimentoNumeroLinea[0]);
            Assert.AreEqual("66685", body.DatiGenerali.DatiOrdineAcquisto[0].IdDocumento);
            Assert.AreEqual("1", body.DatiGenerali.DatiOrdineAcquisto[0].NumItem);

            if (expectedFormat == FormatoTrasmissione.PubblicaAmministrazione)
            {
                Assert.AreEqual("123abc", body.DatiGenerali.DatiOrdineAcquisto[0].CodiceCUP);
                Assert.AreEqual("456def", body.DatiGenerali.DatiOrdineAcquisto[0].CodiceCIG);
                // DatiContratto
                Assert.AreEqual(1, body.DatiGenerali.DatiContratto[0].RiferimentoNumeroLinea[0]);
                Assert.AreEqual("123", body.DatiGenerali.DatiContratto[0].IdDocumento);
                Assert.AreEqual(new(2016, 9, 1), body.DatiGenerali.DatiContratto[0].Data.Value);
                Assert.AreEqual("5", body.DatiGenerali.DatiContratto[0].NumItem);
                Assert.AreEqual("123abc", body.DatiGenerali.DatiContratto[0].CodiceCUP);
                Assert.AreEqual("456def", body.DatiGenerali.DatiContratto[0].CodiceCIG);
                // DatiConvenzione
                Assert.AreEqual(1, body.DatiGenerali.DatiConvenzione[0].RiferimentoNumeroLinea[0]);
                Assert.AreEqual("456", body.DatiGenerali.DatiConvenzione[0].IdDocumento);
                Assert.AreEqual("5", body.DatiGenerali.DatiConvenzione[0].NumItem);
                Assert.AreEqual("123abc", body.DatiGenerali.DatiConvenzione[0].CodiceCUP);
                Assert.AreEqual("456def", body.DatiGenerali.DatiConvenzione[0].CodiceCIG);
                // DatiRicezione
                Assert.AreEqual(1, body.DatiGenerali.DatiRicezione[0].RiferimentoNumeroLinea[0]);
                Assert.AreEqual("789", body.DatiGenerali.DatiRicezione[0].IdDocumento);
                Assert.AreEqual("5", body.DatiGenerali.DatiRicezione[0].NumItem);
                Assert.AreEqual("123abc", body.DatiGenerali.DatiRicezione[0].CodiceCUP);
                Assert.AreEqual("456def", body.DatiGenerali.DatiRicezione[0].CodiceCIG);
            }

            // DatiAnagraficiVettore
            Assert.AreEqual("IT", body.DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.IdFiscaleIVA.IdPaese);
            Assert.AreEqual("24681012141", body.DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.IdFiscaleIVA.IdCodice);
            Assert.AreEqual("Trasporto spa",
                body.DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.Denominazione);
            // DataOraConsegna
            Assert.AreEqual(new DateTime(2012, 10, 22, 16, 46, 12), body.DatiGenerali.DatiTrasporto.DataOraConsegna);
            // DatiBeniServizi
            Assert.AreEqual(1, body.DatiBeniServizi.DettaglioLinee[0].NumeroLinea);
            Assert.AreEqual(
                "LA DESCRIZIONE DELLA FORNITURA PUO' SUPERARE I CENTO CARATTERI CHE RAPPRESENTAVANO IL PRECEDENTE LIMITE DIMENSIONALE. TALE LIMITE NELLA NUOVA VERSIONE E' STATO PORTATO A MILLE CARATTERI",
                body.DatiBeniServizi.DettaglioLinee[0].Descrizione);
            Assert.AreEqual(5m, body.DatiBeniServizi.DettaglioLinee[0].Quantita);
            Assert.AreEqual(1m, body.DatiBeniServizi.DettaglioLinee[0].PrezzoUnitario);
            Assert.AreEqual(5m, body.DatiBeniServizi.DettaglioLinee[0].PrezzoTotale);
            Assert.AreEqual(22m, body.DatiBeniServizi.DettaglioLinee[0].AliquotaIVA);
            Assert.AreEqual(2, body.DatiBeniServizi.DettaglioLinee[1].NumeroLinea);
            Assert.AreEqual("FORNITURE VARIE PER UFFICIO", body.DatiBeniServizi.DettaglioLinee[1].Descrizione);
            Assert.AreEqual(10m, body.DatiBeniServizi.DettaglioLinee[1].Quantita);
            Assert.AreEqual(2m, body.DatiBeniServizi.DettaglioLinee[1].PrezzoUnitario);
            Assert.AreEqual(20m, body.DatiBeniServizi.DettaglioLinee[1].PrezzoTotale);
            Assert.AreEqual(22m, body.DatiBeniServizi.DettaglioLinee[1].AliquotaIVA);
            Assert.AreEqual(3, body.DatiBeniServizi.DettaglioLinee[2].NumeroLinea);
            Assert.AreEqual("TUBI RITORNO GASOLIO", body.DatiBeniServizi.DettaglioLinee[2].Descrizione);
            Assert.AreEqual(2m, body.DatiBeniServizi.DettaglioLinee[2].Quantita);
            Assert.AreEqual(5m, body.DatiBeniServizi.DettaglioLinee[2].PrezzoUnitario);
            Assert.AreEqual(6.58m, body.DatiBeniServizi.DettaglioLinee[2].PrezzoTotale);
            Assert.AreEqual(22m, body.DatiBeniServizi.DettaglioLinee[2].AliquotaIVA);
            Assert.AreEqual("SC", body.DatiBeniServizi.DettaglioLinee[2].ScontoMaggiorazione[0].Tipo);
            Assert.AreEqual(-1.71m, body.DatiBeniServizi.DettaglioLinee[2].ScontoMaggiorazione[0].Importo);
            Assert.AreEqual("TUBI RITORNO GASOLIO", body.DatiBeniServizi.DettaglioLinee[2].Descrizione);
            Assert.AreEqual(1m, body.DatiBeniServizi.DettaglioLinee[3].Quantita);
            Assert.AreEqual(5m, body.DatiBeniServizi.DettaglioLinee[3].PrezzoUnitario);
            Assert.AreEqual(4.5m, body.DatiBeniServizi.DettaglioLinee[3].PrezzoTotale);
            Assert.AreEqual(22m, body.DatiBeniServizi.DettaglioLinee[3].AliquotaIVA);
            Assert.AreEqual("SC", body.DatiBeniServizi.DettaglioLinee[3].ScontoMaggiorazione[0].Tipo);
            Assert.AreEqual(10.0m, body.DatiBeniServizi.DettaglioLinee[3].ScontoMaggiorazione[0].Percentuale);
            // DatiRiepilogo
            Assert.AreEqual(22m, body.DatiBeniServizi.DatiRiepilogo[0].AliquotaIVA);
            Assert.AreEqual(36.08m, body.DatiBeniServizi.DatiRiepilogo[0].ImponibileImporto);
            Assert.AreEqual(7.94m, body.DatiBeniServizi.DatiRiepilogo[0].Imposta);
            Assert.AreEqual("D", body.DatiBeniServizi.DatiRiepilogo[0].EsigibilitaIVA);
            // DatiPagamento
            Assert.AreEqual("TP01", body.DatiPagamento[0].CondizioniPagamento);
            Assert.AreEqual("MP01", body.DatiPagamento[0].DettaglioPagamento[0].ModalitaPagamento);
            Assert.AreEqual(new(2015, 01, 30),
                body.DatiPagamento[0].DettaglioPagamento[0].DataScadenzaPagamento.Value);
            Assert.AreEqual(36.08m, body.DatiPagamento[0].DettaglioPagamento[0].ImportoPagamento);
        }

        private void SerializeAndAssertRootElementAttributes(FatturaBase f)
        {
            using (var w = XmlWriter.Create("test", new() {Indent = true}))
            {
                f.WriteXml(w);
            }

            using (var r = XmlReader.Create("test"))
            {
                while (r.Read())
                {
                    if (r.NodeType != XmlNodeType.Element) continue;
                    if (r.Prefix != RootElement.Prefix || r.LocalName != "FatturaElettronica") continue;

                    Assert.AreEqual(
                        ((FatturaOrdinaria) f).FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione,
                        r.GetAttribute("versione"));
                    Assert.AreEqual(f.SistemaEmittente, r.GetAttribute("SistemaEmittente"));
                    Assert.AreEqual("http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2", r.NamespaceURI);
                    foreach (var a in RootElement.ExtraAttributes)
                    {
                        Assert.AreEqual(a.value, r.GetAttribute($"{a.Prefix}:{a.LocalName}"));
                    }

                    break;
                }
            }

            File.Delete("test");
        }
    }
}