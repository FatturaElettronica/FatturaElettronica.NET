using FluentValidation.TestHelper;
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
        public void NumeroFatturaPrincipaleCannotBeEmpty()
        {
            // Abbiamo bisogno di istanza non Empty ma in questo caso non possiamo usare CausalePagamento
            // a tal scopo perché dobbiamo testare proprio quella proprietà.
            challenge.DataFatturaPrincipale = DateTime.Now;

            challenge.NumeroFatturaPrincipale = null;
            validator.ShouldHaveValidationErrorFor(x => x.NumeroFatturaPrincipale, challenge);
            challenge.NumeroFatturaPrincipale = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.NumeroFatturaPrincipale, challenge);
        }
        [TestMethod]
        public void NumeroFatturaPrinicipaleMinMaxLength()
        {
            challenge.NumeroFatturaPrincipale = new string('x', 21);
            validator.ShouldHaveValidationErrorFor(x => x.NumeroFatturaPrincipale, challenge);
            challenge.NumeroFatturaPrincipale = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroFatturaPrincipale, challenge);
            challenge.NumeroFatturaPrincipale = new string('x', 20);
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroFatturaPrincipale, challenge);
        }
        [TestMethod]
        public void DataFatturaPrincipaleCannotBeNull()
        {
            challenge.DataFatturaPrincipale = null;
            validator.ShouldHaveValidationErrorFor(x => x.DataFatturaPrincipale, challenge);
            challenge.DataFatturaPrincipale = DateTime.Now;
            validator.ShouldNotHaveValidationErrorFor(x => x.DataFatturaPrincipale, challenge);
        }
    }
}
