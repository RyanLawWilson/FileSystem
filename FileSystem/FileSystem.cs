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

        public void InitCommands()
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
        public void ExecuteCommand(string com = "")
        {
            if (IsValidCommand(com))
                return;
        }

        /// <summary>
        /// Test to see if the command is recognized.
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        private bool IsValidCommand(string com = "")
        {
            foreach (var c in commands)
                if (c.command == com)
                    return true;

            return false;
        }
    }
}
