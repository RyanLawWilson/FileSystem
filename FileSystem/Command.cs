﻿using System;
using System.Collections.Generic;
using System.Linq;
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
                case "cd":
                    if (words.Count == 0)
                    {
                        //throw someException;
                        //break;
                    }

                    string folderToFind = words.Pop();
                    // Find the folder we are looking for in the active folder's object list.
                    Folder foundFolderToChangeTo = (Folder)sys.ActiveFolder.ContainedObjects.FirstOrDefault(obj => obj is Folder && obj.Name == folderToFind);
                    if (foundFolderToChangeTo != null)
                    {
                        sys.ActiveFolder = foundFolderToChangeTo;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n  Could not find folder with name \"{folderToFind}\"\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    break;
                case "r":
                    if (words.Count == 0)
                    {
                        //throw someException;
                        //break;
                    }

                    string objectToDelete = words.Pop();

                    Folder foundObjectToDelete = (Folder)sys.ActiveFolder.ContainedObjects.FirstOrDefault(obj => obj.Name == objectToDelete);
                    if (foundObjectToDelete != null)
                    {
                        sys.ActiveFolder.ContainedObjects.Remove(foundObjectToDelete);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n  Could not find folder or file with name \"{objectToDelete}\"\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    break;
                case "help":
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("  Command | Name of Command | Description");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    foreach (Command com in sys.Commands)
                    {
                        Console.WriteLine($"{com.CommandWord} | {com.Name} | {com.Description}");
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
