using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Itlezy.App.OutputViewer.Text
{
    public class SearchCriteria
    {
        public String SearchTerm { get; set; }
        public bool CaseSensitive { get; set; }
    }

    public class Search
    {
        private readonly Matching matching = new Matching();

        public String RegexExtract(String text, SearchCriteria searchCriteria)
        {
            try
            {
                new Regex(searchCriteria.SearchTerm, RegexOptions.ExplicitCapture);
            }
            catch (Exception)
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();
            StringBuilder sbLine = new StringBuilder();

            using (StringReader sr = new StringReader(text))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    Match match = Regex.Match(line, searchCriteria.SearchTerm,
                        searchCriteria.CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase);

                    int groupCtr = 0;

                    foreach (Group group in match.Groups)
                    {
                        groupCtr++;

                        if (groupCtr == 1)
                        {
                            continue;
                        }

                        int captureCtr = 0;

                        foreach (Capture capture in group.Captures)
                        {
                            captureCtr++;

                            sbLine.AppendFormat(
                                "{0}|",
                                capture.Value);
                        }
                    }

                    String appendLine = sbLine.ToString();
                    if (!String.IsNullOrWhiteSpace(appendLine))
                    {
                        sb.AppendLine(appendLine);
                    }
                    sbLine.Clear();
                }
            }

            return sb.ToString();
        }

        public String FilterText(String text, SearchCriteria searchCriteria)
        {
            return FilterText(text, new HashSet<SearchCriteria>() { searchCriteria });
        }

        public String FilterText(String text, ISet<SearchCriteria> searchCriteriaSet)
        {
            return FilterText(text, new List<ISet<SearchCriteria>>() { searchCriteriaSet });
        }

        public String FilterText(String text, IList<ISet<SearchCriteria>> searchCriteriaSetList)
        {
            StringBuilder sb = new StringBuilder();
            using (StringReader sr = new StringReader(text))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (ISet<SearchCriteria> searchCriteriaSet in searchCriteriaSetList)
                    {
                        foreach (SearchCriteria searchCriteria in searchCriteriaSet)
                        {
                            if (matching.Matches(line, searchCriteria))
                            {
                                sb.AppendLine(line);
                            }
                        }
                    }
                }
            }
            return sb.ToString();
        }
    }
}
