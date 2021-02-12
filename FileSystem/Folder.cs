using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem
{
    public class Folder : FileSystemObject
    {
        public Folder() : base() { }
        public Folder(string name) : base(name) { }
        public Folder(Folder prev) : base() { ParentFolder = prev; }
        public Folder(string name, Folder prev) : base(name) { ParentFolder = prev; }
        public Folder(string name, List<FileSystemObject> objs) : this(name)
        {
            ContainedObjects = objs;

            // Set each Folder's prevFolder property in the list of objects to 'this' Folder.
            foreach (var obj in ContainedObjects)
                if (obj is Folder f)
                    f.ParentFolder = this;

        }

        public Folder ParentFolder { get; set; }

        public List<FileSystemObject> ContainedObjects { get; set; }

        public void Path()
        {
            Console.WriteLine(CalculatePath(this));
        }

        private StringBuilder CalculatePath(Folder f)
        {
            StringBuilder sb = new StringBuilder("");

            if (f == null)
                return sb;

            return sb.Append(CalculatePath(f.ParentFolder) + f.Name + " > ");
        }
    }
}
