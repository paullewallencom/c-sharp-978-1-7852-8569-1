﻿using static System.Console;
using System.IO;

namespace Ch10_FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // define a directory
            string dir = @"C:\Code\Ch10_Example\";

            // check if it exists
            WriteLine($"Does {dir} exist? {Directory.Exists(dir)}");

            // create a directory
            Directory.CreateDirectory(dir);
            WriteLine($"Does {dir} exist? {Directory.Exists(dir)}");

            // delete a directory
            Directory.Delete(dir);
            WriteLine($"Does {dir} exist? {Directory.Exists(dir)}");

            string textFile = @"C:\Code\Ch10.txt";
            string backupFile = @"C:\Code\Ch10.bak";

            // check if a file exists
            WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");

            // create a new text file and write a line to it
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello C#!");
            textWriter.Dispose();
            WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");

            // copy a file and overwrite if it already exists
            File.Copy(textFile, backupFile, true);
            WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");

            // delete a file
            File.Delete(textFile);
            WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");

            // read from a text file
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Dispose();

            WriteLine($"File Name: {Path.GetFileName(textFile)}");
            WriteLine($"File Name without Extension: {Path.GetFileNameWithoutExtension(textFile)}");
            WriteLine($"File Extension: {Path.GetExtension(textFile)}");
            WriteLine($"Random File Name: {Path.GetRandomFileName()}");
            WriteLine($"Temporary File Name: {Path.GetTempFileName()}");

            string backup = @"C:\Code\Ch10.bak";
            FileInfo info = new FileInfo(backup);
            WriteLine($"{backup} contains {info.Length} bytes.");
            WriteLine($"{backup} was last accessed {info.LastAccessTime}.");
            WriteLine($"{backup} has readonly set to {info.IsReadOnly}.");

        }
    }
}
