using static System.Console;

namespace Ch03_Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 4.5;
            var b = 2.5;
            var answer = Add(a, b);
            WriteLine($"{a} + {b} = {answer}");
            ReadLine(); // wait for user to press ENTER
        }

        static double Add(double a, double b)
        {
            return a * b;
        }
    }
}
