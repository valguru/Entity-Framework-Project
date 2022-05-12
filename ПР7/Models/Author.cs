namespace ПР7.Models
{
    public class Author
    {
        public Author()
        {
            Songs = new HashSet<Song>();
            Name = "Имя_автора";
            Country = "Название_страны";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<Song> Songs { get; set; }  
    }
}
