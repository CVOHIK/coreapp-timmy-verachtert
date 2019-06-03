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
    public class ShoppingItemsController : Controller
    {
        private readonly webshopContext _context;

        public ShoppingItemsController(webshopContext context)
        {
            _context = context;
        }

        // GET: ShoppingItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        // GET: ShoppingItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingItem = await _context.Items
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shoppingItem == null)
            {
                return NotFound();
            }

            return View(shoppingItem);
        }

        // GET: ShoppingItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Quantitiy")] ShoppingItem shoppingItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingItem);
        }

        // GET: ShoppingItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingItem = await _context.Items.FindAsync(id);
            if (shoppingItem == null)
            {
                return NotFound();
            }
            return View(shoppingItem);
        }

        // POST: ShoppingItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Quantitiy")] ShoppingItem shoppingItem)
        {
            if (id != shoppingItem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingItemExists(shoppingItem.ID))
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
            return View(shoppingItem);
        }

        // GET: ShoppingItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingItem = await _context.Items
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shoppingItem == null)
            {
                return NotFound();
            }

            return View(shoppingItem);
        }

        // POST: ShoppingItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingItem = await _context.Items.FindAsync(id);
            _context.Items.Remove(shoppingItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingItemExists(int id)
        {
            return _context.Items.Any(e => e.ID == id);
        }
    }
}
