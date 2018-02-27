using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheArtOfUnitTestingPractice.Ch5
{
    public class LogAnalyzer2
    {
        private ILoger _loger;

        private IWebService _webService;

        public int MinNameLength { get; set; }

        public LogAnalyzer2(ILoger logger, IWebService webServce)
        {
            this._loger = logger;
            this._webService = webServce;
        }

        public void Analyze(string filename)
        {
            if (filename.Length < MinNameLength)
            {
                try
                {
                    this._loger.LogError(string.Format("Filename too short:{0}", filename));
                }
                catch (Exception e)
                {
                    this._webService.Write("Error From Logger:" + e);
                }
            }
        }
    }
}