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
                    ExecuteAdd(sys, words);
                    break;
                case "dir":
                    sys.ActiveFolder.PrintContents();
                    break;
                case "cd":
                    ExecuteChangeDirectory(sys, words);
                    break;
                case "r":
                    ExecuteRemove(sys, words);
                    break;
                case "ren":
                    ExecuteRename(sys, words);
                    break;
                case "help":
                    ExecuteHelp(sys, words);
                    break;
            }
        }

        private static void ExecuteHelp(FileSystem sys, Stack<string> words)
        {
            if (words.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.WriteLine(" Command | Name of Command: Description ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;

                foreach (Command com in sys.Commands)
                    Console.WriteLine($"  {com.CommandWord}\t| {com.Name}: {com.Description}");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("  To see a command's syntax, type 'help [command]'.  Ex: 'help add'");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            string commandHelp = words.Pop();

            switch (commandHelp)
            {
                case "add":
                    Console.WriteLine();
                    Console.WriteLine("  Add a folder in the active folder:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("    add [folder_name]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("  Add a file in the active folder:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("    add [file_name].[file_type]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    break;
                case "r":
                    Console.WriteLine();
                    Console.WriteLine("  Remove a folder in the active folder:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("    r [folder_name]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("  Remove a file in the active folder:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("    r [file_name].[file_type]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    break;
                case "dir":
                    Console.WriteLine();
                    Console.WriteLine("  Look at the contents of the active folder:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("    dir");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    break;
                case "cd":
                    Console.WriteLine();
                    Console.WriteLine("  Change to a folder that is located in the active folder");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("    cd [folder_name]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("  Move back one folder from the active folder:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("    cd b");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    break;
                case "ren":
                    Console.WriteLine();
                    Console.WriteLine("  Rename a folder located in the active folder:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("    ren [folder_name] [new_folder_name]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("  Rename a file located in the active folder:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("    ren [file_name].[file_type] [new_file_name]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    break;
                case "help":
                    Console.WriteLine();
                    Console.WriteLine("  Display a list of all commands:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("    help");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("  Display the syntax of a specific command:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("    help [command]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    break;
            }
        }

        private static void ExecuteRename(FileSystem sys, Stack<string> words)
        {
            if (words.Count >= 0 && words.Count < 2)
            {
                Program.WriteError($"\n  Incorrect syntax.  Type 'help ren' for valid syntax\n", ConsoleColor.Yellow);
                return;
            }

            string objectToRename = words.Pop();
            string newName = words.Pop();
            string[] fileNameAndType = objectToRename.Split('.');
            if (fileNameAndType.Length > 2)
            {
                Program.WriteError($"\n  Invalid file.  Multiple '.' found\n", ConsoleColor.Yellow);
                return;
            }
            else if (fileNameAndType.Length == 2)
            {
                sys.ActiveFolder.ContainedObjects.FirstOrDefault(obj => obj.Name == fileNameAndType[0]).Name = newName;
            }
            else
            {
                sys.ActiveFolder.ContainedObjects.FirstOrDefault(obj => obj.Name == objectToRename).Name = newName;
            }
        }

        private static void ExecuteRemove(FileSystem sys, Stack<string> words)
        {
            if (words.Count == 0)
            {
                Program.WriteError($"\n  Incorrect syntax.  Type 'help r' for valid syntax\n", ConsoleColor.Yellow);
                return;
            }

            string objectToDelete = words.Pop();

            // Find a folder and remove it, otherwise, print an error.
            Folder foundObjectToDelete = (Folder)sys.ActiveFolder.ContainedObjects.FirstOrDefault(obj => obj.Name == objectToDelete);
            if (foundObjectToDelete != null)
                sys.ActiveFolder.ContainedObjects.Remove(foundObjectToDelete);
            else
                Program.WriteError($"\n  Could not find folder or file with name \"{objectToDelete}\"\n", ConsoleColor.Red);
        }

        private static void ExecuteChangeDirectory(FileSystem sys, Stack<string> words)
        {
            if (words.Count == 0)
            {
                Program.WriteError($"\n  Incorrect syntax.  Type 'help cd' for valid syntax\n", ConsoleColor.Yellow);
                return;
            }

            string folderToFind = words.Pop();
            // Go back implementation
            if (folderToFind == "..")
            {
                // If folder is a root folder, print an error, otherwise, change ActiveFolder to ActiveFolder's Parent folder.
                if (sys.ActiveFolder.ParentFolder == null)
                    Program.WriteError($"\n  {sys.ActiveFolder.Name} does not have a parent folder.\n", ConsoleColor.Red);
                else
                    sys.ActiveFolder = sys.ActiveFolder.ParentFolder;

                return;
            }

            // Find the folder we are looking for in the active folder's object list.
            Folder foundFolderToChangeTo = (Folder)sys.ActiveFolder.ContainedObjects.FirstOrDefault(obj => obj is Folder && obj.Name == folderToFind);
            if (foundFolderToChangeTo != null)
                sys.ActiveFolder = foundFolderToChangeTo;
            else
                Program.WriteError($"\n  Could not find folder with name \"{folderToFind}\"\n", ConsoleColor.Red);
        }

        private static void ExecuteAdd(FileSystem sys, Stack<string> words)
        {
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
        }
    }
}
