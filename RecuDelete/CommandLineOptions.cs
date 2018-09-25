using CommandLine;
using CommandLine.Text;

namespace Itlezy.App.RecuDelete
{
    public class CommandLineOptions
    {
        [Option('i', "Input", Required = true,
            HelpText = "Input Directory")]
        public string Input { get; set; }

        [Option('s', "Search Pattern", Required = false, DefaultValue = "*", 
            HelpText = "Search Pattern")]
        public string SearchPattern { get; set; }

        [Option('r', "Recursive", Required = false,
            HelpText = "Recurse Directories")]
        public bool Recursive { get; set; }

        [Option('q', "Quiet", Required = false, DefaultValue = false,
            HelpText = "Quiet Mode")]
        public bool Quiet { get; set; }

        [Option('m', "Simulate", Required = false, DefaultValue = false,
            HelpText = "Simulation Mode")]
        public bool Simulate { get; set; }

        [Option('n', "MinFileSize", Required = false, DefaultValue = 0,
            HelpText = "Minimum File Size")]    
        public int MinFileSize { get; set; }

        [Option('x', "MaxFileSize", Required = false, DefaultValue = int.MaxValue,
            HelpText = "Maximum File Size")]
        public int MaxFileSize { get; set; }

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
