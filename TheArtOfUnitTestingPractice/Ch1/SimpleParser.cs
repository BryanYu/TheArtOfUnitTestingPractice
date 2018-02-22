using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheArtOfUnitTestingPractice.Ch1
{
    public class SimpleParser
    {
        public int ParseAndSum(string nubmbers)
        {
            if (nubmbers.Length == 0)
            {
                return 0;
            }
            if (!nubmbers.Contains(","))
            {
                return int.Parse(nubmbers);
            }
            else
            {
                throw new InvalidOperationException("I can only handle 0 or 1 numbers for now!");
            }
        }
    }
}