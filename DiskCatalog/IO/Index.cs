using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Itlezy.App.DiskCatalog.IO
{
    public enum IndexState { New, Saved, Modified }

    public enum IndexType { Disk, RemovableDisk, OpticalDisk, Directory, Archive }

    [Serializable]
    public class IndexMetadata
    {
        [XmlIgnore]
        public IndexState State { get; set; }

        [XmlAttribute]
        public IndexType IndexType { get; set; }

        [XmlAttribute]
        public String IndexNumber { get; set; }

        [XmlElement]
        public String VolumeId { get; set; }

        [XmlElement]
        public String PathId { get; set; }
    }

    [XmlRoot]
    [Serializable]
    public class Index
    {
        private List<IndexItem> items;
        private IndexMetadata metadata;

        public Index()
        {
            this.items = new List<IndexItem>();
            this.metadata = new IndexMetadata();
        }

        [XmlArray(Order = 2)]
        public List<IndexItem> Items { get { return items; } set { } }

        [XmlElement(Order = 1)]
        public IndexMetadata Metadata { get { return metadata; } set { } }

    }
}
