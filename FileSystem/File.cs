using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem
{
    class File : FileSystemObject
    {
        public File() : base() { }
        public File(string name, string type = "") : base(name) { FileType = type; }
        public File(string name, string type, string size) : this(name, type) { Size = size; }

        public string FileType { get; set; }
    }
}
