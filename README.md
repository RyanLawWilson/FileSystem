# <p align="center">Custom File System</p>
This project is a C# Console Application that simulates a File System.  Users can add, remove, and rename files and folders.  C# classes represent the files and folders that the user changes.  If a user wants to know what commands they can use, they can type in `help` to see a list of all commands.  You can even type in `help add` to see how to use the `add` command, for example.  Below you can take a look at the UML Class diagram that I created using draw.io.


<div align="center" width="300px">

<span>*contents*</span>
<br>
**[UML class Diagram](#uml-class-diagram) • [Program](#program) • [File System](#file-system) • [Command](#command) • [File System Object](#fso) • [File](#file) • [Folder](#folder)**

</div>

<br>

<div align="center">

| **<div align="center">Technologies/Skills Used</div>** |
| --- |
| **C# • OOP • UML • Recursion • Data Structures** |

</div>

*UML class diagram*
<img src="./FileSystem/documents/class_diagram.png" name="uml-class-diagram">

## **<p align="center" name="command">Command</p>**
*Properties*<br>
`CommandWord` → The text that the user needs to type into the console to use this command<br>
`Name` → The human-readable name of the command<br>
`Description` → Short description of what the Command does.<br>

The Command class is responsible for performing operations on the File System.  The input from the user is sent to the Execute command as a Stack of strings.  Each string is the stack will do different things to the file system depending on the Execute Function.  For example, if the user wants to change directories, the Stack of strings will consist of one string: folder that the user is trying to get to.  If there are an unexpected number of strings in the Stack, an error is displayed to the console instead.

```csharp
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
```


## **<p align="center" name="file-system">File System</p>**
*Properties*<br>
`FileSystemObjects` → The Folder object whose ContainedObjects List contains this Folder.<br>
`Commands` → List of File System Objects that are in the folder.<br>
`ActiveFolder` → List of File System Objects that are in the folder.<br>

lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.

```csharp
// Initialize the Commands for the File System.
private void InitCommands()
{
    Commands = new List<Command>()
    {
        new Command("add", "Add", "Adds a file or folder to the file system based on the name provided"),
        new Command("r", "Remove", "Remove a file or folder that matches the name provided"),
        new Command("dir", "Show Directory", "Shows all of the objects in the active folder"),
        new Command("cd", "Change Directory", "Change active directories"),
        new Command("ren", "Rename", "Rename a file or folder"),
        new Command("help", "Help", "Get a list of all of the Commands"),
    };
}

// Initialize the File System with several Files and Folders
private void InitFileSystem()
{
    Folder c_drive = new Folder("C:", new List<FileSystemObject>()
    {
        new Folder("Documents", new List<FileSystemObject>()
        {
            new Folder("School"),

            ...
```


## **<p align="center" name="folder">Folder</p>**
*Properties*<br>
`ParentFolder` → The Folder object whose ContainedObjects List contains this Folder.<br>
`ContainedObjects` → List of File System Objects that are in the folder.<br><br>
The Folder class is a [FileSystemObject](#fso) so it inherits from the [FileSystemObject](#fso) abstract class.  The Folder's `Path` method uses a recursive `CalculatePath` method to get the Folder path of the current folder (usually the [ActiveFolder](#active-folder)).  The `CalculatePath` method constructs a StringBuilder of the path by traversing to the root folder one iteration at a time (by using the Folder's ParentFolder property) and returning the desired StringBuilder as the recursive method calls get removed from the call stack.
```csharp
/// <summary>
/// Return a string representing this Folders file path.
/// </summary>
public string Path()
{
    return CalculatePath(this).ToString();
}

/// <summary>
/// Recursive method to calculate the Folder path.
/// </summary>
/// <param name="f">The Folder you want to find the path of.</param>
/// <returns>StringBuilder object which contains the path.</returns>
private StringBuilder CalculatePath(Folder f)
{
    StringBuilder sb = new StringBuilder("");

    if (f == null)
        return sb;

    return sb.Append(CalculatePath(f.ParentFolder) + f.Name + " > ");
}
```




## **<p align="center" name="program">Program</p>**
*Properties*<br>
`Sys` → The FileSystem object for the program.<br>

lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.

```csharp
string input = Console.ReadLine();
while (input != "exit" && input != "Exit")
{
    string[] words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    Array.Reverse(words);
    Stack<string> wordStack = new Stack<string>(words);

    // If the input is valid, find the Command and if is a recognized command, execute it.
    if (wordStack != null && wordStack.Count != 0)
    {
        // Find the command from the list of commands in the FileSystem
        string firstWord = wordStack.Pop();
        Command com = Sys.Commands.Find(c => c.CommandWord == firstWord);

        // If valid Command, execute, otherwise, print error message.
        if (com != null)
            com.Execute(Sys, wordStack);
        else
            WriteError("\n  Command not recognized\n  For a list of commands, type 'help'\n", ConsoleColor.DarkYellow);
    }

    // Ready for next command
    Write();
    input = Console.ReadLine();
}
```



## **<p align="center" name="file">File</p>**
*Properties*<br>
`FileType` → The file extension of the file ("png", "txt", etc.)<br>

lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.

```csharp
class File : FileSystemObject
{
    public File() : base() { }
    public File(string name, string type = "") : base(name) { FileType = type; }
    public File(string name, string type, string size) : this(name, type) { Size = size; }

    public string FileType { get; set; }
}
```


## **<p align="center" name="fso">File System Object</p>**
*Properties*<br>
`Name` → The file extension of the file ("png", "txt", etc.)<br>
`Size` → The file extension of the file ("png", "txt", etc.)<br>
`Created` → The file extension of the file ("png", "txt", etc.)<br>

lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.  lorem ipsum.

```csharp
public abstract class FileSystemObject
{
    public FileSystemObject()
    {
        Created = DateTime.Now;
    }

    public FileSystemObject(string name)
    {
        Created = DateTime.Now;
        Name = name;
    }

    public string Name { get; set; }
    public string Size { get; set; }
    public DateTime Created { get; set; }
}
```