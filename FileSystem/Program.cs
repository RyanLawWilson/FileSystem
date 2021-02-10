using System;
using System.Threading;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            pln("Welcome to the file system");
            Thread.Sleep(1000);

            pln();
            pln("For a list of commands, type 'help'");





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
