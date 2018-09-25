using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itlezy.App.DiskCatalog.IO
{
    public enum IndexSetState { New, Saved, Modified }

    public class IndexSetInitMetadata
    {
        public String Name { get; set; }
        public String Path { get; set; }
        public String IndexFilePath
        {
            get
            {
                return this.Path + System.IO.Path.DirectorySeparatorChar + ".idx";
            }
        }
    }

    public class IndexSetMetadata : IndexSetInitMetadata
    {
        public IndexSetState State { get; set; }
    }

    /// <summary>
    /// This is a Set of Indexes, which is the full index
    /// </summary>
    public class IndexSet
    {
        private List<Index> indexes;
        private IndexSetMetadata indexSetMetadata;

        public IndexSet()
        {
            this.indexes = new List<Index>();
            this.indexSetMetadata = new IndexSetMetadata();
        }

        public List<Index> Indexes { get { return this.indexes; } }
        public IndexSetMetadata Metadata { get { return this.indexSetMetadata; } }

    }
}
