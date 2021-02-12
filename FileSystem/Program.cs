using System;
using System.Collections.Generic;
using System.Threading;
using FileSystem.Comms;

namespace FileSystem
{
    class Program
    {
        public static FileSystem sys = new FileSystem();

        static void Main(string[] args)
        {
            pln("Welcome to the file system");
            Thread.Sleep(1000);

            pln();
            pln("For a list of commands, type 'help'");


            Folder f1 = new Folder("Folder 1");
            Folder f2 = new Folder("Folder 2", f1);
            Folder f3 = new Folder("Folder 3", f2);
            Folder f4 = new Folder("Folder 4", f3);
            Folder f5 = new Folder("Folder 5", f4);

            f5.Path();


            string input = Console.ReadLine();
            while (input != "exit" || input != "Exit")
            {
                string[] words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Array.Reverse(words);
                Stack<string> wordStack = new Stack<string>(words);

                // If the input is valid, find the Command and if is a recognized command, execute it.
                if (wordStack == null || wordStack.Count == 0)
                {
                    // Find the command from the list of commands in the FileSystem
                    Command com = sys.commands.Find(c => c.command == wordStack.Pop());

                    if (com != null)
                        com.Execute(sys, wordStack);
                    else
                        Console.WriteLine("That is not a valid command");
                }

                // Ready for next command
                input = Console.ReadLine();
            }

            Console.Read();
        }







        static void pln(string s = "")
        {
            Console.WriteLine($"{sys.activeFolder}> " + s);
        }

        static void p(string s = "")
        {
            Console.Write(">> ");
        }
    }
}
