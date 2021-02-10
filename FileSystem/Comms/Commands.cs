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

        /// <summary>
        /// Execute the command that was typed in
        /// </summary>
        /// <param name="com"></param>
        public static void ExecuteCommand(string com = "")
        {
            if (IsValidCommand(com))
                return;
        }

        /// <summary>
        /// Test to see if the command is recognized.
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        private static bool IsValidCommand(string com = "")
        {
            foreach (var c in commands)
                if (c.command == com)
                    return true;

            return false;
        }
    }
}
