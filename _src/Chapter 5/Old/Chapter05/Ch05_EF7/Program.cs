using static System.Console;
using Microsoft.Data.Entity;
namespace Ch05_EF7
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Northwind();
            var query = db.Categories.Include(c => c.Products);
            foreach (var item in query)
            {
                WriteLine($"{item.CategoryName} has {item.Products.Count} products.");
            }
        }
    }
}
