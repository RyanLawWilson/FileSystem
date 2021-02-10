using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem
{
    abstract class FileSystemObject
    {
        public FileSystemObject()
        {
            created = DateTime.Now;
        }

        public string name { get; set; }

        public string size { get; set; }

        public DateTime created { get; set; }
    }
}
