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
            List<Command> comms = Commands.InitCommands();

            pln("Welcome to the file system");
            Thread.Sleep(1000);

            pln();
            pln("For a list of commands, type 'help'");

            string input = Console.ReadLine();
            while (input != "exit" || input != "Exit")
            {
                Commands.ExecuteCommand(input);
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
