using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheArtOfUnitTestingPractice.Ch5
{
    public class FakeLogger2 : ILoger
    {
        public Exception WillThrow = null;
        public string LastError { get; set; }

        public string LoggerGotMessage { get; set; }

        public void LogError(string message)
        {
            LoggerGotMessage = message;
            if (this.WillThrow != null)
            {
                throw this.WillThrow;
            }
        }
    }
}