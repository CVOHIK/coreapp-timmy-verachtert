using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Omschr { get; set; }

        public static implicit operator Product(string v)
        {
            throw new NotImplementedException();
        }
    }
}
