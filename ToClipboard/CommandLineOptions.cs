using CommandLine;
using CommandLine.Text;

namespace Itlezy.App.ToClipboard
{
    public class CommandLineOptions
    {
        [Option('i', "Input", Required = true,
            HelpText = "Input File")]
        public string Input { get; set; }

        [Option('e', "Encoding", Required = false, DefaultValue="utf-8",
            HelpText = "Encoding")]
        public string Encoding { get; set; }

        [Option('b', "Binary", Required = false,
            HelpText = "Binary Mode")]
        public bool Binary { get; set; }

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
