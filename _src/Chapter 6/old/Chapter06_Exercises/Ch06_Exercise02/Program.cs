using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using static System.Console;

namespace Ch06_Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathXml = @"C:\Code\Shapes.xml";
            string pathJson = @"C:\Code\Shapes.json";

            // create a list of Shapes
            var listOfShapes = new List<Shape>
            {
                new Circle { Colour = "Red", Radius = 2.5 },
                new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
                new Circle { Colour = "Green", Radius = 8 },
                new Circle { Colour = "Purple", Radius = 12.3 },
                new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0  }
            };

            var serializerXml = new XmlSerializer(typeof(List<Shape>));
            FileStream fileXml = File.Create(pathXml);
            serializerXml.Serialize(fileXml, listOfShapes);
            fileXml.Close();

            var serializerJson = new JavaScriptSerializer();
            StreamWriter fileJson = File.CreateText(pathJson);
            string json = serializerJson.Serialize(listOfShapes);
            fileJson.Write(json);
            fileJson.Close();

            WriteLine("Loading shapes from XML:");
            fileXml = File.Open(pathXml, FileMode.Open);
            var loadedShapesXml = (List<Shape>)serializerXml.Deserialize(fileXml);
            foreach (var item in loadedShapesXml)
            {
                WriteLine($"{item.GetType().Name} is {item.Colour} and has an area of {item.Area}");
            }
            WriteLine();
            //WriteLine("Loading shapes from JSON:");
            //json = File.ReadAllText(pathJson);
            //var loadedShapesJson = serializerJson.Deserialize<List<Shape>>(json);
            //foreach (var item in loadedShapesJson)
            //{
            //    WriteLine($"{item.GetType().Name} is {item.Colour} and has an area of {item.Area}");
            //}
        }
    }
}
