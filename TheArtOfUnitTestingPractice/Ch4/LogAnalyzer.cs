namespace TheArtOfUnitTestingPractice.Ch4
{
    public class LogAnalyzer
    {
        private IWebServe service;

        public LogAnalyzer(IWebServe service)
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