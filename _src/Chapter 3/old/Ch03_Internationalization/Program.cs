using System;
using System.Globalization;
using System.Threading;
using static System.Console;

namespace Ch03_Internationalization
{
    class Program
    {
        static void Main(string[] args)
        {
            int
            WriteLine();
            var t = Thread.CurrentThread;
            WriteLine($"  The current globalization culture is {t.CurrentCulture.Name}: {t.CurrentCulture.DisplayName}");
            WriteLine($"  The current localization culture is {t.CurrentUICulture.Name}: {t.CurrentUICulture.DisplayName}");
            WriteLine();

            WriteLine("  en-US: English (United States)");
            WriteLine("  da-DK: Danish (Denmark)");
            WriteLine("  fr-CA: French (Canada)");
            Write("  Enter an ISO culture code: ");
            var newculture = ReadLine();
            if (!string.IsNullOrEmpty(newculture))
            {
                var ci = new CultureInfo(newculture);
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
            }

            Write($"  {Prompts.EnterYourName}");
            var name = ReadLine();
            Write($"  {Prompts.EnterYourDOB}");
            var dob = ReadLine();
            Write($"  {Prompts.EnterYourSalary}");
            var salary = ReadLine();
            WriteLine();

            var date = DateTime.Parse(dob);
            var minutes = DateTime.Today.Subtract(date).TotalMinutes;
            var earns = decimal.Parse(salary);
            WriteLine($"  {name} was born on a {date:dddd}, is {minutes:N0} minutes old and earns {earns:C}.");
            WriteLine();
        }
    }
}
