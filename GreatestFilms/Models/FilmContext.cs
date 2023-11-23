using Microsoft.EntityFrameworkCore;

namespace GreatestFilms.Models
{
    public class FilmContext:DbContext
    {
        public DbSet<Film> Films { get; set; }
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
            if(Database.EnsureCreated())
            {
                Films.Add(new Film { Name="Atlantis: The Lost Empire", DirectorName= "Gary Trousdale", Genre="Action-Adventure", Poster="/Images/Atlantis.jpg", Date="2001", Description=" "});
                Films.Add(new Film { Name="Blade Runner: 2049", DirectorName= "Denis Villeneuve", Genre="Science Fiction", Poster="/Images/BladeRunner2049.jpg", Date="2017", Description=" " });
                SaveChanges();
            }
        }

    }
}
