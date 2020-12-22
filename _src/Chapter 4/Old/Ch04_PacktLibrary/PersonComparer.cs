using System.Collections.Generic;

namespace Packt.LearningCS
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Name.Length.CompareTo(y.Name.Length);
        }
    }
}
