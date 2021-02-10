using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Comms
{
    public class Commands
    {
        public static List<Command> commands { get; set; }

        public static List<Command> InitCommands()
        {
            return commands = new List<Command>()
            {
                new Command("add", "Add", "Adds a file or folder to the file system based on the name provided"),
                new Command("rem", "Remove", "Remove a file or folder that matches the name provided")
            };
        }
    }
}
