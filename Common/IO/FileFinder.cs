using System;
using System.Collections.Generic;
using Alphaleonis.Win32.Filesystem;

namespace Itlezy.Common.IO
{
    public class FileFinderOptions
    {
        public String SearchIn { get; set; }
        public String SearchPattern { get; set; }
        public System.IO.SearchOption SearchOption { get; set; }
    }

    public class FileFinder
    {
        public IEnumerable<String> FindFiles(FileFinderOptions options)
        {
            return
                Directory.GetFiles(
                options.SearchIn,
                options.SearchPattern,
                options.SearchOption);
        }
    }
}
