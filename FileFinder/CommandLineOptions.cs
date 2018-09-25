using System;
using System.Runtime.InteropServices;
using CommandLine;
using CommandLine.Text;

namespace Itlezy.App.FileFinderApp
{
	public class CommandLineOptions
	{
		[Option('i', "Input", Required = false, DefaultValue = ".",
            HelpText = "Input Directory")]
		public string Input { get; set; }

        [Option('s', "Search Pattern", Required = false, DefaultValue = "*", 
            HelpText = "Search Pattern")]
        public string SearchPattern { get; set; }

        [Option('r', "Recursive", Required = false,
            HelpText = "Recurse Directories")]
        public bool Recursive { get; set; }

		[ParserState]
		public IParserState LastParserState { get; set; }

		[HelpOption]
		public string GetUsage() {
			return HelpText.AutoBuild(this,
			                          (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
		}
	}
}
