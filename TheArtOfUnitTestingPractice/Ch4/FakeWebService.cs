using System;

namespace TheArtOfUnitTestingPractice.Ch4
{
    public class FakeWebService : IWebService
    {
        public string LastError;

        public Exception ToThrow;

        public void LogError(string message)
        {
            if (this.ToThrow != null)
            {
                throw this.ToThrow;
            }
        }
    }
}