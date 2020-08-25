using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentValidation.TestHelper;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Tabelle;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class DatiCassaPrevidenzialeValidator
        : BaseClass<DatiCassaPrevidenziale, FatturaElettronica.Validators.DatiCassaPrevidenzialeValidator>
    {
        [TestMethod]
        public void TipoCassaIsRequired()
        {
            AssertRequired(x => x.TipoCassa);
        }
        [TestMethod]
        public void TipoCassaOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<TipoCassa>(x => x.TipoCassa);
        }
        [TestMethod]
        public void NaturaIsRequiredWhenAliquotaIsZero()
        {
            Challenge.AliquotaIVA = 0;
            AssertRequired(x => x.Natura, expectedErrorCode:"00413");
        }
        [TestMethod]
        public void NaturaIsNotAllowedWhenAliquotaIsNotZero()
        {
            Challenge.AliquotaIVA = 1;
            Challenge.Natura = "N1";
            Validator.ShouldHaveValidationErrorFor(x => x.Natura, Challenge).WithErrorCode("00414");
        }
        [TestMethod]
        public void NaturaOnlyAcceptsTableValuesWhenAliquotaIsZero()
        {
            Challenge.AliquotaIVA = 0;
            AssertOnlyAcceptsTableValues<Natura>(x => x.Natura);

        }
        [TestMethod]
        public void NaturaIsOnlyValidatedWhenIsNotZero()
        {
            Challenge.Natura = null;
            Challenge.AliquotaIVA = 1;
            Validator.ShouldNotHaveValidationErrorFor(x => x.Natura, Challenge);
        }
        [TestMethod]
        public void RiferimentoAmministrazioneIsOptional()
        {
            AssertOptional(x => x.RiferimentoAmministrazione);
        }
        [TestMethod]
        public void RiferimentoAmministrazioneMinMaxLength()
        {
            AssertMinMaxLength(x => x.RiferimentoAmministrazione, 1, 20);
        }
        [TestMethod]
        public void RiferimentoAmministrazioneMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.RiferimentoAmministrazione);
        }
        [TestMethod]
        public void RitenutaIsOptional()
        {
            AssertOptional(x => x.Ritenuta);
        }
        [TestMethod]
        public void RitenutaOnlyAcceptSIValue()
        {
            AssertOnlyAcceptsSIValue(x => x.Ritenuta);
        }
        
        [TestMethod]
        public void ImportoContributoCassa()
        {
            AssertDecimalType(x => x.ImportoContributoCassa, 2, 13);
        }
        
        [TestMethod]
        public void ImponibileCassa()
        {
            AssertDecimalType(x => x.ImponibileCassa, 2, 13);
        }
    }
}
