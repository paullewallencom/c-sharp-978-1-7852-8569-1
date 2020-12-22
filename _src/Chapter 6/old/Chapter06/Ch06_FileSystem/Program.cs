using static System.Console;
using System.IO;

namespace Ch06_FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // define a directory
            var dir = @"C:\Code\Ch06_Example\";

            // check if it exists
            WriteLine($"Does {dir} exist? {Directory.Exists(dir)}");

            // create a directory
            Directory.CreateDirectory(dir);
            WriteLine($"Does {dir} exist? {Directory.Exists(dir)}");

            // delete a directory
            Directory.Delete(dir);
            WriteLine($"Does {dir} exist? {Directory.Exists(dir)}");

            var textFile = @"C:\Code\Ch06.txt";
            var backupFile = $@"C:\Code\Ch06.bak";

            // check if a file exists
            WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");

            // create a new text file and write a line to it
            var textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello C#!");
            textWriter.Close();
            WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");

            // copy a file and overwrite if it already exists
            File.Copy(textFile, backupFile, true);
            WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");

            // delete a file
            File.Delete(textFile);
            WriteLine($"Does {textFile} exist? {File.Exists(textFile)}");

            // read from a text file
            var textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Close();

            // managing paths
            WriteLine($"File Name: {Path.GetFileName(textFile)}");
            WriteLine($"File Name without Extension: {Path.GetFileNameWithoutExtension(textFile)}");
            WriteLine($"File Extension: {Path.GetExtension(textFile)}");
            WriteLine($"Random File Name: {Path.GetRandomFileName()}");
            WriteLine($"Temporary File Name: {Path.GetTempFileName()}");

            // file details
            var backup = @"C:\Code\Ch06.bak";
            var info = new FileInfo(backup);
            WriteLine($"{backup} contains {info.Length} bytes.");
            WriteLine($"{backup} was last accessed {info.LastAccessTime}.");
            WriteLine($"{backup} has readonly set to {info.IsReadOnly}.");
        }
    }
}
