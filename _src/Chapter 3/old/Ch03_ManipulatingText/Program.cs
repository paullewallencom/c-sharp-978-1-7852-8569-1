using static System.Console;

namespace Ch03_ManipulatingText
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine();
            var city = "London";
            WriteLine($"  {city} is {city.Length} characters long.");
            WriteLine($"  First char is {city[0]} and third is {city[2]}.");
            WriteLine();

            var cities = "Paris,Berlin,Madrid,New York";
            var citiesArray = cities.Split(',');
            foreach (var item in citiesArray)
            {
                WriteLine($"  {item}");
            }
            WriteLine();

            var fullname = "Alan Jones";
            var indexOfTheSpace = fullname.IndexOf(' ');
            var firstname = fullname.Substring(0, indexOfTheSpace);
            var lastname = fullname.Substring(indexOfTheSpace + 1);
            WriteLine($"  {lastname}, {firstname}");
            WriteLine();

            var company = "Microsoft";
            var startsWithM = company.StartsWith("M");
            var containsN = company.Contains("N");
            WriteLine($"  Starts with M: {startsWithM}, contains an N: {containsN}");
            WriteLine();
        }
    }
}
