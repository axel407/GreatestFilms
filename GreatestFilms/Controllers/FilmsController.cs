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

    }
}