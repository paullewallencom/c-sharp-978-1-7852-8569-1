using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using static System.Console;

namespace Ch06_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // create an object graph
            var people = new List<Person>
            {
                new Person(30000M) { FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(1974, 3, 14) },
                new Person(40000M) { FirstName = "Bob", LastName = "Jones", DateOfBirth = new DateTime(1969, 11, 23) },
                new Person(20000M) { FirstName = "Charlie", LastName = "Rose", DateOfBirth = new DateTime(1964, 5, 4), Children = new HashSet<Person>
                    { new Person(0M) { FirstName = "Sally", LastName = "Rose", DateOfBirth = new DateTime(1990, 7, 12) } } }
            };

            // create a file to write to
            var xmlFilepath = @"C:\Code\Ch06_People.xml";
            var xmlStream = File.Create(xmlFilepath);

            // create an object that will format as List of Persons as XML
            var xs = new XmlSerializer(typeof(List<Person>));

            // serialize the object graph to the stream
            xs.Serialize(xmlStream, people);

            // you must close the stream to release the file lock
            xmlStream.Close();

            WriteLine($"Written {new FileInfo(xmlFilepath).Length} bytes of XML to {xmlFilepath}");
            WriteLine();

            // Display the serialized object graph
            WriteLine(File.ReadAllText(xmlFilepath));
            WriteLine();

            var xmlLoad = File.Open(xmlFilepath, FileMode.Open);
            // deserialize and cast the object graph into a List of Person
            var loadedPeople = (List<Person>)xs.Deserialize(xmlLoad);
            foreach (var item in loadedPeople)
            {
                WriteLine($"{item.LastName} has {item.Children.Count} children.");
            }
            WriteLine();

            // create a file to write to
            var jsonFilepath = @"C:\Code\Ch06_People.json";
            var jsonStream = File.Create(jsonFilepath);

            // create an object that will format as JSON
            var jss = new JavaScriptSerializer();

            // serialize the object graph into a string
            var json = jss.Serialize(people);

            // write the string to a file
            var writer = new StreamWriter(jsonStream);
            writer.Write(json);

            // you must close the stream to release the file lock
            writer.Close();

            WriteLine($"Written {new FileInfo(jsonFilepath).Length} bytes of JSON to: {jsonFilepath}");
            WriteLine();

            // Display the serialized object graph
            WriteLine(File.ReadAllText(jsonFilepath));
            WriteLine();

            var binaryFilepath = @"C:\Code\Ch06_People.bin";
            var binaryStream = File.Create(binaryFilepath);
            var bf = new BinaryFormatter();
            bf.Serialize(binaryStream, people);
            binaryStream.Close();

            WriteLine($"Written {new FileInfo(binaryFilepath).Length} bytes of proprietary binary to {binaryFilepath}");
            WriteLine();

            // Display the serialized object graph
            WriteLine(File.ReadAllText(binaryFilepath));
            WriteLine();
        }
    }
}
