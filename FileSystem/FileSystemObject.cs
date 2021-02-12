using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem
{
    public abstract class FileSystemObject
    {
        public FileSystemObject()
        {
            created = DateTime.Now;
        }

        public FileSystemObject(string name)
        {
            created = DateTime.Now;
            this.name = name;
        }

        public string name { get; set; }

        public string size { get; set; }

        public DateTime created { get; set; }
    }
}
