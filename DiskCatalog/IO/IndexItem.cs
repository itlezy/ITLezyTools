using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Itlezy.App.DiskCatalog.IO
{
    public enum ItemType { Directory, File, Archive }

    [Serializable]
    public class IndexItem
    {
        [XmlElement]
        public String Path { get; set; }

        [XmlAttribute]
        public String Hash { get; set; }

        public bool ShouldSerializeHash()
        {
            return !String.IsNullOrEmpty(Hash);
        }

        [XmlAttribute]
        public ItemType ItemType { get; set; }

        [XmlAttribute]
        public Int64 Size { get; set; }

        public bool ShouldSerializeSize()
        {
            return ItemType == IO.ItemType.Archive || ItemType == IO.ItemType.File;
        }

        public override string ToString()
        {
            return String.Format("{0,-12} {1}", ItemType, Path);
        }

    }
}
