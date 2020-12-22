using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06_Exercise02
{
    public class Rectangle : Shape
    {
        public override double Area
        {
            get
            {
                return Height * Width;
            }
        }

        public double Height { get; set; }
        public double Width { get; set; }
    }
}
