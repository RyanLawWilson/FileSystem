using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem
{
    class File : FileSystemObject
    {
        public File() : base() { Size = "1 B"; }
        public File(string name) : base(name) { Size = "1 B"; }
        public File(string name, string size) : this(name) { Size = size; }
        public File(string name, string size, string type) : this(name) { FileType = type; }

        public string FileType { get; set; }
    }
}
