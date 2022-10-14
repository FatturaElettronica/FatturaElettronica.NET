using System.Linq;
using FatturaElettronica.Common;
using FatturaElettronica.Extensions;
using FatturaElettronica.Semplificata;
using FatturaElettronica.Semplificata.FatturaElettronicaBody;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Semplificata
{
    [TestClass]
    public class FatturaSemplificataValidator : BaseClass<FatturaSemplificata,
        FatturaElettronica.Validators.Semplificata.FatturaSemplificataValidator>
    {
        [TestInitialize]
        public new void Init()
        {
            Validator = new();
            Challenge = new();
        }

        [TestMethod]
        public void FatturaElettronicaHeaderHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaHeader,
                typeof(FatturaElettronica.Validators.Semplificata.FatturaElettronicaHeaderValidator));
        }

        [TestMethod]
        public void FatturaElettronicaBodyHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(
                x => x.FatturaElettronicaBody,
                typeof(FatturaElettronica.Validators.Semplificata.FatturaElettronicaBodyValidator));
        }

        [TestMethod]
        public void FatturaValidateAgainstError00471()
        {
            var tipiDocumento = new[] { "TD07" };
            var cedente = Challenge.FatturaElettronicaHeader.CedentePrestatore;
            var cessionario = Challenge.FatturaElettronicaHeader.CessionarioCommittente;
            var id123 = new IdFiscaleIVA { IdPaese = "IT", IdCodice = "123" };
            var id456 = new IdFiscaleIVA { IdPaese = "IT", IdCodice = "456" };

            foreach (var tipoDocumento in tipiDocumento)
            {
                var body = new FatturaElettronicaBody();
                body.DatiGenerali.DatiGeneraliDocumento.TipoDocumento = tipoDocumento;
                Challenge.FatturaElettronicaBody.Add(body);

                cedente.IdFiscaleIVA = id123;
                cessionario.IdentificativiFiscali.IdFiscaleIVA = id123;
                var result = Challenge.Validate();
                Assert.IsNotNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00471"));

                cedente.IdFiscaleIVA = id456;
                result = Challenge.Validate();
                Assert.IsNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00471"));

                cedente.IdFiscaleIVA = new();
                cessionario.IdentificativiFiscali.IdFiscaleIVA = new();
                result = Challenge.Validate();
                Assert.IsNotNull(result.Errors.FirstOrDefault(x => x.ErrorCode == "00471"));
            }
        }
    }
}