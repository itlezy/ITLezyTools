using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Itlezy.App.DiskCatalog.IO;
using Itlezy.Common;
using System.IO;

namespace Itlezy.App.DiskCatalog
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += ExceptionHandler.UnhandledExceptionTrapper;

            var options = new CommandLineOptions();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if (String.IsNullOrWhiteSpace(options.Operation))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new UI.DiskCatalogMainForm());
                }
                else
                {
                    var idxManager = new IndexManager(
                                        IndexManager.LoadOrCreateIndexSet(
                                            new IndexSetInitMetadata()
                                            {
                                                Name = options.IndexName,
                                                Path = options.IndexPath
                                            }
                                        ));

                    switch (options.Operation)
                    {
                        case Operations.AddToIndex:

                            idxManager.AddIndexToIndexSet(options.Input);

                            idxManager.Save();

                            break;

                        case Operations.Duplicates:
                            {
                                var results = idxManager.Duplicates();

                                using (var sCsv = File.CreateText("_dups.csv"))
                                using (var sMov = File.CreateText("_dups_move.cmd"))
                                using (var sDele = File.CreateText("_dups_dele.cmd"))
                                {
                                    sMov.WriteLine("SET TGT=c:\\tmp\\dup\\");
                                    sMov.WriteLine("IF NOT EXIST \"%TGT%\" MKDIR \"%TGT%\"");
                                    sMov.WriteLine();

                                    var c = 0;

                                    foreach (var resultList in results)
                                    {
                                        var resultListValue = resultList.Value;

                                        foreach (var result in resultListValue)
                                        {
                                            if (result.IndexItem.Size > (1024 * 1024 * 4))
                                            {

                                                var s = String.Format(
                                                "{2},{3},\"{0}\",\"{1}\"",
                                                result.Name, result.IndexItem.Path, result.IndexItem.Size, result.IndexItem.Hash);

                                                sCsv.WriteLine(s);

                                                var dn = Path.GetDirectoryName(result.IndexItem.Path);

                                                sMov.WriteLine(
                                                    "IF EXIST \"{2}\" ROBOCOPY /E \"{0}\" \"%TGT%{1}\"",
                                                    dn,
                                                    Path.GetFileName(dn),
                                                    result.IndexItem.Path
                                                    );

                                                sMov.WriteLine("ECHO {0} / {1}", c++, results.Count());

                                            }
                                        }
                                    }

                                    foreach (var resultList in results)
                                    {
                                        var resultListValue = resultList.Value;

                                        foreach (var result in resultListValue)
                                        {
                                            if (result.IndexItem.Size > (1024 * 1024 * 4))
                                            {
                                                var dn = Path.GetDirectoryName(result.IndexItem.Path);

                                                sDele.WriteLine(
                                                   //"IF EXIST \"{1}\" RMDIR /S /Q \"{0}\"",
                                                   "IF EXIST \"{0}\" DEL /F /Q \"{0}\"",
                                                   result.IndexItem.Path
                                                   );

                                            }
                                        }
                                    }

                                }

                            }

                            break;

                        case Operations.SearchFor:
                            {
                                var results = idxManager.SearchFor(options.SearchFor);

                                foreach (var result in results.OrderBy(r => r.IndexItem.ItemType).ThenBy(r => r.Name))
                                {
                                    if (result.IndexItem.ItemType == ItemType.Directory ||
                                        result.IndexItem.Size > options.MinFileSize)
                                    {
                                        Console.WriteLine(
                                            "{0,-10} {2} {1}",
                                            result.IndexItem.ItemType, result.Name, result.IndexItem.Path.Substring(0, 8));
                                    }
                                }
                            }

                            break;

                        default:
                            break;
                    }

                }
            }
        }
    }
}
