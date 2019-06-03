using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public ICollection<ShoppingBag> Bags { get; set; }
    }
}
