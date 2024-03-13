using System.Collections.Generic;
using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public abstract class BaseDatiDocumentoValidator<TClass, TValidator>
        : BaseClass<TClass, TValidator>
        where TClass : FatturaElettronica.Common.DatiDocumento
        where TValidator : IValidator<TClass>
    {
        [TestMethod]
        public void IdDocumentoIsRequired()
        {
            AssertRequired(x => x.IdDocumento);
        }

        [TestMethod]
        public void IdDocumentoMinMaxLength()
        {
            AssertMinMaxLength(x => x.IdDocumento, 1, 20);
        }

        [TestMethod]
        public void IdDocumentMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.IdDocumento);
        }

        [TestMethod]
        public void NumItemIsOptional()
        {
            AssertOptional(x => x.NumItem);
        }

        [TestMethod]
        public void NumItemMinMaxLength()
        {
            AssertMinMaxLength(x => x.NumItem, 1, 20);
        }

        [TestMethod]
        public void NumItemMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.NumItem);
        }

        [TestMethod]
        public void CodiceCommessaIsOptional()
        {
            AssertOptional(x => x.CodiceCommessaConvenzione);
        }

        [TestMethod]
        public void CodiceCommessaMustBeLatin1Supplement()
        {
            AssertMustBeLatin1Supplement(x => x.CodiceCommessaConvenzione);
        }

        [TestMethod]
        public void CodiceCommessaMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodiceCommessaConvenzione, 1, 100);
        }

        [TestMethod]
        public void CodiceCUPIsOptional()
        {
            AssertOptional(x => x.CodiceCUP);
        }

        [TestMethod]
        public void CodiceCUPMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodiceCUP, 1, 15);
        }

        [TestMethod]
        public void CodiceCUPMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.CodiceCUP);
        }

        [TestMethod]
        public void CodiceCIGIsOptional()
        {
            AssertOptional(x => x.CodiceCIG);
        }

        [TestMethod]
        public void CodiceCIGMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodiceCIG, 1, 15);
        }

        [TestMethod]
        public void CodiceCIGMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.CodiceCIG);
        }

        [TestMethod]
        public void RiferimentoNumeroLineaValidatorMinMax()
        {
            Challenge.RiferimentoNumeroLinea = new() { -1 };
            var result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.RiferimentoNumeroLinea);

            Challenge.RiferimentoNumeroLinea = new() { 10000 };
            result = Validator.TestValidate(Challenge);
            result.ShouldHaveValidationErrorFor(x => x.RiferimentoNumeroLinea);

            Challenge.RiferimentoNumeroLinea = new() { 1 };
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.RiferimentoNumeroLinea);

            Challenge.RiferimentoNumeroLinea = new() { 9999 };
            result = Validator.TestValidate(Challenge);
            result.ShouldNotHaveValidationErrorFor(x => x.RiferimentoNumeroLinea);
        }
    }
}