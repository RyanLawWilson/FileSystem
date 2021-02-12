using System;
using System.Collections.Generic;
using System.Threading;
using FileSystem.Comms;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystem sys = new FileSystem();

            pln("Welcome to the file system");
            Thread.Sleep(1000);

            pln();
            pln("For a list of commands, type 'help'");

            string input = Console.ReadLine();
            while (input != "exit" || input != "Exit")
            {
                string[] words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);



                sys.ExecuteCommand(words);

                input = Console.ReadLine();
            }

            Console.Read();
        }



























        static void pln(string s = "")
        {
            Console.WriteLine(">> " + s);
        }

        static void p(string s = "")
        {
            Console.Write(">> ");
        }
    }
}
