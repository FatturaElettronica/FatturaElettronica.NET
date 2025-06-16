using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FatturaElettronica.Extensions
{
    public static class StreamExtensions
    {
        /// <summary>
        /// This helper performs preliminary checks to determine if content is likely to be Base64 encoded and if it is it attempts to Decode it and returns.
        /// For better consistency with previous implementations if the input stream Position is not 0 and it is seekable, it will be rewound to Position = 0
        /// </summary>
        /// <param name="fileContents">The Stream to be processed</param>
        /// <returns>If the input stream was Base encoded and was successfully decoded it returns a new Stream containing the decoded data. 
        ///Else it rewinds and returns the original stream</returns>
        ///<exception cref="FormatException">Although unlikely, if provided with an invalid base encoded Stream that still got through the length check and regex it will throw a FormatException</exception>
        public static Stream PreprocessStreamEncoding(Stream fileContents)
        {
            ///Previous versions of the library worked independently of the stream position, so we should maintain this behavior where possible
            if (fileContents.Position != 0 && fileContents.CanSeek)
            {
                fileContents.Position = 0;
            }
            //Using the full constructor to prevent stream collection
            using var reader = new StreamReader(fileContents, System.Text.Encoding.UTF8, true, 1024, true);
            var content = reader.ReadToEnd();
            //The length check is a bit faster separate instead of inserted in the regex match
            if (content.Length % 4 != 0 || !Regex.IsMatch(content, "^[A-Za-z0-9+/]*([AQgw]==|[AEIMQUYcgkosw048]=)?$"))
            {
                //Unlikely to be B64,we rewind the stream for caller convenience
                fileContents.Position = 0;
                return fileContents;
            }
            //Returning a B64Decoded Stream
            return new MemoryStream(Convert.FromBase64String(content));
        }
    }
}