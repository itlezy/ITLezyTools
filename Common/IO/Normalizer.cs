using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Itlezy.Common.IO
{
    public class Normalizer
    {
        public String NormalizeEnding(String path)
        {
            var ps = Path.DirectorySeparatorChar.ToString();

            while (path.EndsWith(ps) && path.Length > 0)
            {
                path = path.Substring(0, path.Length - 1);
            }

            return path;
        }
    }
}
