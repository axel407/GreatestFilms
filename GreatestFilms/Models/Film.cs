namespace GreatestFilms.Models
{
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
        public string Description { get; set; }
        //Path to poster image
        public string Poster { get; set; }

    }
}
