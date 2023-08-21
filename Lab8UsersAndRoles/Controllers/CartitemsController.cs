using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab8UsersAndRoles.Data;
using Lab8UsersAndRoles.Models;

namespace Lab8UsersAndRoles.Controllers
{
    public class CartitemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartitemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cartitems
        public async Task<IActionResult> Index()
        {
            return _context.Cartitem != null ?
                        View(await _context.Cartitem.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Cartitem'  is null.");
        }

        // GET: Cartitems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cartitem == null)
            {
                return NotFound();
            }

            var cartitem = await _context.Cartitem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartitem == null)
            {
                return NotFound();
            }

            return View(cartitem);
        }

        // GET: Cartitems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cartitems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,Quantity,Total")] Cartitem cartitem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartitem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartitem);
        }

        // GET: Cartitems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cartitem == null)
            {
                return NotFound();
            }

            var cartitem = await _context.Cartitem.FindAsync(id);
            if (cartitem == null)
            {
                return NotFound();
            }
            return View(cartitem);
        }

        // POST: Cartitems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Quantity,Total")] Cartitem cartitem)
        {
            if (id != cartitem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartitemExists(cartitem.Id))
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
            return View(cartitem);
        }

        // GET: Cartitems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cartitem == null)
            {
                return NotFound();
            }

            var cartitem = await _context.Cartitem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartitem == null)
            {
                return NotFound();
            }

            return View(cartitem);
        }

        // POST: Cartitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cartitem == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cartitem'  is null.");
            }
            var cartitem = await _context.Cartitem.FindAsync(id);
            if (cartitem != null)
            {
                _context.Cartitem.Remove(cartitem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartitemExists(int id)
        {
            return (_context.Cartitem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
