using System;
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
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n  Incorrect syntax.  Type 'help cd' for valid syntax\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }

                    string folderToFind = words.Pop();
                    // Go back implementation
                    if (folderToFind == "..")
                    {
                        if (sys.ActiveFolder.ParentFolder == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\n  {sys.ActiveFolder.Name} does not have a parent folder.\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            sys.ActiveFolder = sys.ActiveFolder.ParentFolder;
                        }

                        break;
                    }

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
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n  Incorrect syntax.  Type 'help r' for valid syntax\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
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
                case "ren":
                    if (words.Count >= 0 && words.Count < 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n  Incorrect syntax.  Type 'help ren' for valid syntax\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }

                    string objectToRename = words.Pop();
                    string newName = words.Pop();
                    string[] fileNameAndType = objectToRename.Split('.');
                    if (fileNameAndType.Length > 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n  Invalid file.  Multiple '.' found\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    else if (fileNameAndType.Length == 2)
                    {
                        sys.ActiveFolder.ContainedObjects.FirstOrDefault(obj => obj.Name == fileNameAndType[0]).Name = newName;
                    }
                    else
                    {
                        sys.ActiveFolder.ContainedObjects.FirstOrDefault(obj => obj.Name == objectToRename).Name = newName;
                    }

                    break;
                case "help":
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
                        break;
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


                    break;
            }
        }
    }
}
