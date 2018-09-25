using Alphaleonis.Win32.Filesystem;

namespace Itlezy.Common.IO
{
    public class FileOperation
    {
        public static void Delete(string filePath)
        {
            File.SetAttributes(filePath, System.IO.FileAttributes.Normal);
            File.Delete(filePath);
        }
    }
}
