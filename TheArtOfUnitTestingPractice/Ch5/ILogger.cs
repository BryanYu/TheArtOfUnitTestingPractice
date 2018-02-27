using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheArtOfUnitTestingPractice.Ch5
{
    public interface ILoger
    {
        string LastError { get; set; }

        void LogError(string message);
    }
}