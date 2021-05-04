﻿using System.Linq;
using FatturaElettronica.Common;
using FatturaElettronica.Extensions;
using FatturaElettronica.Ordinaria;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class FatturaValidator : BaseClass<FatturaOrdinaria, Validators.FatturaOrdinariaValidator>
    {
        [TestInitialize]
        public new void Init()
        {
            Validator = new Validators.FatturaOrdinariaValidator();
            Challenge = new FatturaOrdinaria();
        }

        [TestMethod]
        public void FatturaElettronicaHeaderHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaHeader,
                typeof(Validators.FatturaElettronicaHeaderValidator));
        }

        [TestMethod]
        public void FatturaElettronicaBodyHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaBody, typeof(Validators.FatturaElettronicaBodyValidator));
        }

        [TestMethod]
        public void FatturaValidateAgainstError00473()
        {
            var tipiDocumento = new[] { "TD17", "TD18", "TD19" };
            var cedente = Challenge.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici;

            cedente.IdFiscaleIVA = new IdFiscaleIVA { IdPaese = "IT" };
            var body = new FatturaElettronicaBody();
            Challenge.FatturaElettronicaBody.Add(body);

            foreach (var tipoDocumento in tipiDocumento)
            {
                body.DatiGenerali.DatiGeneraliDocumento.TipoDocumento = tipoDocumento;
                Assert.IsNotNull(Challenge.Validate().Errors.FirstOrDefault(x => x.ErrorCode == "00473"));
            }

            body.DatiGenerali.DatiGeneraliDocumento.TipoDocumento = "TD01";
            Assert.IsNull(Challenge.Validate().Errors.FirstOrDefault(x => x.ErrorCode == "00473"));

            cedente.IdFiscaleIVA = new IdFiscaleIVA { IdPaese = "XX" };
            foreach (var tipoDocumento in tipiDocumento)
            {
                body.DatiGenerali.DatiGeneraliDocumento.TipoDocumento = tipoDocumento;
                Assert.IsNull(Challenge.Validate().Errors.FirstOrDefault(x => x.ErrorCode == "00473"));
            }
        }

        [TestMethod]
        public void FatturaValidateAgainstError00472()
        {
            var cedente = Challenge.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici;
            var cessionario = Challenge.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici;
            var id123 = new IdFiscaleIVA { IdPaese = "IT", IdCodice = "123" };
            var id456 = new IdFiscaleIVA { IdPaese = "IT", IdCodice = "456" };

            var body = new FatturaElettronicaBody();
            body.DatiGenerali.DatiGeneraliDocumento.TipoDocumento = "TD21";
            Challenge.FatturaElettronicaBody.Add(body);

            cedente.IdFiscaleIVA = id123;
            cessionario.IdFiscaleIVA = id456;
            Assert.IsNotNull(Challenge.Validate().Errors.FirstOrDefault(x => x.ErrorCode == "00472"));

            cessionario.IdFiscaleIVA = id123;
            Assert.IsNull(Challenge.Validate().Errors.FirstOrDefault(x => x.ErrorCode == "00472"));

            cedente.CodiceFiscale = "123";
            cedente.CodiceFiscale = "456";
            Assert.IsNotNull(Challenge.Validate().Errors.FirstOrDefault(x => x.ErrorCode == "00472"));

            cedente.CodiceFiscale = "123";
            Assert.IsNotNull(Challenge.Validate().Errors.FirstOrDefault(x => x.ErrorCode == "00472"));

            body.DatiGenerali.DatiGeneraliDocumento.TipoDocumento = "TD01";
            Assert.IsNull(Challenge.Validate().Errors.FirstOrDefault(x => x.ErrorCode == "00472"));
        }

        [TestMethod]
        public void FatturaValidateAgainstError00471()
        {
            var tipiDocumento = new[] { "TD16", "TD17", "TD18", "TD19", "TD20" };
            var cedente = Challenge.FatturaElettronicaHeader.CedentePrestatore.DatiAnagrafici;
            var cessionario = Challenge.FatturaElettronicaHeader.CessionarioCommittente.DatiAnagrafici;
            var id123 = new IdFiscaleIVA { IdPaese = "IT", IdCodice = "123" };
            var id456 = new IdFiscaleIVA { IdPaese = "IT", IdCodice = "456" };

            foreach (var tipoDocumento in tipiDocumento)
            {
                var body = new FatturaElettronicaBody();
                body.DatiGenerali.DatiGeneraliDocumento.TipoDocumento = tipoDocumento;
                Challenge.FatturaElettronicaBody.Add(body);

                cedente.CodiceFiscale = null;
                cessionario.CodiceFiscale = null;

                cedente.IdFiscaleIVA = id123;
                cessionario.IdFiscaleIVA = id123;
                var result = Challenge.Validate();
                Assert.IsNotNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00471"));

                cedente.IdFiscaleIVA = id456;
                result = Challenge.Validate();
                Assert.IsNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00471"));

                cedente.IdFiscaleIVA = new IdFiscaleIVA();
                cessionario.IdFiscaleIVA = new IdFiscaleIVA();
                cedente.CodiceFiscale = "123";
                cessionario.CodiceFiscale = "123";
                result = Challenge.Validate();
                Assert.IsNotNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00471"));

                cessionario.CodiceFiscale = "456";
                result = Challenge.Validate();
                Assert.IsNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00471"));
            }
        }

        [TestMethod]
        public void BodyValidateAgainstError00444()
        {
            var body = new FatturaElettronicaBody();
            body.DatiBeniServizi.DettaglioLinee.Add(new DettaglioLinee { Natura = "N1" });
            body.DatiBeniServizi.DettaglioLinee.Add(new DettaglioLinee { Natura = "N2" });
            body.DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Add(
                new DatiCassaPrevidenziale { Natura = "N3" });
            body.DatiBeniServizi.DatiRiepilogo.Add(new DatiRiepilogo { Natura = "N1" });
            Challenge.FatturaElettronicaBody.Add(body);

            var result = Validator.Validate(Challenge);
            Assert.IsNotNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00444"));

            body.DatiBeniServizi.DatiRiepilogo.Add(new DatiRiepilogo { Natura = "N2" });
            Assert.IsNotNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00444"));

            body.DatiBeniServizi.DatiRiepilogo.Add(new DatiRiepilogo { Natura = "N3" });
            result = Validator.Validate(Challenge);
            Assert.IsNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00444"));

            body.DatiBeniServizi.DettaglioLinee.Add(new DettaglioLinee { Natura = null });
            result = Validator.Validate(Challenge);
            Assert.IsNotNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00444"));

            body.DatiBeniServizi.DatiRiepilogo.Add(new DatiRiepilogo { Natura = null });
            result = Validator.Validate(Challenge);
            Assert.IsNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00444"));

        }

        [TestMethod]
        public void BodyValidateAgainstError00443()
        {
            var body = new FatturaElettronicaBody();
            body.DatiBeniServizi.DettaglioLinee.Add(new DettaglioLinee { AliquotaIVA = 1m });
            body.DatiBeniServizi.DettaglioLinee.Add(new DettaglioLinee { AliquotaIVA = 2m });
            body.DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Add(
                new DatiCassaPrevidenziale { AliquotaIVA = 3m });
            body.DatiBeniServizi.DatiRiepilogo.Add(new DatiRiepilogo { AliquotaIVA = 1m });
            Challenge.FatturaElettronicaBody.Add(body);

            var result = Validator.Validate(Challenge);
            Assert.IsNotNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00443"));

            body.DatiBeniServizi.DatiRiepilogo.Add(new DatiRiepilogo { AliquotaIVA = 2m });
            Assert.IsNotNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00443"));

            body.DatiBeniServizi.DatiRiepilogo.Add(new DatiRiepilogo { AliquotaIVA = 3m });
            result = Validator.Validate(Challenge);
            Assert.IsNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00443"));

            body.DatiBeniServizi.DatiRiepilogo.Add(new DatiRiepilogo { AliquotaIVA = 4m });
            result = Validator.Validate(Challenge);
            Assert.IsNotNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00443"));
        }
    }
}