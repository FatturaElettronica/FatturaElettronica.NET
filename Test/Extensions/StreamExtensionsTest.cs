using System;
using System.IO;
using System.Text;
using FatturaElettronica.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Extensions
{
    [TestClass]
    public class StreamExtensionsTest
    {

        [TestMethod]
        public void ReadXml_ShouldRewindBeforeReading()
        {
            var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(Base64String));
            inputStream.Position = 5;
            var resultStream = StreamExtensions.PreprocessStreamEncoding(inputStream);

            var decodedString = Encoding.UTF8.GetString((resultStream as MemoryStream).ToArray());

            Assert.AreEqual(BareString, decodedString);
        }

        [TestMethod]
        public void PreprocessStreamEncoding_ShouldOnlyConvertBase64Input()
        {
            var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(BareString));
            var resultStream = StreamExtensions.PreprocessStreamEncoding(inputStream);

            var decodedString = Encoding.UTF8.GetString((resultStream as MemoryStream).ToArray());

            Assert.AreEqual(BareString, decodedString);
            Assert.AreEqual(inputStream.Length, resultStream.Length);
        }


        [TestMethod]
        public void PreprocessStreamEncoding_ShouldDecodeCorrectly()
        {
            var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(Base64String));
            inputStream.Position = 5;

            var resultStream = StreamExtensions.PreprocessStreamEncoding(inputStream);

            var decodedString = Encoding.UTF8.GetString((resultStream as MemoryStream).ToArray());

            Assert.AreEqual(BareString, decodedString);
        }

        [TestMethod]
        public void PreprocessStreamEncoding_ShouldNotRewindNonSeekableStream()
        {
            var mixedPreviousContent = "CouldBeAFileHeader";
            var mixedBufferStream = new NonRewindableStream(Encoding.UTF8.GetBytes(string.Concat("CouldBeAFileHeader", Base64String)));
            mixedBufferStream.Position = mixedPreviousContent.Length; //We move to the stream position where the base64 starts

            var resultStream = StreamExtensions.PreprocessStreamEncoding(mixedBufferStream);

            var decodedString = Encoding.UTF8.GetString((resultStream as MemoryStream).ToArray());

            Assert.AreEqual(BareString, decodedString);
        }

        [TestMethod]
        public void PreprocessStreamEncoding_ShouldNotRewindPositionZeroStreams()
        {
            var correctlyPositionedStream = new SusceptibleMemoryStream(Encoding.UTF8.GetBytes(Base64String));
     
            var resultStream = StreamExtensions.PreprocessStreamEncoding(correctlyPositionedStream);

            var decodedString = Encoding.UTF8.GetString((resultStream as MemoryStream).ToArray());

            Assert.AreEqual(BareString, decodedString);
        }


        private const string BareString = "NotABaseEncodedString";
        private const string Base64String = "Tm90QUJhc2VFbmNvZGVkU3RyaW5n";

        private class NonRewindableStream : MemoryStream
        {
            public NonRewindableStream(byte[] buffer) : base(buffer)
            {
            }
            public override bool CanSeek => false;
        }

        /// <summary>
        /// This class will take offense if Position is invoked and it's original value is zero
        /// </summary>
        private class SusceptibleMemoryStream : MemoryStream
        {
            public SusceptibleMemoryStream(byte[] buffer) : base(buffer)
            {
            }
            public override long Position 
            { 
                get => base.Position; 
                set 
                { 
                    if (base.Position == 0) 
                    {
                        throw new Exception("You should not see this if the StreamExtensions class is implemented correctly");
                    } base.Position = value; 
                } 
            }
        }
    }
}