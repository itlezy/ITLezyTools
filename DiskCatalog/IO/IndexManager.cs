using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using Alphaleonis.Win32.Filesystem;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Itlezy.App.DiskCatalog.IO
{
    public class IndexManager
    {
        //  Index Directory
        //    00000_VolumeID_PathID.xml
        //
        //  The Index Manager has to
        //   * load an IndexSet
        //   * save an IndexSet

        private IndexSet indexSet;

        public IndexManager(IndexSet indexSet)
        {
            this.indexSet = indexSet;
        }

        public static IndexSet LoadOrCreateIndexSet(IndexSetInitMetadata metadata)
        {
            var indexSet = new IndexSet();

            indexSet.Metadata.Name = metadata.Name;
            indexSet.Metadata.Path = metadata.Path;

            if (!Directory.Exists(metadata.Path))
            {
                Directory.CreateDirectory(metadata.Path);
            }

            if (!File.Exists(metadata.IndexFilePath))
            {
                File.WriteAllText(metadata.IndexFilePath, metadata.Name);
            }

            foreach (var f in Directory.GetFiles(indexSet.Metadata.Path, "*.xml"))
            {
                try
                {
                    indexSet.Indexes.Add(LoadIndex(f));
                }
                catch (InvalidOperationException iex)
                {
                    Console.Error.WriteLine("Invalid index file {0}, skipping..", f);
                }
            }

            return indexSet;
        }

        public void AddIndexToIndexSet(String path)
        {
            var index = new Index();

            var files = Alphaleonis.Win32.Filesystem.Directory.EnumerateFileSystemEntryInfos<FileSystemEntryInfo>(
                            path,
                            "*.*",
                            DirectoryEnumerationOptions.ContinueOnException |
                            DirectoryEnumerationOptions.FilesAndFolders |
                            DirectoryEnumerationOptions.Recursive);

            foreach (var fi in files)
            {
                if (fi.IsMountPoint || fi.IsReparsePoint || fi.IsSymbolicLink)
                {
                    continue;
                }

                index.Items.Add(ToItem(fi));
            }

            indexSet.Indexes.Add(index);
        }



        private IndexItem ToItem(FileSystemEntryInfo fi)
        {
            var hash = fi.IsDirectory ? String.Empty : new QuickSha().Compute(fi);

            return new IndexItem()
            {
                Path = fi.FullPath,
                Size = fi.IsDirectory ? 0 : fi.FileSize,
                ItemType = fi.IsDirectory ? ItemType.Directory : ItemType.File,
                Hash = hash
            };
        }

        public void Save()
        {
            int i = 0;
            foreach (var index in indexSet.Indexes)
            {
                SaveIndex(index,
                    indexSet.Metadata.Path + Path.DirectorySeparator +
                    indexSet.Metadata.Name + "_" + i.ToString("000000") + ".xml");
                i++;
            }
        }

        private void SaveIndex(Index index, String filePath)
        {
            using (var writer = new System.IO.StreamWriter(filePath))
            {
                new XmlSerializer(typeof(Index)).Serialize(writer, index);
            }
        }

        private static Index LoadIndex(String filePath)
        {
            using (var reader = new System.IO.StreamReader(filePath))
            {
                return new XmlSerializer(typeof(Index)).Deserialize(reader) as Index;
            }
        }

        public IList<SearchResult> SearchFor(String searchFor)
        {
            var results = new List<SearchResult>();

            foreach (var index in indexSet.Indexes)
            {
                foreach (var indexItem in index.Items)
                {
                    var searchResult = new SearchResult(indexItem);

                    if (Operators.LikeString(searchResult.Name, searchFor, CompareMethod.Text))
                    {
                        results.Add(searchResult);
                    }
                }
            }

            return results;
        }

        public System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.IList<Itlezy.App.DiskCatalog.IO.SearchResult>>> Duplicates()
        {
            var dups = new Dictionary<String, IList<SearchResult>>();

            foreach (var index in indexSet.Indexes)
            {
                foreach (var indexItem in index.Items.Where(p => p.Hash != null && p.Hash.Length > 0))
                {
                    if (!dups.ContainsKey(indexItem.Hash))
                    {
                        dups.Add(indexItem.Hash, new List<SearchResult>());
                    }

                    dups[indexItem.Hash].Add(new SearchResult(indexItem));
                }
            }

            return dups.Where(p => p.Value.Count > 1);
        }
    }
}
