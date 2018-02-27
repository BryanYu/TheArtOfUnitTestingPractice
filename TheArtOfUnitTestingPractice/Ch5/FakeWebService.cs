namespace TheArtOfUnitTestingPractice.Ch5
{
    public class FakeWebService : IWebService
    {
        public string MessageToWebService;

        public void Write(string message)
        {
            this.MessageToWebService = message;
        }
    }
}