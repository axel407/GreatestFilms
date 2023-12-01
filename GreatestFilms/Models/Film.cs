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
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int Id { get; set; }
        //Film Name
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Name { get; set; }
        //Filml`s director name
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string DirectorName { get; set; }
        //Film genre
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Genre { get; set; }
        //Release date
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"[0-9]", ErrorMessage = "Некорректный адрес")]
        public string Date { get; set; }
        //Film discription
        [MaxLength(500)]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Description { get; set; }
        //Path to poster image
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Poster { get; set; }

    }
}
