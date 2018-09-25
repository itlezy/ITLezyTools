using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alphaleonis.Win32.Filesystem;

namespace Itlezy.App.DiskCatalog.IO
{
    public class SearchResult
    {
        private IndexItem indexItem;
        public IndexItem IndexItem { get { return this.indexItem; } }

        public SearchResult(IndexItem indexItem)
        {
            this.indexItem = indexItem;
        }

        public String Name
        {
            get
            {
                return Path.GetFileName(IndexItem.Path);
            }
        }

        public override string ToString()
        {
            return String.Format("{0,-10} {1}", indexItem.ItemType, Name);
        }
    }
}
