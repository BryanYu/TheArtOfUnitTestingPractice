using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheArtOfUnitTestingPractice.Ch4;

namespace TheArtOfUnitTestingPractice.UnitTests.Ch4
{
    public class FakeEmailService : IEmailService
    {
        public string To;

        public string Subject;

        public string Body;

        public void SendEmail(string to, string subject, string body)
        {
            this.To = to;
            this.Subject = subject;
            this.Body = body;
        }
    }
}