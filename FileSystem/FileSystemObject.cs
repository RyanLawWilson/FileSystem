using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem
{
    public abstract class FileSystemObject
    {
        public FileSystemObject()
        {
            Created = DateTime.Now;
        }

        public FileSystemObject(string name)
        {
            Created = DateTime.Now;
            Name = name;
        }

        public string Name { get; set; }

        public string Size { get; set; }

        public DateTime Created { get; set; }
    }
}
