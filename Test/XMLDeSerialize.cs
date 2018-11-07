using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;
using FatturaElettronica.Defaults;
using System;
using FatturaElettronica;

namespace Tests
{
    [TestClass]
    public class XMLDeSerialize
    {
        [TestMethod]
        public void SerializePrivatiHeader()
        {
            SerializeAndAssertRootElementAttributes(FatturaElettronica.Fattura.CreateInstance(Instance.Privati));
        }

        [TestMethod]
        public void SerializePubblicaAmministrazioneHeader()
        {
            SerializeAndAssertRootElementAttributes(FatturaElettronica.Fattura.CreateInstance(Instance.PubblicaAmministrazione));
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

        private void DeserializeAndThenSerialize(string filename, string expectedFormat)
        {
            var f = Deserialize(filename);

            Assert.IsTrue(f.Validate().IsValid);
            ValidateInvoice(f, expectedFormat);

            // Serialize it back to disk, to another file
            using (var w = XmlWriter.Create("challenge.xml", new XmlWriterSettings { Indent = true }))
            {
                f.WriteXml(w);
            }

            // Deserialize the new file and validate it
            var f2 = Deserialize("challenge.xml");

            Assert.IsTrue(f2.Validate().IsValid);
            ValidateInvoice(f2, expectedFormat);

            File.Delete("challenge.xml");
        }
        private Fattura Deserialize(string fileName)
        {
            var f = Fattura.CreateInstance(Instance.Privati);
            var s = new XmlReaderSettings { IgnoreWhitespace = true };
            using (var r = XmlReader.Create(fileName, new XmlReaderSettings { IgnoreWhitespace = true }))
            {
                f.ReadXml(r);
            }
            return f;
        }
        private void ValidateInvoice(FatturaElettronica.Fattura f, string expectedFormat)
        {

            var header = f.FatturaElettronicaHeader;

            // DatiTrasmissione
            Assert.AreEqual("00001", header.DatiTrasmissione.ProgressivoInvio);
            Assert.AreEqual((expectedFormat == FormatoTrasmissione.Privati) ? "0000000" : "AAAAAA", header.DatiTrasmissione.CodiceDestinatario);

            Assert.AreEqual("IT", header.DatiTrasmissione.IdTrasmittente.IdPaese);
            Assert.AreEqual("01234567890", header.DatiTrasmissione.IdTrasmittente.IdCodice);
            Assert.AreEqual((expectedFormat == FormatoTrasmissione.Privati) ? "betagamma@pec.it" : null, header.DatiTrasmissione.PECDestinatario);

            // CedentePrestatore
            Assert.AreEqual("IT", header.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdPaese);
            Assert.AreEqual("01234567890", header.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice);
            Assert.AreEqual("SOCIETA' ALPHA SRL", header.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione);
            Assert.AreEqual("RF01", header.CedentePrestatore.DatiAnagrafici.RegimeFiscale);
            Assert.AreEqual("VIALE ROMA 543", header.CedentePrestatore.Sede.Indirizzo);
            Assert.AreEqual("07100", header.CedentePrestatore.Sede.CAP);
            Assert.AreEqual("SASSARI", header.CedentePrestatore.Sede.Comune);
            Assert.AreEqual("IT", header.CedentePrestatore.Sede.Nazione);
            // CessionarioCommittente
            Assert.AreEqual("09876543210", header.CessionarioCommittente.DatiAnagrafici.CodiceFiscale);
            Assert.AreEqual((expectedFormat == FormatoTrasmissione.Privati) ? "BETA GAMMA" : "AMMINISTRAZIONE BETA", header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Denominazione);
            Assert.AreEqual("VIA TORINO 38-B", header.CessionarioCommittente.Sede.Indirizzo);
            Assert.AreEqual("00145", header.CessionarioCommittente.Sede.CAP);
            Assert.AreEqual("ROMA", header.CessionarioCommittente.Sede.Comune);
            Assert.AreEqual("RM", header.CessionarioCommittente.Sede.Provincia);
            Assert.AreEqual("IT", header.CessionarioCommittente.Sede.Nazione);

            var body = f.FatturaElettronicaBody[0];
            // DatiGeneraliDocumento
            Assert.AreEqual("TD01", body.DatiGenerali.DatiGeneraliDocumento.TipoDocumento);
            Assert.AreEqual("EUR", body.DatiGenerali.DatiGeneraliDocumento.Divisa);
            Assert.AreEqual(new DateTime(2014, 12, 18), body.DatiGenerali.DatiGeneraliDocumento.Data);
            Assert.AreEqual("123", body.DatiGenerali.DatiGeneraliDocumento.Numero);
            Assert.AreEqual("LA FATTURA FA RIFERIMENTO AD UNA OPERAZIONE AAAA BBBBBBBBBBBBBBBBBB CCC DDDDDDDDDDDDDDD E FFFFFFFFFFFFFFFFFFFF GGGGGGGGGG HHHHHHH II LLLLLLLLLLLLLLLLL MMM NNNNN OO PPPPPPPPPPP QQQQ RRRR SSSSSSSSSSSSSS", body.DatiGenerali.DatiGeneraliDocumento.Causale[0]);
            Assert.AreEqual("SEGUE DESCRIZIONE CAUSALE NEL CASO IN CUI NON SIANO STATI SUFFICIENTI 200 CARATTERI AAAAAAAAAAA BBBBBBBBBBBBBBBBB", body.DatiGenerali.DatiGeneraliDocumento.Causale[1]);
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
                Assert.AreEqual(new DateTime(2016, 9, 1), body.DatiGenerali.DatiContratto[0].Data);
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
            Assert.AreEqual("Trasporto spa", body.DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.Denominazione);
            // DataOraConsegna
            Assert.AreEqual(new DateTime(2012, 10, 22, 16, 46, 12), body.DatiGenerali.DatiTrasporto.DataOraConsegna);
            // DatiBeniServizi
            Assert.AreEqual(1, body.DatiBeniServizi.DettaglioLinee[0].NumeroLinea);
            Assert.AreEqual("LA DESCRIZIONE DELLA FORNITURA PUO' SUPERARE I CENTO CARATTERI CHE RAPPRESENTAVANO IL PRECEDENTE LIMITE DIMENSIONALE. TALE LIMITE NELLA NUOVA VERSIONE E' STATO PORTATO A MILLE CARATTERI", body.DatiBeniServizi.DettaglioLinee[0].Descrizione);
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
            Assert.AreEqual(new DateTime(2015, 01, 30), body.DatiPagamento[0].DettaglioPagamento[0].DataScadenzaPagamento);
            Assert.AreEqual(36.08m, body.DatiPagamento[0].DettaglioPagamento[0].ImportoPagamento);
        }
        private void SerializeAndAssertRootElementAttributes(FatturaElettronica.Fattura f)
        {
            using (var w = XmlWriter.Create("test", new XmlWriterSettings { Indent = true }))
            {
                f.WriteXml(w);
            }

            using (var r = XmlReader.Create("test"))
            {
                while (r.Read())
                {
                    if (r.NodeType == XmlNodeType.Element)
                    {
                        if (r.Prefix == RootElement.Prefix && r.LocalName == RootElement.LocalName)
                        {
                            Assert.AreEqual(f.FatturaElettronicaHeader.DatiTrasmissione.FormatoTrasmissione, r.GetAttribute("versione"));
                            Assert.AreEqual(RootElement.NameSpace, r.NamespaceURI);
                            foreach (var a in RootElement.ExtraAttributes)
                            {
                                Assert.AreEqual(a.value, r.GetAttribute(string.Format("{0}:{1}", a.Prefix, a.LocalName)));
                            }
                            break;
                        }
                    }
                }
            }
            File.Delete("test");
        }
    }
}
