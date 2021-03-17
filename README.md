# <p align="center">Custom File System</p>
This project is a C# Console Application that simulates a File System.  Users can add, remove, and rename files and folders.  C# classes represent the files and folders that the user changes.  If a user wants to know what commands they can use, they can type in `help` to see a list of all commands.  You can even type in `help add` to see how to use the `add` command, for example.  Below you can take a look at the UML Class diagram that I created using draw.io.


<div align="center" width="300px">

<span>*contents*</span>
<br>
**[UML class Diagram](#uml-class-diagram) • [Program](#Program) • [File System](#file-system) • [Command](#command) • [File System Object](#fso) • [File](#file) • [Folder](#folder)**

</div>

<br>

<div align="center">

| **<div align="center">Technologies/Skills Used</div>** |
| --- |
| **C# • OOP • UML • Recursion • Data Structures** |

</div>

*UML class diagram*
<img src="./FileSystem/documents/class_diagram.png" name="uml-class-diagram">

## **<p align="center">File System Object</p>**






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
