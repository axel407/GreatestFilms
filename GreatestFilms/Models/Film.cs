using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;

namespace GreatestFilms.Models
{
    [ComplexType]
    public class Film
    {
        //Film Id
        public int Id { get; set; }
        //Film Name
        public string Name { get; set; }
        //Filml`s director name
        public string DirectorName { get; set; }
        //Film genre
        public string Genre { get; set; }
        //Release date
        public string Date { get; set; }
        //Film discription
        [MaxLength(500)]
        public string Description { get; set; }
        //Path to poster image
        public string Poster { get; set; }

    }
}
