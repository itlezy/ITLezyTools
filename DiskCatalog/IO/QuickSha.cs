using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Alphaleonis.Win32.Filesystem;

namespace Itlezy.App.DiskCatalog.IO
{
    public class QuickSha
    {
        const int BUF_SIZE = 1024 * 64;

        private String ByteArrayToString(byte[] array)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < array.Length; i++)
            {
                sb.AppendFormat("{0:x2}", array[i]);
            }

            return sb.ToString();
        }

        public String Compute(FileSystemEntryInfo fi)
        {
            try
            {
                using (var s = File.OpenRead(fi.FullPath))
                {
                    var b = new byte[(int)Math.Min(fi.FileSize, BUF_SIZE)];
                    s.Read(b, 0, b.Length);

                    return ByteArrayToString(new SHA256Managed().ComputeHash(b));
                }
            }
            catch (System.IO.IOException)
            {
                return String.Empty;
            }
        }
    }
}
