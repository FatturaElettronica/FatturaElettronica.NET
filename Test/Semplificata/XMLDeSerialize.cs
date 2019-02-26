namespace Semplificata.Tests
{
    using System;
    using System.IO;
    using System.Xml;
    using FatturaElettronica;
    using FatturaElettronica.Defaults;
    using FatturaElettronica.Semplificata;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class XMLDeSerialize
    {
        [TestMethod]
        public void SerializeFatturaSemplificataHeader()
        {
            SerializeAndAssertRootElementAttributes(FatturaSemplificata.CreateInstance());
        }

        [Ignore("Finchè non ci sarà il nuovo pacchetto di FAtturaElettornica.Core")]
        [TestMethod]
        public void DeserializeAndThenSerializeOfficialSMSample()
        {
            // Deserialize from an official example file 
            // (downloaded from http://www.fatturapa.gov.it/export/fatturazione/it/normativa/f-2.htm)
            DeserializeAndThenSerializeSM("Samples/IT01234567890_FSM10.xml", FormatoTrasmissione.Semplificata);
        }

        private void DeserializeAndThenSerializeSM(string filename, string expectedFormat)
        {
            var f = DeserializeSM(filename);

            Assert.IsTrue(f.Validate().IsValid);
            ValidateInvoice(f, expectedFormat);

            // Serialize it back to disk, to another file
            using (var w = XmlWriter.Create("challenge.xml", new XmlWriterSettings { Indent = true }))
            {
                f.WriteXml(w);
            }

            // Deserialize the new file and validate it
            var f2 = DeserializeSM("challenge.xml");

            Assert.IsTrue(f2.Validate().IsValid);
            ValidateInvoice(f2, expectedFormat);

            File.Delete("challenge.xml");
        }

        private FatturaSemplificata DeserializeSM(string fileName)
        {
            var f = FatturaSemplificata.CreateInstance();
            var s = new XmlReaderSettings { IgnoreWhitespace = true };
            using (var r = XmlReader.Create(fileName, new XmlReaderSettings { IgnoreWhitespace = true }))
            {
                f.ReadXml(r);
            }
            return f;
        }

        private void ValidateInvoice(FatturaSemplificata f, string expectedFormat)
        {
            var header = f.FatturaElettronicaHeader;

            // DatiTrasmissione
            Assert.AreEqual("00001", header.DatiTrasmissione.ProgressivoInvio);
            Assert.AreEqual("0000000", header.DatiTrasmissione.CodiceDestinatario);

            Assert.AreEqual("IT", header.DatiTrasmissione.IdTrasmittente.IdPaese);
            Assert.AreEqual("01234567890", header.DatiTrasmissione.IdTrasmittente.IdCodice);
            Assert.AreEqual("betagamma@pec.it", header.DatiTrasmissione.PECDestinatario);

            // CedentePrestatore
            Assert.AreEqual("IT", header.CedentePrestatore.IdFiscaleIVA.IdPaese);
            Assert.AreEqual("01234567890", header.CedentePrestatore.IdFiscaleIVA.IdCodice);
            Assert.AreEqual("SOCIETA' ALPHA SRL", header.CedentePrestatore.Denominazione);
            Assert.AreEqual("RF01", header.CedentePrestatore.RegimeFiscale);
            Assert.AreEqual("VIALE ROMA 543", header.CedentePrestatore.Sede.Indirizzo);
            Assert.AreEqual("07100", header.CedentePrestatore.Sede.CAP);
            Assert.AreEqual("SASSARI", header.CedentePrestatore.Sede.Comune);
            Assert.AreEqual("IT", header.CedentePrestatore.Sede.Nazione);
            // CessionarioCommittente
            Assert.AreEqual("09876543210", header.CessionarioCommittente.IdentificativiFiscali.IdFiscaleIVA.IdCodice);
            Assert.AreEqual("IT", header.CessionarioCommittente.IdentificativiFiscali.IdFiscaleIVA.IdPaese);
            Assert.AreEqual("BETA GAMMA", header.CessionarioCommittente.AltriDatiIdentificativi.Denominazione);
            Assert.AreEqual("VIA TORINO 38-B", header.CessionarioCommittente.AltriDatiIdentificativi.Sede.Indirizzo);
            Assert.AreEqual("00145", header.CessionarioCommittente.AltriDatiIdentificativi.Sede.CAP);
            Assert.AreEqual("ROMA", header.CessionarioCommittente.AltriDatiIdentificativi.Sede.Comune);
            Assert.AreEqual("RM", header.CessionarioCommittente.AltriDatiIdentificativi.Sede.Provincia);
            Assert.AreEqual("IT", header.CessionarioCommittente.AltriDatiIdentificativi.Sede.Nazione);

            var body = f.FatturaElettronicaBody[0];
            // DatiGeneraliDocumento
            Assert.AreEqual("TD07", body.DatiGenerali.DatiGeneraliDocumento.TipoDocumento);
            Assert.AreEqual("EUR", body.DatiGenerali.DatiGeneraliDocumento.Divisa);
            Assert.AreEqual(new DateTime(2019, 01, 01), body.DatiGenerali.DatiGeneraliDocumento.Data);
            Assert.AreEqual("123", body.DatiGenerali.DatiGeneraliDocumento.Numero);
            // DatiBeniServizi
            Assert.AreEqual("LA DESCRIZIONE DELLA FORNITURA PUO' SUPERARE I CENTO CARATTERI CHE RAPPRESENTAVANO IL PRECEDENTE LIMITE DIMENSIONALE. TALE LIMITE NELLA NUOVA VERSIONE E' STATO PORTATO A MILLE CARATTERI", body.DatiBeniServizi[0].Descrizione);
            Assert.AreEqual(25m, body.DatiBeniServizi[0].Importo);
            Assert.AreEqual(22m, body.DatiBeniServizi[0].DatiIVA.Aliquota);
            Assert.AreEqual(null, body.DatiBeniServizi[0].Natura);
            Assert.AreEqual(null, body.DatiBeniServizi[0].RiferimentoNormativo);
        }

        private void SerializeAndAssertRootElementAttributes(FatturaSemplificata f)
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
