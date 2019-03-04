﻿namespace Ordinaria.Tests
{
    using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CedentePrestatore;
    using global::Tests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;


    [TestClass]
    public class ContattiValidator
        : BaseClass<Contatti, FatturaElettronica.Validators.ContattiValidator>
    {
        [TestMethod]
        public void TelefonoIsOptional()
        {
            AssertOptional(x => x.Telefono);
        }
        [TestMethod]
        public void TelefonoMinMaxLength()
        {
            AssertMinMaxLength(x => x.Telefono, 5, 12);
        }
        [TestMethod]
        public void FaxIsOptional()
        {
            AssertOptional(x => x.Fax);
        }
        [TestMethod]
        public void FaxMinMaxLength()
        {
            AssertMinMaxLength(x => x.Fax, 5, 12);
        }
        [TestMethod]
        public void EmailIsOptional()
        {
            AssertOptional(x => x.Email);
        }
        [TestMethod]
        public void EmailMinMaxLength()
        {
            AssertMinMaxLength(x => x.Email, 7, 256);
        }
    }
}