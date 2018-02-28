using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using NSubstitute;
using NUnit.Framework;
using TheArtOfUnitTestingPractice.Ch5;

namespace TheArtOfUnitTestingPractice.UnitTests.Ch5
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            ILoger logger = Substitute.For<ILoger>();
            LogAnalyzer analyzer = new LogAnalyzer(logger);
            analyzer.MinNameLength = 6;
            analyzer.Analyze("a.txt");
            logger.Received().LogError("Filename too short:a.txt");
            StringAssert.Contains("too short", logger.LastError);
        }

        [Test]
        public void Analyze_LoggerThrows_CallsWebService()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILoger>();
            stubLogger.When(logger => logger.LogError(Arg.Any<string>())).
                Do(info => { throw new Exception("fake exception"); });
            var analyzer2 = new LogAnalyzer2(stubLogger, mockWebService);
            analyzer2.MinNameLength = 10;
            analyzer2.Analyze("Short.txt");
            mockWebService.Received().Write(Arg.Is<string>(s => s.Contains("fake exception")));
        }
    }
}