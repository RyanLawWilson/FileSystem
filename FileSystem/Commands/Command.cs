using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Commands
{
    class Command
    {
        // What you need to type into the console to run the Command.  Ex: cr
        public string command { get; set; }

        // The name of the command.  Ex: Create
        public string name { get; set; }

        // A short description of the Command
        public string description { get; set; }
    }
}
