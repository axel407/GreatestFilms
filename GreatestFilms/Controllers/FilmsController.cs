using GreatestFilms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GreatestFilms.Controllers
{
    public class FilmsController : Controller
    {
        private readonly FilmContext _context;

        public FilmsController(FilmContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Films != null ?
                View(await _context.Films.ToListAsync()) : 
                Problem("Entity set 'FilmContext.Films' is null.");
        }

        //GET: Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Films.SingleOrDefaultAsync(m => m.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        //GET: Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DirectorName,Genre,Date,Description,Poster")] Film film)
        {
            if(ModelState.IsValid)
            {
                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }


        //GET: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DirectorName,Genre,Date,Description,Poster")] Film film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.Id))
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
            return View(film);
        }

        //GET: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Films == null)
            {
                return Problem("Entity set 'FilmContext.Films'  is null.");
            }
            var film = await _context.Films.FindAsync(id);
            if (film != null)
            {
                _context.Films.Remove(film);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return (_context.Films?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}