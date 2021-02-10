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
            sys.InitCommands();

            pln("Welcome to the file system");
            Thread.Sleep(1000);

            pln();
            pln("For a list of commands, type 'help'");

            string input = Console.ReadLine();
            while (input != "exit" || input != "Exit")
            {
                sys.ExecuteCommand(input);

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
