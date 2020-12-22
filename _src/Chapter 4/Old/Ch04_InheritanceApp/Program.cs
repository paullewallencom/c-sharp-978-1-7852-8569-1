using Packt.LearningCS;
using System;
using static System.Console;
namespace Ch04_InheritanceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee { Name = "John Jones", DateOfBirth = new DateTime(1990, 7, 28) };
            e1.WriteToConsole();
            e1.EmployeeCode = "JJ001";
            e1.HireDate = new DateTime(2014, 11, 23);
            WriteLine($"  {e1.Name} was hired on {e1.HireDate:dd/MM/yy}");
            WriteLine(e1.ToString());

            Employee aliceInEmployee = new Employee { Name = "Alice", EmployeeCode = "AA123" };
            Person aliceInPerson = aliceInEmployee;
            aliceInEmployee.WriteToConsole();
            aliceInPerson.WriteToConsole();
            WriteLine(aliceInEmployee.ToString());
            WriteLine(aliceInPerson.ToString());

            if (aliceInPerson is Employee)
            {
                Employee e2 = (Employee)aliceInPerson;
                // do something with e2
            }

            Employee e3 = aliceInPerson as Employee;
            if (e3 != null)
            {
                // do something with e3
            }
        }
    }
}
