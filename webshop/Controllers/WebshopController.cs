using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webshop.Data;
using webshop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webshop.Controllers
{
    public class WebshopController : Controller
    {
        private readonly webshopContext _context;

        public WebshopController(webshopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        // GET: /<controller>/
        public IActionResult List()
        {
            var products = _context.Products;
            ViewData["products"] = products.ToList();
            return View();
        }
        public IActionResult Detail(int id)
        {
            var product = _context.Products.Where(p => p.ID == id).Single();
            return View(product);
        }

        // GET: /Webshop/Products
        public IActionResult Winkelwagen(int id) {
            var products = _context.Products;
            ViewData["products"] = products.ToList();
            return View();
        }
        //POST: /Webshop/Winkelwagen/S
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Winkelwagen([Bind("Quantity,ProductID,BagID")]ShoppingItem item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View();
        }
    }
}