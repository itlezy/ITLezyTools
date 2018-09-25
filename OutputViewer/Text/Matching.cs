using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itlezy.App.OutputViewer.Text
{
    public class Matching
    {
        private readonly ISet<SearchCriteria> errorLevel = new HashSet<SearchCriteria>() { 
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "ERROR " },
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "FATAL " },
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "SEVERE " },
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "Error:" }
        };

        private readonly ISet<SearchCriteria> errorLevelDetail = new HashSet<SearchCriteria>() { 
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "\tat " },
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "  at " },
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "! at " },
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "common frames omitted" },
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "Caused by" },
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "java.lang.Throwable" },
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "Exception" }
        };

        private readonly ISet<SearchCriteria> warningLevel = new HashSet<SearchCriteria>() { 
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "WARN " },
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "WARNING " },
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "WARNING:" },
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "Warning:" }
        };

        private readonly ISet<SearchCriteria> infoLevel = new HashSet<SearchCriteria>() { 
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "INFO " },
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "INFO:" },
            new SearchCriteria() { CaseSensitive = true, SearchTerm = "Info:" }
        };

        /// <summary>
        /// Used by Filtering
        /// </summary>
        public ISet<SearchCriteria> ErrorLevel { get { return errorLevel; } }
        public ISet<SearchCriteria> ErrorLevelDetail { get { return errorLevelDetail; } }
        public ISet<SearchCriteria> WarningLevel { get { return warningLevel; } }
        public ISet<SearchCriteria> InfoLevel { get { return infoLevel; } }

        /// <summary>
        /// Checks if the line matches the searchCriteria
        /// </summary>
        /// <param name="line"></param>
        /// <param name="searchCriteria"></param>
        /// <returns></returns>
        public bool Matches(String line, SearchCriteria searchCriteria)
        {
            return (line.IndexOf(searchCriteria.SearchTerm,
                                         searchCriteria.CaseSensitive ?
                                         StringComparison.Ordinal :
                                         StringComparison.OrdinalIgnoreCase) >= 0);
        }

        /// <summary>
        /// Checks if the line matches the searchCriteria
        /// </summary>
        /// <param name="line"></param>
        /// <param name="searchCriteria"></param>
        /// <returns></returns>
        public bool Matches(String line, ISet<SearchCriteria> searchCriteria)
        {
            foreach (SearchCriteria _searchCriteria in searchCriteria)
            {
                if (Matches(line, _searchCriteria))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Used by Highlighting
        /// </summary>
        public bool IsWarning(String line)
        {
            return Matches(line, warningLevel);
        }

        /// <summary>
        /// Used by Highlighting
        /// </summary>
        public bool IsError(String line)
        {
            return Matches(line, errorLevel);
        }

        /// <summary>
        /// Used by Highlighting
        /// </summary>
        public bool IsErrorDetail(String line)
        {
            return Matches(line, errorLevelDetail);
        }
    }
}
