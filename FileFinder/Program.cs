using System;
using System.IO;
using Itlezy.Common;
using Itlezy.Common.IO;

namespace Itlezy.App.FileFinderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += ExceptionHandler.UnhandledExceptionTrapper;

            var options = new CommandLineOptions();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                var inputPath = options.Input;

                var fileFinder = new FileFinder();
                var files = fileFinder.FindFiles(
                    new FileFinderOptions
                    {
                        SearchIn = inputPath,
                        SearchPattern = options.SearchPattern,
                        SearchOption = options.Recursive ?
                            SearchOption.AllDirectories :
                            SearchOption.TopDirectoryOnly
                    });

                foreach (var file in files)
                {
                    Console.WriteLine("{0}", file);
                }
            }
        }
    }
}
