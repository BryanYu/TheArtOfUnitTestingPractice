using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TheArtOfUnitTestingPractice.Ch3;

namespace TheArtOfUnitTestingPractice.UnitTests.Ch3
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            FakeExtensionManager myFakeExtensionManager = new FakeExtensionManager();
            myFakeExtensionManager.WillBeValid = true;
            LogAnalyzer log = new LogAnalyzer(myFakeExtensionManager);
            var result = log.IsValidLogFileName("short.txt");
            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager myFakeExtensionManager = new FakeExtensionManager();
            myFakeExtensionManager.WillThrow = new Exception("this is fake");
            LogAnalyzer log = new LogAnalyzer(myFakeExtensionManager);
            var result = log.IsValidLogFileName("anything.anyextension");
            Assert.False(result);
        }

        [Test]
        public void OverrideTest()
        {
            FakeExtensionManager stub = new FakeExtensionManager();
            stub.WillBeValid = true;

            TestableLogAnalyzer logan = new TestableLogAnalyzer(stub);
            var result = logan.IsValidLogFileName("file.ext");
            Assert.True(result);
        }
    }

    public class LogAnalyzerUsingFactoryMethod
    {
        public bool IsValidLogFileName(string fileName)
        {
            return GetManager().IsValid(fileName);
        }

        protected virtual IFileExtensionManager GetManager()
        {
            return new FileExtensionManager();
        }
    }

    public class TestableLogAnalyzer : LogAnalyzerUsingFactoryMethod
    {
        public IFileExtensionManager Manager;

        public TestableLogAnalyzer(FakeExtensionManager mgr)
        {
            this.Manager = mgr;
        }

        protected override IFileExtensionManager GetManager()
        {
            return this.Manager;
        }
    }

    public class FakeExtensionManager : IFileExtensionManager
    {
        public bool WillBeValid { get; set; }

        public Exception WillThrow { get; set; }

        public bool IsValid(string fileName)
        {
            if (WillThrow != null)
            {
                throw WillThrow;
            }
            return WillBeValid;
        }
    }
}