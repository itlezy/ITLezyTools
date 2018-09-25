using Itlezy.Common;
using Itlezy.Common.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlezy.App.MoveToDateSubdirsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += ExceptionHandler.UnhandledExceptionTrapper;

            var options = new CommandLineOptions();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine("Using Date Pattern {0} = {1}", options.DatePattern, DateTime.Today.ToString(options.DatePattern));

                var inputPath = new Normalizer().NormalizeEnding(options.Input);

                var fileFinder = new FileFinder();
                var files = fileFinder.FindFiles(
                    new FileFinderOptions
                    {
                        SearchIn = inputPath,
                        SearchPattern = options.SearchPattern,
                        SearchOption = SearchOption.TopDirectoryOnly
                    });

                foreach (var file in files)
                {
                    var fi = new Alphaleonis.Win32.Filesystem.FileInfo(file);

                    //Console.WriteLine("{1} {2} {3} {0}", file, 
                    //    fi.CreationTime.ToString("yyyy-MM-dd"),
                    //    fi.LastAccessTime.ToString("yyyy-MM-dd"),
                    //    fi.LastWriteTime.ToString("yyyy-MM-dd")
                    //    );

                    var subDirName = options.DirNamePrefix + fi.LastWriteTime.ToString(options.DatePattern) + options.DirNameSuffix;
                    var subDirPath = inputPath + Path.DirectorySeparatorChar + subDirName;
                    var targetFilePath = inputPath + Path.DirectorySeparatorChar + subDirName + Path.DirectorySeparatorChar + fi.Name;

                    if (!Alphaleonis.Win32.Filesystem.Directory.Exists(subDirPath))
                    {
                        Alphaleonis.Win32.Filesystem.Directory.CreateDirectory(subDirPath);
                    }

                    if (!Alphaleonis.Win32.Filesystem.File.Exists(targetFilePath))
                    {
                        Alphaleonis.Win32.Filesystem.File.Move(fi.FullName, targetFilePath);
                    }
                }
            }
        }
    }
}
