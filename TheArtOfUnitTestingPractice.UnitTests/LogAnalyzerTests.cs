using System;

using NUnit.Framework;

using TheArtOfUnitTestingPractice.Ch2;

namespace TheArtOfUnitTestingPractice.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidLogFileName_Bad_Extension_ReturnsFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");
            Assert.False(result);
        }

        [TestCase("filewithgoodextension.SLF", true)]
        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithgoodextension.foo", false)]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string file, bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName(file);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void IsValidLogFileName_EmptyFileName_ThrowsException()
        {
            LogAnalyzer analyzer = this.MakeAnalyzer();
            var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName(string.Empty));
            StringAssert.Contains("filename has to be provided", ex.Message);
        }

        [Test]
        public void IsValidFileName_EmptyFileName_ThrowsFluent()
        {
            LogAnalyzer analyzer = this.MakeAnalyzer();
            var ex = Assert.Catch<ArgumentException>(() => analyzer.IsValidLogFileName(string.Empty));
            Assert.That(ex.Message, Is.StringContaining("filename has to be provided"));
        }

        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string filename, bool expected)
        {
            LogAnalyzer analyzer = this.MakeAnalyzer();
            analyzer.IsValidLogFileName(filename);
            Assert.AreEqual(expected, analyzer.WasLastFileNameValid);
        }

        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }
    }
}