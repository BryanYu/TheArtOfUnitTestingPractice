namespace TheArtOfUnitTestingPractice.Ch4
{
    public class LogAnalyzer
    {
        private IWebService service;

        public LogAnalyzer(IWebService service)
        {
            this.service = service;
        }

        public void Analyze(string filename)
        {
            if (filename.Length < 8)
            {
                this.service.LogError("Filename too short:" + filename);
            }
        }
    }
}