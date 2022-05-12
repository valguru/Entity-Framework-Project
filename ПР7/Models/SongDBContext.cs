using Microsoft.EntityFrameworkCore;

namespace ПР7.Models
{
    public class SongDBContext : DbContext
    {
        public SongDBContext() : this(false) { }
        public SongDBContext(bool bFromScratch) : base()
        {
            if (bFromScratch)
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        public SongDBContext(DbContextOptions<SongDBContext> options)
            : base(options)
        {

        }

        // коллекцию объектов, которая сопоставляется с определенной таблицей в базе данных
        public DbSet<Song> Songs { get; set; } 
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SongDB;Trusted_connection=TRUE");
            }
        }
    }
}
