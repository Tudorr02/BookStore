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
    public class PHController : Controller
    {
        private readonly BookStoreContext _context;

        public PHController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: PH
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            if (_context.PH == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.PH
                                            orderby m.Country
                                            select m.Country;
            var movies = from m in _context.PH
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Country == movieGenre);
            }

            var movieGenreVM = new HPViewModel
            {
                Country = new SelectList(await genreQuery.Distinct().ToListAsync()),
                PHs = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: PH/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PH == null)
            {
                return NotFound();
            }

            var pH = await _context.PH
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pH == null)
            {
                return NotFound();
            }

            return View(pH);
        }

        // GET: PH/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Country,numberOfBooks")] PH pH)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pH);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pH);
        }

        // GET: PH/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PH == null)
            {
                return NotFound();
            }

            var pH = await _context.PH.FindAsync(id);
            if (pH == null)
            {
                return NotFound();
            }
            return View(pH);
        }

        // POST: PH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Country,numberOfBooks")] PH pH)
        {
            if (id != pH.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pH);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PHExists(pH.Id))
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
            return View(pH);
        }

        // GET: PH/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PH == null)
            {
                return NotFound();
            }

            var pH = await _context.PH
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pH == null)
            {
                return NotFound();
            }

            return View(pH);
        }

        // POST: PH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PH == null)
            {
                return Problem("Entity set 'BookStoreContext.PH'  is null.");
            }
            var pH = await _context.PH.FindAsync(id);
            if (pH != null)
            {
                _context.PH.Remove(pH);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PHExists(int id)
        {
          return (_context.PH?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
