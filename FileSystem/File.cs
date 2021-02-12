using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem
{
    class File : FileSystemObject
    {
        public File() : base() { size = "1 B"; }
        public File(string name) : base(name) { size = "1 B"; }
        public File(string name, string size) : this(name) { this.size = size; }

        public string type { get; set; }
    }
}
