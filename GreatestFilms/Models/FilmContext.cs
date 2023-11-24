﻿using Microsoft.EntityFrameworkCore;

namespace GreatestFilms.Models
{
    public class FilmContext:DbContext
    {
        public DbSet<Film> Films { get; set; }
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
            if(Database.EnsureCreated())
            {
                Films.Add(new Film { Name="Atlantis: The Lost Empire", DirectorName= "Gary Trousdale", Genre="Action-Adventure", Poster="~/Images/Atlantis.jpg", Date="2001", Description="Atlantis: The Lost Empire is a 2001 American animated science fiction action-adventure film"});
                Films.Add(new Film { Name="Blade Runner: 2049", DirectorName= "Denis Villeneuve", Genre="Science Fiction", Poster="~/Images/BladeRunner2049.jpg", Date="2017", Description="Blade Runner 2049 is a 2017 American epic neo-noir science fiction film directed by Denis Villeneuve and written by Hampton Fancher and Michael Green.[10] A sequel to the 1982 film Blade Runner, the film stars Ryan Gosling and Harrison Ford, with Ana de Armas, Sylvia Hoeks, Robin Wright, Mackenzie Davis, Dave Bautista, and Jared Leto in supporting roles. Ford and Edward James Olmos reprise their roles from the original film. Gosling plays K, a Nexus-9 replicant \"blade runner\" who uncovers a secret that threatens to destabilize society and the course of civilization."});
                SaveChanges();
            }
        }

    }
}
