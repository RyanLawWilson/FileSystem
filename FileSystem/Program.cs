﻿using System;
using System.Collections.Generic;
using System.Threading;
using FileSystem.Comms;

namespace FileSystem
{
    class Program
    {
        public static FileSystem Sys = new FileSystem();

        static void Main(string[] args)
        {


            //Sys.ActiveFolder.PrintContents();

            WriteLine("Welcome to the file system");
            Thread.Sleep(1000);

            Console.WriteLine();
            WriteLine("For a list of commands, type 'help'");

            //TestPathImplementation();

            Write();
            string input = Console.ReadLine();
            while (input != "exit" || input != "Exit")
            {
                string[] words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Array.Reverse(words);
                Stack<string> wordStack = new Stack<string>(words);

                // If the input is valid, find the Command and if is a recognized command, execute it.
                if (wordStack != null && wordStack.Count != 0)
                {
                    // Find the command from the list of commands in the FileSystem
                    Command com = Sys.Commands.Find(c => c.CommandWord == wordStack.Pop());

                    if (com != null)
                        com.Execute(Sys, wordStack);
                    else
                        Console.WriteLine("That is not a valid command");
                }

                // Ready for next command
                Write();
                input = Console.ReadLine();
            }

            Console.Read();
        }



        public static void WriteLine(string s = "")
        {
            Console.WriteLine(Sys.ActiveFolder.Path() + " " + s);
        }

        public static void Write(string s = "")
        {
            Console.Write(Sys.ActiveFolder.Path() + " " + s);
        }

        /// <summary>
        /// For testing purposes.  Dipslay the path of a folder deep in the File System
        /// </summary>
        public static void TestPathImplementation()
        {
            Folder f1 = new Folder("Folder 1");
            Folder f2 = new Folder("Folder 2", f1);
            Folder f3 = new Folder("Folder 3", f2);
            Folder f4 = new Folder("Folder 4", f3);
            Folder f5 = new Folder("Folder 5", f4);

            f5.Path();
        }
    }
}
