using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch05_Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Northwind();

            var distinctCities = db.Customers.Select(c => c.City).Distinct();
            WriteLine($"{string.Join(", ", distinctCities)}");
            WriteLine();

            Write("Enter the name of a city: ");
            var city = ReadLine();

            var customersInCity = db.Customers.Where(c => c.City == city);

            WriteLine($"There are {customersInCity.Count()} customers in {city}:");
            foreach (var item in customersInCity)
            {
                WriteLine($"{item.CompanyName}");
            }
        }
    }
}
