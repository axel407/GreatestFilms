using GreatestFilms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GreatestFilms.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmContext _context;

        public FilmController(FilmContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Films != null ?
                View(await _context.Films.ToListAsync()) : 
                Problem("Entity set 'FilmContext.Films' is null.");
        }

        
    }
}