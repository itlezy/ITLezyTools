using System;
using System.Runtime.InteropServices;
using CommandLine;
using CommandLine.Text;

namespace Itlezy.App.MoveToDateSubdirsApp
{
	public class CommandLineOptions
	{
		[Option('i', "Input", Required = false, DefaultValue = ".",
            HelpText = "Input Directory")]
		public string Input { get; set; }

        [Option('s', "Search Pattern", Required = false, DefaultValue = "*",
            HelpText = "Search Pattern")]
        public string SearchPattern { get; set; }

        [Option('d', "Date Pattern", Required = false, DefaultValue = "MM",
            HelpText = "Date Pattern")]
        public string DatePattern { get; set; }

        [Option('p', "Prefix", Required = false, DefaultValue = "",
            HelpText = "Directory Name Prefix")]
        public string DirNamePrefix { get; set; }

        [Option('u', "Suffix", Required = false, DefaultValue = "",
            HelpText = "Directory Name Suffix")]
        public string DirNameSuffix { get; set; }

		[ParserState]
		public IParserState LastParserState { get; set; }

		[HelpOption]
		public string GetUsage() {
			return HelpText.AutoBuild(this,
			                          (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
		}
	}
}
