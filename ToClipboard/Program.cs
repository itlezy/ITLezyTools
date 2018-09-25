using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Itlezy.Common;

namespace Itlezy.App.ToClipboard
{
    class Program
    {
        const int MAX_FILE_SIZE = (100 * 1024 * 1024);

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += ExceptionHandler.UnhandledExceptionTrapper;

            var options = new CommandLineOptions();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if (new FileInfo(options.Input).Length > MAX_FILE_SIZE)
                {
                    throw new ApplicationException(String.Format("File size exceeds limit {0}", MAX_FILE_SIZE));
                }

                Console.WriteLine(
                    "Copying content of '{0}' to Clipboard, Binary Mode {1}, Encoding '{2}'",
                    options.Input,
                    options.Binary,
                    options.Encoding);

                if (!options.Binary)
                {
                    Clipboard.SetText(
                        File.ReadAllText(
                            options.Input,
                            Encoding.GetEncoding(options.Encoding)));

                    Console.WriteLine(
                        "Content of '{0}' copied to Clipboard, Encoding '{1}'",
                        options.Input,
                        options.Encoding);
                }
                else
                {
                    Clipboard.SetText(
                        Encoding.ASCII.GetString(
                            File.ReadAllBytes(options.Input)));

                    Console.WriteLine(
                        "Content of '{0}' copied to Clipboard, Binary Mode",
                        options.Input);
                }

            }
        }
    }
}
