using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TheArtOfUnitTestingPractice.Ch3
{
    public class LogAnalyzer
    {
        private IFileExtensionManager manager;

        public LogAnalyzer(IFileExtensionManager manager)
        {
            this.manager = manager;
        }

        public LogAnalyzer()
        {
            this.manager = new FileExtensionManager();
        }

        public IFileExtensionManager ExtensionManager
        {
            get
            {
                return this.manager;
            }
            set
            {
                this.manager = value;
            }
        }

        public bool IsValidLogFileName(string fileName)
        {
            return this.manager.IsValid(fileName);
        }
    }

    public interface IFileExtensionManager
    {
        bool IsValid(string fileName);
    }

    public class FileExtensionManager : IFileExtensionManager
    {
        public bool IsValid(string fileName)
        {
            // read some file here
            return true;
        }
    }

    public class AlwaysValidFakeExtensionManager : IFileExtensionManager
    {
        public bool IsValid(string fileName)
        {
            return true;
        }
    }
}