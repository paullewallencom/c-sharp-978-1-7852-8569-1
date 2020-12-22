using System.Collections.Generic;
using static System.Console;

namespace Ch03_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine();
            var cities = new List<string>();
            cities.Add("London");
            cities.Add("Paris");
            cities.Add("Milan");
            WriteLine("  Initial list");
            foreach (var city in cities)
            {
                WriteLine($"    {city}");
            }

            WriteLine($"  The first city is {cities[0]}."); // London
            WriteLine($"  The last city is {cities[cities.Count - 1]}."); // Milan

            cities.Insert(0, "Sydney");
            WriteLine("  After inserting Sydney at index 0");
            foreach (var city in cities)
            {
                WriteLine($"    {city}");
            }

            cities.RemoveAt(1);
            cities.Remove("Milan");
            WriteLine("  After removing two cities");
            foreach (var city in cities)
            {
                WriteLine($"    {city}");
            }
            WriteLine();

            
        }
    }
}
