using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheArtOfUnitTestingPractice.Ch4
{
    public class LogAnalyzer2
    {
        public IWebService Service { get; set; }

        public IEmailService Email { get; set; }

        public LogAnalyzer2(IWebService service, IEmailService email)
        {
            this.Service = service;
            this.Email = email;
        }

        public void Analyze(string filename)
        {
            if (filename.Length < 8)
            {
                try
                {
                    Service.LogError("Filename too short:" + filename);
                }
                catch (Exception e)
                {
                    Email.SendEmail("someone@somewhere.com", "can't log", e.Message);
                }
            }
        }
    }
}