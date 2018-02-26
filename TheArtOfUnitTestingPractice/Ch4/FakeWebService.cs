namespace TheArtOfUnitTestingPractice.Ch4
{
    public class FakeWebService : IWebServe
    {
        public string LastError;

        public void LogError(string message)
        {
            this.LastError = message;
        }
    }
}