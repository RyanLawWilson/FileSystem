using FileSystem.Comms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem
{
    class FileSystem
    {
        public List<FileSystemObject> initialObjects { get; set; }

        public List<Command> commands { get; set; }

        public FileSystem()
        {
            InitCommands();
            InitFileSystem();
        }

        

        /// <summary>
        /// Execute the command that was typed in
        /// </summary>
        /// <param name="com"></param>
        public void ExecuteCommand(string[] words = null)
        {
            if (words == null || words.Length == 0)
                return;
        }






        private void InitCommands()
        {
            commands = new List<Command>()
            {
                new Command("add", "Add", "Adds a file or folder to the file system based on the name provided"),
                new Command("rem", "Remove", "Remove a file or folder that matches the name provided")
            };
        }

        private void InitFileSystem()
        {
            Folder documents = new Folder("Documents");

            documents.objects = new List<FileSystemObject>()
            {
                new Folder()
                {
                    name = "School",
                    prevFolder = documents
                },
                new Folder()
                {
                    name = "Work",
                    prevFolder = documents
                }
            };

            initialObjects = new List<FileSystemObject>()
            {
                new Folder()
                {
                    name = "Dektop"
                },
                documents,
                new Folder()
                {
                    name = "Downloads"
                },
                new File()
                {
                    name = "some image",
                    type = "png"
                }
            };
        }
    }
}
