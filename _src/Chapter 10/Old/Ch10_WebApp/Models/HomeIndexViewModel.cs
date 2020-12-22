using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch10_WebApp.Models
{
    public class HomeIndexViewModel
    {
        public int VisitorCount;
        public ICollection<Product> Products { get; set; }
    }
}
