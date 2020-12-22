using System.Text.RegularExpressions;
using static System.Console;

namespace Ch03_RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine();
            Write("  Enter your age: ");
            var input = ReadLine();
            var ageChecker = new Regex(@"\d");
            if (ageChecker.IsMatch(input))
            {
                WriteLine("  Thank you!");
            }
            else
            {
                WriteLine($"  This is not a valid age: {input}");
            }
            WriteLine();
        }
    }
}
