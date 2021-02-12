using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem
{
    class Folder : FileSystemObject
    {
        public Folder() : base() { }
        public Folder(string name) : base(name) { }

        public Folder prevFolder { get; set; }

        public List<FileSystemObject> objects { get; set; }
    }
}
