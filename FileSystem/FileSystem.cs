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
        }

        private void InitCommands()
        {
            commands = new List<Command>()
            {
                new Command("add", "Add", "Adds a file or folder to the file system based on the name provided"),
                new Command("rem", "Remove", "Remove a file or folder that matches the name provided")
            };
        }

        /// <summary>
        /// Execute the command that was typed in
        /// </summary>
        /// <param name="com"></param>
        public void ExecuteCommand(FileSystem sys, string com = "")
        {
            if (sys == null)
                return;

            switch (com)
            {
                case "add":
                    break;
                case "rem":
                    break;
            }
        }
    }
}
