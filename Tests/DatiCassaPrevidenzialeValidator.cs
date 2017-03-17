using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentValidation.TestHelper;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Tabelle;

namespace Tests
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
            challenge.AliquotaIVA = 0;
            AssertRequired(x => x.Natura, expectedErrorCode:"00413");
        }
        [TestMethod]
        public void NaturaIsNotAllowedWhenAliquotaIsNotZero()
        {
            challenge.AliquotaIVA = 1;
            challenge.Natura = "N1";
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge).WithErrorCode("00414");
        }
        [TestMethod]
        public void NaturaOnlyAcceptsTableValuesWhenAliquotaIsZero()
        {
            challenge.AliquotaIVA = 0;
            AssertOnlyAcceptsTableValues<Natura>(x => x.Natura);

        }
        [TestMethod]
        public void NaturaIsOnlyValidatedWhenIsNotZero()
        {
            challenge.Natura = null;
            challenge.AliquotaIVA = 1;
            validator.ShouldNotHaveValidationErrorFor(x => x.Natura, challenge);
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
        public void RitenutaIsOptional()
        {
            AssertOptional(x => x.Ritenuta);
        }
        [TestMethod]
        public void RitenutaOnlyAcceptSIValue()
        {
            AssertOnlyAcceptsSIValue(x => x.Ritenuta);
        }
    }
}
