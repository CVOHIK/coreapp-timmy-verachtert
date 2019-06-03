using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Models
{
    public class ShoppingItem
    {
        public int ID { get; set; }
        public int Quantitiy { get; set; }
        public Product Product { get; set; }
        public ShoppingBag Bag { get; set; }
    }
}
