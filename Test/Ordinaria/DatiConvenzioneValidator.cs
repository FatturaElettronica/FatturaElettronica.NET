using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using Tests;

namespace Ordinaria.Tests
{
    [TestClass]
    public class DatiConvenzioneValidator
        : BaseDatiDocumentoValidator<DatiConvenzione, FatturaElettronica.Validators.DatiConvenzioneValidator>
    {
    }
}
