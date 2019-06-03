using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Models
{
    public class ShoppingBag
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ShoppingItem> Items { get; set; }
    }
}
