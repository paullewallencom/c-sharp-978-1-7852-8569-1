using Packt.LearningCS;
using System;
using static System.Console;

namespace Ch04_PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person();
            p1.Name = "Bob Smith";
            p1.DateOfBirth = new DateTime(1965, 12, 22);
            WriteLine($"  {p1.Name} was born on {p1.DateOfBirth:dddd, d MMMM yyyy}");

            p1.FavouriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            WriteLine($"  {p1.Name}'s favourite wonder is {p1.FavouriteAncientWonder}");

            p1.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            // p1.BucketList = (WondersOfTheAncientWorld)18;
            WriteLine($"  {p1.Name}'s bucket list is {p1.BucketList}");

            p1.Children.Add(new Person());
            p1.Children.Add(new Person());
            WriteLine($"  {p1.Name} has {p1.Children.Count} children.");

            BankAccount.InterestRate = 0.012M;
            var ba1 = new BankAccount();
            ba1.AccountName = "Mrs. Jones";
            ba1.Balance = 2400;
            WriteLine($"  {ba1.AccountName} earned {ba1.Balance * BankAccount.InterestRate:C} interest.");
            var ba2 = new BankAccount();
            ba2.AccountName = "Ms. Gerrier";
            ba2.Balance = 98;
            WriteLine($"  {ba2.AccountName} earned {ba2.Balance * BankAccount.InterestRate:C} interest.");

            var p2 = new Person { Name = "Alice Jones", DateOfBirth = new DateTime(1998, 3, 17) };
            WriteLine($"  {p2.Name} was born on {p2.DateOfBirth:d MMM yy}");
            WriteLine($"  {p1.Name} is a {Person.Species}");
            WriteLine($"  {p1.Name} was born on {p1.HomePlanet}");

            var p3 = new Person();
            WriteLine($"  {p3.Name} was instantiated at {p3.Instantiated:hh:mm:ss} on {p3.Instantiated:dddd, d MMMM yyyy}");

            var p4 = new Person("Aziz");
            WriteLine($"  {p4.Name} was instantiated at {p4.Instantiated:hh:mm:ss} on {p4.Instantiated:dddd, d MMMM yyyy}");

            p1.WriteToConsole();
            WriteLine(p1.GetOrigin());

            WriteLine(p1.SayHello());
            WriteLine(p1.SayHello("Emily"));

            p1.OptionalParameters();
            p1.OptionalParameters("Jump!", 98.5);
            p1.OptionalParameters(number: 52.7, command: "Hide!");
            p1.OptionalParameters("Poke!", active: false);

            var max = new Person { Name = "Max", DateOfBirth = new DateTime(1972, 1, 27) };
            WriteLine(max.Origin);
            WriteLine(max.Greeting);
            WriteLine($"  {max.Age}");
            max.FavouriteIceCream = "Chocolate Fudge";
            WriteLine($"  Max's favourite ice-cream flavour is {max.FavouriteIceCream}.");
            max.FavouritePrimaryColour = "Red";
            WriteLine($"  Max's favourite primary colour is {max.FavouritePrimaryColour}.");

            max.Children.Add(new Person { Name = "Charlie" });
            max.Children.Add(new Person { Name = "Ella" });
            WriteLine($"  Max's first child is {max.Children[0].Name}");
            WriteLine($"  Max's second child is {max.Children[1].Name}");
            WriteLine($"  Max's first child is {max[0].Name}");
            WriteLine($"  Max's second child is {max[1].Name}");

            var harry = new Person { Name = "Harry" };
            var mary = new Person { Name = "Mary" };
            var baby1 = harry.Procreate(mary);
            var baby2 = harry * mary;

            int answer = p1.MethodIWantToCall("Frog");

            var d = new DelegateWithMatchingSignature(p1.MethodIWantToCall);
            int answer2 = d("Frog");

            p1.Shout += P1_Shout;
            p1.Poke();
            p1.Poke();
            p1.Poke();
            p1.Poke();

            Person[] people = {
                new Person { Name = "Chris" },
                new Person { Name = "Adam" },
                new Person { Name = "Ben" }
            };
            Array.Sort(people);
            foreach (var person in people)
            {
                WriteLine($"  {person.Name}");
            }

            Array.Sort(people, new PersonComparer());
            foreach (var person in people)
            {
                WriteLine($"  {person.Name}");
            }

            var dv1 = new DisplacementVector(3, 5);
            var dv2 = new DisplacementVector(-2, 7);
            var dv3 = dv1 + dv2;
            WriteLine();
            WriteLine($"  ({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");
            WriteLine();
        }

        private static void P1_Shout(object sender, EventArgs e)
        {
            Person p = (Person)sender;
            WriteLine($"  {p.Name} is this angry: {p.AngerLevel}.");
        }
    }
    delegate int DelegateWithMatchingSignature(string s);
}
