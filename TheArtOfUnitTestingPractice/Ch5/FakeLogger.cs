namespace TheArtOfUnitTestingPractice.Ch5
{
    public class FakeLogger : ILoger
    {
        public string LastError { get; set; }

        public void LogError(string message)
        {
            LastError = message;
        }
    }
}