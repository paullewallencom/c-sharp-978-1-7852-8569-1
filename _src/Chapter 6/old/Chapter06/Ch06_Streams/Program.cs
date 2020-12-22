using static System.Console;
using System.IO;
using System.Xml;
using System.IO.Compression;

namespace Ch06_Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            // define an array of strings
            var callsigns = new string[] { "Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack" };

            // define a file to write to using a text writer helper 
            var textFile = @"C:\Code\Ch06_Streams.txt";
            StreamWriter text = File.CreateText(textFile);

            // enumerate the strings writing each one to the stream
            foreach (var item in callsigns)
            {
                text.WriteLine(item);
            }
            text.Close(); // close the stream

            // output all the contents of the file to the Console
            WriteLine($"{textFile} contains {new FileInfo(textFile).Length} bytes.");
            WriteLine(File.ReadAllText(textFile));

            // define a file to write to using the XML writer helper
            var xmlFile = @"C:\Code\Ch06_Streams.xml";
            XmlWriter xml = XmlWriter.Create(xmlFile, new XmlWriterSettings { Indent = true });

            // write the XML declaration
            xml.WriteStartDocument();

            // write a root element
            xml.WriteStartElement("callsigns");

            // enumerate the strings writing each one to the stream
            foreach (var item in callsigns)
            {
                xml.WriteElementString("callsign", item);
            }

            // write the close root element
            xml.WriteEndElement();
            xml.Close();

            // output all the contents of the file to the Console
            WriteLine($"{xmlFile} contains {new FileInfo(xmlFile).Length} bytes.");
            WriteLine(File.ReadAllText(xmlFile));

            // compress the XML output
            var gzipFilePath = @"C:\Code\Ch06.gzip";
            var gzipFile = File.Create(gzipFilePath);
            var compressor = new GZipStream(gzipFile, CompressionMode.Compress);
            var xmlGzip = XmlWriter.Create(compressor);
            xmlGzip.WriteStartDocument();
            xmlGzip.WriteStartElement("callsigns");
            foreach (var item in callsigns)
            {
                xmlGzip.WriteElementString("callsign", item);
            }
            xmlGzip.Close();
            compressor.Close(); // also closes the underlying stream

            // output all the contents of the compressed file to the Console
            WriteLine($"{gzipFilePath} contains {new FileInfo(gzipFilePath).Length} bytes.");
            WriteLine(File.ReadAllText(gzipFilePath));

            // read a compressed file
            WriteLine("Reading the compressed XML file:");
            gzipFile = File.Open(gzipFilePath, FileMode.Open);
            var decompressor = new GZipStream(gzipFile, CompressionMode.Decompress);
            var reader = XmlReader.Create(decompressor);
            while (reader.Read())
            {
                // check if we are currently on an element node named callsign
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
                {
                    reader.Read(); // move to the Text node inside the element
                    WriteLine($"{reader.Value}"); // read its value
                }
            }
            reader.Close();
            decompressor.Close();
        }
    }
}
