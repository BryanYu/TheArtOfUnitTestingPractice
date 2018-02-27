namespace TheArtOfUnitTestingPractice.Ch5
{
    public class LogAnalyzer
    {
        private ILoger _logger;

        public int MinNameLength { get; set; }

        public LogAnalyzer(ILoger logger)
        {
            this._logger = logger;
        }

        public void Analyze(string aTxt)
        {
            throw new System.NotImplementedException();
        }
    }
}