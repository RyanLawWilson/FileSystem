using FileSystem.Comms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem
{
    public class FileSystem
    {
        public FileSystem()
        {
            InitCommands();
            InitFileSystem();
        }

        public List<FileSystemObject> FileSystemObjects { get; set; }

        public List<Command> Commands { get; set; }

        // The folder that you are currently looking in.  Any added or removed folders will be created/removed from this folder.
        // The place where the command will be executed.
        public Folder ActiveFolder { get; set; }





        ///// <summary>
        ///// Execute the command that was typed in
        ///// </summary>
        ///// <param name="com"></param>
        //public void ExecuteCommand(Stack<string> words = null)
        //{
        //    if (words == null || words.Count == 0)
        //        return;

        //    Command com = commands.Find(c => c.command == words.Pop());
        //    if (com == null) return;

        //    com.Execute(this, words);
        //}





        /// <summary>
        /// Initialize the Commands for the File System.
        /// </summary>
        private void InitCommands()
        {
            Commands = new List<Command>()
            {
                new Command("add", "Add", "Adds a file or folder to the file system based on the name provided"),
                new Command("rem", "Remove", "Remove a file or folder that matches the name provided"),
                new Command("dir", "Show Directory", "Shows all of the objects in the active folder"),
                new Command("cd", "Change Directory", "Change active directories")
            };
        }

        /// <summary>
        /// Initialize the File System with several Files and Folders
        /// </summary>
        private void InitFileSystem()
        {
            Folder c_drive = new Folder("C:", new List<FileSystemObject>()
            {
                new Folder("Documents", new List<FileSystemObject>()
                {
                    new Folder("School"),
                    new Folder("Work")
                }),
                new Folder("Desktop", new List<FileSystemObject>() { 
                    new File("cool_img", "jpg", "12 MB"),
                    new File("stories", "txt"),
                    new File("file"),
                    new Folder("Resumes", new List<FileSystemObject>() { 
                        new Folder("2020 Resumes"),
                        new Folder("2021 Resumes")
                    })
                }),
                new File("todolist", "txt"),
                new Folder("Downloads"),
                new File("some image", "png")
            });

            ActiveFolder = c_drive;

            FileSystemObjects = new List<FileSystemObject>() { c_drive };
        }


        public void Print()
        {
            string printString = "";
            foreach (var obj in FileSystemObjects)
                if (obj is Folder f)
                    printString += CalculatePrintString(f);
        }

        private string CalculatePrintString(Folder f, int depth = 0)
        {
            //if (f == null)
            //    return 
            //string s = "";




            return null;
        }
    }
}
