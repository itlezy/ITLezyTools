using System;
using System.IO;
using Itlezy.Common;
using Itlezy.Common.IO;

namespace Itlezy.App.RecuDelete
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

                Console.WriteLine("Searching for files '{0}' in '{1}', recursive {2}, quiet mode {3}, simulate {4}",
                    options.SearchPattern,
                    inputPath,
                    options.Recursive,
                    options.Quiet,
                    options.Simulate);

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
                    var fi = new FileInfo(file);

                    if (!(fi.Length >= options.MinFileSize && fi.Length <= options.MaxFileSize))
                    {
                        Console.WriteLine("Skipping file '{0}', size {1}", file, fi.Length);
                        continue;
                    }

                    Console.WriteLine("Deleting file '{0}'", file);

                    try
                    {
                        if (!options.Quiet)
                        {
                            Console.WriteLine("Confirm [Y/N]?");
                        }

                        if (options.Quiet ||
                            ("y" == Console.ReadKey(true).KeyChar.ToString().ToLower()))
                        {
                            if (!options.Simulate)
                            {
                                FileOperation.Delete(file);
                            }

                            Console.WriteLine("File deleted '{0}'", file);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Unable to delete file '{0}', {1}", file, ex.Message);
                    }
                }
            }
        }
    }
}
