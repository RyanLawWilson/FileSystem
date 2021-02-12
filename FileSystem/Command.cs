using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Comms
{
    public class Command
    {
        public Command(string comm, string name, string desc)
        {
            CommandWord = comm;
            Name = name;
            Description = desc;
        }

        // What you need to type into the console to run the Command.  Ex: cr
        public string CommandWord { get; set; }

        // The name of the command.  Ex: Create
        public string Name { get; set; }

        // A short description of the Command.  Ex: Creates a new file or folder
        public string Description { get; set; }

        
        public void Execute(FileSystem sys, Stack<string> words)
        {
            switch (CommandWord)
            {
                case "add":
                    bool addCommandSwitch = false;

                    string fileSystemObjectName = words.Pop();



                    break;
            }
        }
    }
}
