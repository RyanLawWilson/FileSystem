﻿using FileSystem.Comms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem
{
    public class FileSystem
    {
        public List<FileSystemObject> objects { get; set; }

        public List<Command> commands { get; set; }

        // The folder that you are currently looking in.  Any added or removed folders will be created/removed from this folder.
        // The place where the command will be executed.
        public Folder activeFolder { get; set; }

        public FileSystem()
        {
            InitCommands();
            InitFileSystem();
        }

        

        ///// <summary>
        ///// Execute the command that was typed in
        ///// </summary>
        ///// <param name="com"></param>
        //public void ExecuteCommand(Stack<string> words = null)
        //{
        //    if (words == null || words.Count == 0)
        //        return;

        //    Command com = commands.Find(c => c.command == words.Pop());
        //    if (com == null) return;

        //    com.Execute(this, words);
        //}





        /// <summary>
        /// Initialize the Commands for the File System.
        /// </summary>
        private void InitCommands()
        {
            commands = new List<Command>()
            {
                new Command("add", "Add", "Adds a file or folder to the file system based on the name provided"),
                new Command("rem", "Remove", "Remove a file or folder that matches the name provided")
            };
        }

        /// <summary>
        /// Initialize the File System with several Files and Folders
        /// </summary>
        private void InitFileSystem()
        {
            Folder documents = new Folder("Documents");

            activeFolder = documents;

            documents.objects = new List<FileSystemObject>()
            {
                new Folder()
                {
                    name = "School",
                    prevFolder = documents
                },
                new Folder()
                {
                    name = "Work",
                    prevFolder = documents
                }
            };




            Folder school = new Folder("School");
            Folder docs = new Folder("Documents", null, new List<FileSystemObject>()
            {
                new Folder("School"),
                new Folder("Work")
            });





            objects = new List<FileSystemObject>()
            {
                new Folder()
                {
                    name = "Dektop"
                },
                documents,
                new Folder()
                {
                    name = "Downloads"
                },
                new File()
                {
                    name = "some image",
                    type = "png"
                }
            };
        }
    }
}
