using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06_Exercise02
{
    public class Circle : Shape
    {
        public override double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }

        public double Radius { get; set; }
    }
}
