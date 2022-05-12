namespace ПР7.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public uint Year { get; set; }

        public int? AuthorId { get; set; } // ссылка на бренд
        public Author Author { get; set; }

        public Song()
        {
            Name = "Название_песни";
        }
    }
}
