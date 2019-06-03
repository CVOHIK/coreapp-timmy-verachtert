using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webshop.Data;
using webshop.Models;

namespace webshop.Controllers
{
    public class ShoppingBagsController : Controller
    {
        private readonly webshopContext _context;

        public ShoppingBagsController(webshopContext context)
        {
            _context = context;
        }

        // GET: ShoppingBags
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bags.ToListAsync());
        }

        // GET: ShoppingBags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingBag = await _context.Bags
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shoppingBag == null)
            {
                return NotFound();
            }

            return View(shoppingBag);
        }

        // GET: ShoppingBags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingBags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,Price")] ShoppingBag shoppingBag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingBag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingBag);
        }

        // GET: ShoppingBags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingBag = await _context.Bags.FindAsync(id);
            if (shoppingBag == null)
            {
                return NotFound();
            }
            return View(shoppingBag);
        }

        // POST: ShoppingBags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,Price")] ShoppingBag shoppingBag)
        {
            if (id != shoppingBag.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingBag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingBagExists(shoppingBag.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingBag);
        }

        // GET: ShoppingBags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingBag = await _context.Bags
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shoppingBag == null)
            {
                return NotFound();
            }

            return View(shoppingBag);
        }

        // POST: ShoppingBags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingBag = await _context.Bags.FindAsync(id);
            _context.Bags.Remove(shoppingBag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingBagExists(int id)
        {
            return _context.Bags.Any(e => e.ID == id);
        }
    }
}
