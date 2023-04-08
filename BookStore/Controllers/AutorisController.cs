using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class AutorisController : Controller
    {
        private readonly BookStoreContext _context;

        public AutorisController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: Autoris
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Autori == null)
            {
                return Problem("Entity set 'MvcMovieContext.Autori'  is null.");
            }

            var movies = from m in _context.Autori
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Country!.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }

        // GET: Autoris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Autori == null)
            {
                return NotFound();
            }

            var autori = await _context.Autori
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autori == null)
            {
                return NotFound();
            }

            return View(autori);
        }

        // GET: Autoris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autoris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,BirthDay,Country,WrittenBooks,Rating")] Autori autori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autori);
        }

        // GET: Autoris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Autori == null)
            {
                return NotFound();
            }

            var autori = await _context.Autori.FindAsync(id);
            if (autori == null)
            {
                return NotFound();
            }
            return View(autori);
        }

        // POST: Autoris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,BirthDay,Country,WrittenBooks,Rating")] Autori autori)
        {
            if (id != autori.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoriExists(autori.Id))
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
            return View(autori);
        }

        // GET: Autoris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Autori == null)
            {
                return NotFound();
            }

            var autori = await _context.Autori
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autori == null)
            {
                return NotFound();
            }

            return View(autori);
        }

        // POST: Autoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Autori == null)
            {
                return Problem("Entity set 'BookStoreContext.Autori'  is null.");
            }
            var autori = await _context.Autori.FindAsync(id);
            if (autori != null)
            {
                _context.Autori.Remove(autori);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoriExists(int id)
        {
          return (_context.Autori?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
