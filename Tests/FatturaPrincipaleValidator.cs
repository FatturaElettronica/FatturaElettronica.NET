using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using System;

namespace Tests
{
    [TestClass]
    public class FatturaPrincipaleValidator: BaseClass<FatturaPrincipale, FatturaElettronica.Validators.FatturaPrincipaleValidator>
    {
        [TestInitialize]
        public new void Init()
        {
            base.Init();

            // Abbiamo bisogno che l'istanza non sia Empty.
            challenge.NumeroFatturaPrincipale = "x";

        }
        [TestMethod]
        public void ValidationIsPerformedWhenNotEmpty()
        {
            var r = validator.Validate(challenge);
            Assert.IsFalse(r.IsValid);
        }

        [TestMethod]
        public void IsValidWhenEmptyBecauseOptional()
        {
            // Riportiamo istanza a Empty (vedi Init()).
            challenge.NumeroFatturaPrincipale = null;

            var r = validator.Validate(challenge);
            Assert.IsTrue(r.IsValid);
        }
        [TestMethod]
        public void NumeroFatturaPrincipaleIsRequired()
        {
            // Abbiamo bisogno di istanza non Empty ma in questo caso non possiamo usare CausalePagamento
            // a tal scopo perché dobbiamo testare proprio quella proprietà.
            challenge.DataFatturaPrincipale = DateTime.Now;

            AssertRequired(x => x.NumeroFatturaPrincipale);
        }
        [TestMethod]
        public void NumeroFatturaPrinicipaleMinMaxLength()
        {
            AssertMinMaxLength(x => x.NumeroFatturaPrincipale, 1, 20);
        }
        [TestMethod]
        public void DataFatturaPrincipaleIsRequired()
        {
            AssertRequired(x => x.DataFatturaPrincipale);
        }
    }
}
