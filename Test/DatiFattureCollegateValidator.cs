﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiFattureCollegateValidator
        : BaseDatiDocumentoValidator<DatiFattureCollegate, FatturaElettronica.Validators.DatiFattureCollegateValidator>
    {
    }
}
