using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class DatiRicezioneValidator
        : BaseDatiDocumentoValidator<DatiRicezione, FatturaElettronica.Validators.DatiRicezioneValidator>
    {
    }
}