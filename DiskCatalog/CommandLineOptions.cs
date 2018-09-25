using System;
using System.Runtime.InteropServices;
using CommandLine;
using CommandLine.Text;

namespace Itlezy.App.DiskCatalog
{
    public static class Operations
    {
        public const String AddToIndex = "a";
        public const String Duplicates = "d";
        public const String SearchFor = "s";
    }

    public class CommandLineOptions
    {
        // add : DiskCatalog.exe -o a -x idx -i w:\w003
        // dup : DiskCatalog.exe -o d -x idx

        [Option('o', "Operation", Required = false, DefaultValue = "SearchFor",
            HelpText = "Operation: " + Operations.AddToIndex + ", " + Operations.SearchFor + ", " + Operations.Duplicates)]
        public string Operation { get; set; }

        [Option('x', "Index Path", Required = false, DefaultValue = ".",
            HelpText = "Index Path")]
        public string IndexPath { get; set; }

        [Option('n', "Index Name", Required = false, DefaultValue = "Index",
            HelpText = "Index Name")]
        public string IndexName { get; set; }

        [Option('i', "Input", Required = false, DefaultValue = ".",
            HelpText = "Directory To Add To Index")]
        public string Input { get; set; }

        [Option('s', "SearchFor", Required = false, DefaultValue = "*.*",
            HelpText = "Search for")]
        public string SearchFor { get; set; }

        [Option('z', "MinFileSize", Required = false, DefaultValue = 0,
            HelpText = "Minimum File Size (search)")]
        public int MinFileSize { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
                                      (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
