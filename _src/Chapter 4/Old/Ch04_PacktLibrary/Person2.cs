using System;

namespace Packt.LearningCS
{
    public partial class Person : IComparable<Person>
    {
        // properties
        public string Origin // C# 1.0 - 5.0 syntax
        {
            get
            {
                return $"  {Name} was born on {HomePlanet}";
            }
        }

        public string Greeting => $"  {Name} says 'Hello!'"; // C# 6.0 syntax

        public int Age => (int)(DateTime.Today.Subtract(DateOfBirth).TotalDays / 365.25);

        public string FavouriteIceCream { get; set; } // auto-syntax

        private string favouritePrimaryColour;
        public string FavouritePrimaryColour
        {
            get
            {
                return favouritePrimaryColour;
            }
            set
            {
                switch (value.ToLower())
                {
                    case "red":
                    case "green":
                    case "blue":
                        favouritePrimaryColour = value;
                        break;
                    default:
                        throw new ArgumentException($"{value} is not a primary colour. Choose from: red, green, blue.");
                }
            }
        }

        // indexers
        public Person this[int index]
        {
            get
            {
                return Children[index];
            }
            set
            {
                Children[index] = value;
            }
        }

        // method to "multiply"
        public Person Procreate(Person partner)
        {
            return new Person("Baby");
        }

        // operator to "multiply"
        public static Person operator *(Person p1, Person p2) => new Person("Baby");

        // delegate example
        public int MethodIWantToCall(string input)
        {
            return input.Length;
        }

        // events
        public event EventHandler Shout;
        public int AngerLevel;
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                if (Shout != null)
                {
                    Shout(this, EventArgs.Empty);
                }
            }
        }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
