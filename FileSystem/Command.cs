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
                    //bool addCommandSwitch = false;
                    if (sys.ActiveFolder.ContainedObjects == null)
                    {
                        sys.ActiveFolder.ContainedObjects = new List<FileSystemObject>();
                    }

                    string fileSystemObjectName = words.Pop();

                    string objectName;
                    string fileType;
                    // Detemine if the User is adding a file or folder.  Users that specify files should
                    // type out the type of the file.  Users that want to add a folder should not specify a type.
                    if (fileSystemObjectName.Contains('.'))
                    {
                        string[] splitInput = fileSystemObjectName.Split('.');
                        if (splitInput.Length > 2)
                        {
                            //throw someException;
                        }
                        objectName = splitInput[0];
                        fileType = splitInput[1];

                        sys.ActiveFolder.ContainedObjects.Add(new File(objectName, fileType));
                    }
                    else
                    {
                        sys.ActiveFolder.ContainedObjects.Add(new Folder(fileSystemObjectName, sys.ActiveFolder));
                    }

                    break;
                case "dir":
                    sys.ActiveFolder.PrintContents();
                    break;
            }
        }
    }
}
