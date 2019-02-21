using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiRicezioneValidator
        : BaseDatiDocumentoValidator<DatiRicezione, FatturaElettronica.Validators.DatiRicezioneValidator>
    {
    }
}
