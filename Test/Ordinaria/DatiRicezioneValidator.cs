using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using Tests;

namespace Ordinaria.Tests
{
    [TestClass]
    public class DatiRicezioneValidator
        : BaseDatiDocumentoValidator<DatiRicezione, FatturaElettronica.Validators.DatiRicezioneValidator>
    {
    }
}
