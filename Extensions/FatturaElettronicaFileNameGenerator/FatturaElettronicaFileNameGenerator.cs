using FatturaElettronica.Common;
using FatturaElettronica.Extensions.Resources;
using System;

namespace FatturaElettronica.Extensions
{
    /// <summary>
    /// Factory per la creazione del filename
    /// </summary>
    public class FatturaElettronicaFileNameGenerator
    {
        private readonly IdFiscaleIVA _idFiscaleIVA;
        private readonly FatturaElettronicaFileNameExtensionType _fatturaExtensionType;

        public FatturaElettronicaFileNameGenerator(IdFiscaleIVA idFiscale,
            FatturaElettronicaFileNameExtensionType fatturaType = FatturaElettronicaFileNameExtensionType.Plain)
        {
            _idFiscaleIVA = idFiscale ?? throw new ArgumentNullException(ErrorMessages.IdFiscaleIsMissing);
            if (_idFiscaleIVA.IdPaese == null || _idFiscaleIVA.IdPaese.Length < 2)
                throw new ArgumentException(ErrorMessages.IdPaeseIsWrongOrMissing);
            if (_idFiscaleIVA.IdCodice == null)
                throw new ArgumentException(ErrorMessages.IdCodiceIsMissing);
            _fatturaExtensionType = fatturaType;
        }

        /// <summary>
        /// Restituisce il nome del file partendo dall'ultimo numero di fattura staccata
        /// </summary>
        /// <param name="lastBillingNumber"></param>
        /// <returns></returns>
        public string GetNextFileName(int lastBillingNumber) =>
            $"{_idFiscaleIVA.IdPaese}{_idFiscaleIVA.IdCodice}_{GetNext(lastBillingNumber)}{Extension}";

        /// <summary>
        /// Restituisce il nome del file partendo dall'ultimo nome del file generato
        /// </summary>
        /// <param name="lastBillingNumber"></param>
        /// <returns></returns>
        public string GetNextFileName(string lastBillingNumber) =>
            $"{_idFiscaleIVA.IdPaese}{_idFiscaleIVA.IdCodice}_{GetNext(lastBillingNumber)}{Extension}";

        private readonly char[] _baseChars = {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
            'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        public int? CurrentIndex { get; set; }

        private string Extension =>
            _fatturaExtensionType == FatturaElettronicaFileNameExtensionType.Plain ? ".xml" : ".xml.p7m";

        /// <summary>
        /// Restituisce il Progressivo Invio Successivo
        /// </summary>
        /// <param name="lastNumber"></param>
        /// <returns></returns>
        private string GetNext(int lastNumber)
        {
            CurrentIndex = ++lastNumber;
            var value = ToString(CurrentIndex.Value);
            if (value.Length > 5)
                throw new ArgumentException(ErrorMessages.LastBillingNumberIsTooLong);
            return value.PadLeft(5, '0');
        }

        /// <summary>
        /// Restituisce il Progressivo Invio Successivo
        /// </summary>
        /// <param name="lastStringNumber"></param>
        /// <returns></returns>
        private string GetNext(string lastStringNumber)
        {
            return GetNext(ToInteger(lastStringNumber));
        }

        /// <summary>
        /// Da numero a stringa valida
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string ToString(int value)
        {
            var i = 32;
            var buffer = new char[i];
            var targetBase = _baseChars.Length;

            do
            {
                buffer[--i] = _baseChars[value % targetBase];
                value = value / targetBase;
            } while (value > 0);

            var result = new char[32 - i];
            Array.Copy(buffer, i, result, 0, 32 - i);

            return new(result);
        }

        /// <summary>
        /// Da Stringa valida a numero
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int ToInteger(string value)
        {
            var k = value.Length - 1;
            value = Reverse(value);
            var targetBase = _baseChars.Length;
            var result = 0;

            do
            {
                for (var j = _baseChars.Length - 1; j > 0; j--)
                {
                    if (_baseChars[j] != value[k]) continue;
                    result = result + j * (int) Math.Pow(targetBase, k);
                    break;
                }

                k--;
            } while (k >= 0);

            return result;
        }

        /// <summary>
        /// String Reverse
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string Reverse(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new(charArray);
        }
    }
}