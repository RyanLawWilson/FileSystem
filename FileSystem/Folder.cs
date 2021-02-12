using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem
{
    public class Folder : FileSystemObject
    {
        public Folder() : base() { }
        public Folder(string name) : base(name) { }
        public Folder(Folder prev) : base() { prevFolder = prev; }
        public Folder(string name, Folder prev) : base(name) { prevFolder = prev; }
        public Folder(string name, Folder prev, List<FileSystemObject> objs) : this(name, prev)
        {
            objects = objs;

            // Set each Folder's prevFolder property in the list of objects to 'this' Folder.
            foreach (var obj in objects)
                if (obj is Folder f)
                    f.prevFolder = this;

        }

        public Folder prevFolder { get; set; }

        public List<FileSystemObject> objects { get; set; }

        public void PrintBreadcrumb()
        {
            Console.WriteLine(GetBreadcrumb(this));
        }

        private StringBuilder GetBreadcrumb(Folder f)
        {
            StringBuilder sb = new StringBuilder("");

            if (f == null)
                return sb;

            return sb.Append(GetBreadcrumb(f.prevFolder) + f.name + " > ");
        }
    }
}
