using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        /// <summary>
        /// Return a string representing this Folders file path
        /// </summary>
        public string Path()
        {
            return CalculatePath(this).ToString();
        }

        private StringBuilder CalculatePath(Folder f)
        {
            StringBuilder sb = new StringBuilder("");

            if (f == null)
                return sb;

            return sb.Append(CalculatePath(f.ParentFolder) + f.Name + " > ");
        }

        /// <summary>
        /// Prints all of the contents of the folder
        /// </summary>
        public void PrintContents(bool SortByNameAscending = true)
        {
            //List<FileSystemObject> folders = new List<FileSystemObject>(ContainedObjects.Where(obj => obj is Folder));
            //List<FileSystemObject> files = new List<FileSystemObject>(ContainedObjects.Where(obj => obj is File));
            List<FileSystemObject> objs = new List<FileSystemObject>(ContainedObjects);

            //if (ShowFilesFirst)
            //{
            //    // Code that I found on https://stackoverflow.com/questions/3874853/how-to-sort-a-collection-based-on-type-in-linq
            //    // that sorts types.  This code sorts the collection so that Folders are first.
            //    objs.Sort((folder, file) =>
            //    {
            //        bool folderType = folder.GetType() == typeof(Folder);
            //        bool fileType = file.GetType() == typeof(Folder);
            //        return fileType.CompareTo(folderType);
            //    });
            //}

            if (SortByNameAscending)
            {
                objs.OrderBy(obj => obj.Name);
            }

            Console.WriteLine();

            foreach (var obj in objs)
            {
                if (obj is File f)
                    Console.WriteLine("  " + obj.Name + "." + f.FileType);
                else
                    Console.WriteLine("  " + obj.Name);
            }

            Console.WriteLine();
        }
    }
}
