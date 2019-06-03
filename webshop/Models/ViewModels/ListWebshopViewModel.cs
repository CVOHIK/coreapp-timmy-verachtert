using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace webshop.Models.ViewModels
{
    public class ListWebshopViewModel
    {
        public List<ShoppingItem> shoppingItems { get; set; }
        public SelectList Products { get; set; }
        public int productID { get; set; }
    }
}
