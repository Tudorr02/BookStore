using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using MvcBookStore.Models;

namespace BookStore.Controllers
{
    public class Book1Controller : Controller
    {
        private readonly BookStoreContext _context;

        public Book1Controller(BookStoreContext context)
        {
            _context = context;
        }

        // GET: Book1
        public async Task<IActionResult> Index(string bookGenre, string searchString)
        {
            if (_context.Book1 == null)
            {
                return Problem("Entity set 'MvcBooksContext.Book'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Book1
                                            orderby m.Genre
                                            select m.Genre;
            var books = from m in _context.Book1
                        select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bookGenre))
            {
                books = books.Where(x => x.Genre == bookGenre);
            }

            var Book1GenreVM = new Book1GenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Books = await books.ToListAsync()
            };

            return View(Book1GenreVM);
        }


        // GET: Book1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Book1 == null)
            {
                return NotFound();
            }

            var book1 = await _context.Book1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book1 == null)
            {
                return NotFound();
            }

            return View(book1);
        }

        // GET: Book1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Book1 book1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book1);
        }

        // GET: Book1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Book1 == null)
            {
                return NotFound();
            }

            var book1 = await _context.Book1.FindAsync(id);
            if (book1 == null)
            {
                return NotFound();
            }
            return View(book1);
        }

        // POST: Book1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Book1 book1)
        {
            if (id != book1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Book1Exists(book1.Id))
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
            return View(book1);
        }

        // GET: Book1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Book1 == null)
            {
                return NotFound();
            }

            var book1 = await _context.Book1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book1 == null)
            {
                return NotFound();
            }

            return View(book1);
        }

        // POST: Book1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Book1 == null)
            {
                return Problem("Entity set 'BookStoreContext.Book1'  is null.");
            }
            var book1 = await _context.Book1.FindAsync(id);
            if (book1 != null)
            {
                _context.Book1.Remove(book1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Book1Exists(int id)
        {
          return (_context.Book1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
