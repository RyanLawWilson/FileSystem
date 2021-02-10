using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Comms
{
    public class Command
    {
        // What you need to type into the console to run the Command.  Ex: cr
        public string command { get; set; }

        // The name of the command.  Ex: Create
        public string name { get; set; }

        // A short description of the Command.  Ex: Creates a new file or folder
        public string description { get; set; }

        public Command(string comm, string name, string desc)
        {
            command = comm;
            this.name = name;
            description = desc;
        }

















        static void Add()
        {

        }






























    }
}
