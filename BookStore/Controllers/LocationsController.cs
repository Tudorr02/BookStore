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
    public class LocationsController : Controller
    {
        private readonly BookStoreContext _context;

        public LocationsController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: Locations
        // GET: Movies
         public async Task<IActionResult> Index(string movieGenre, string searchString)
         {
             if (_context.Locations == null)
             {
                 return Problem("Entity set 'BookStoreContext.Locations'  is null.");
             }

             // Use LINQ to get list of genres.
             IQueryable<string> genreQuery = from m in _context.Locations
                                             orderby m.Country
                                             select m.Country;
             var movies = from m in _context.Locations
                          select m;

             if (!string.IsNullOrEmpty(searchString))
             {
                 movies = movies.Where(s => s.City!.Contains(searchString));
             }

             if (!string.IsNullOrEmpty(movieGenre))
             {
                 movies = movies.Where(x => x.Country == movieGenre);
             }

             var movieGenreVM = new LocationsViewModel
             {
                 Countries= new SelectList(await genreQuery.Distinct().ToListAsync()),
                 Locations = await movies.ToListAsync()
             };

             return View(movieGenreVM);
         }
        /*
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Locations == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var movies = from m in _context.Locations
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Country!.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }
        */
        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Locations == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locations == null)
            {
                return NotFound();
            }

            return View(locations);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Country,City,Adress,Opens,Closes")] Locations locations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locations);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Locations == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations.FindAsync(id);
            if (locations == null)
            {
                return NotFound();
            }
            return View(locations);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Country,City,Adress,Opens,Closes")] Locations locations)
        {
            if (id != locations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationsExists(locations.Id))
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
            return View(locations);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Locations == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locations == null)
            {
                return NotFound();
            }

            return View(locations);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Locations == null)
            {
                return Problem("Entity set 'BookStoreContext.Locations'  is null.");
            }
            var locations = await _context.Locations.FindAsync(id);
            if (locations != null)
            {
                _context.Locations.Remove(locations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationsExists(int id)
        {
          return (_context.Locations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
