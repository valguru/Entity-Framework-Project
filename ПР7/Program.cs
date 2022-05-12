using ПР7.Models;

namespace ПР7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Добавление
            using (SongDBContext db = new SongDBContext())
            {
                if (!db.Songs.Any() && !db.Authors.Any())
                {
                    Song sn1 = new Song { Name = "Секретный пляж", Year = 2020, AuthorId = 7 };
                    Song sn2 = new Song { Name = "Test Drive", Year = 2018, AuthorId = 3 };

                    Author auth1 = new Author { Name = "Дима Билан", Country = "Россия" };
                    Author auth2 = new Author { Name = "Дора", Country = "Россия" };
                    Author auth3 = new Author { Name = "Joji", Country = "США" };
                    Author auth4 = new Author { Name = "Филипп Киркоров", Country = "Россия" };
                    Author auth5 = new Author { Name = "Freddie Mercury", Country = "Англия" };
                    Author auth6 = new Author { Name = "Валентин Стрыкало", Country = "Украина" };
                    Author auth7 = new Author { Name = "Mirele", Country = "Израиль" };
                    Author auth8 = new Author { Name = "Макс Корж", Country = "Беларусь" };
                    Author auth9 = new Author { Name = "Сплин", Country = "Россия" };


                    // Добавление

                    db.Authors.Add(auth1);
                    db.Authors.Add(auth2);
                    db.Authors.Add(auth3);
                    db.Authors.Add(auth4);
                    db.Authors.Add(auth5);
                    db.Authors.Add(auth6);
                    db.Authors.Add(auth7);
                    db.Authors.Add(auth8);
                    db.Authors.Add(auth9);

                    db.Songs.Add(sn1);
                    db.Songs.Add(sn2);
                }
                db.SaveChanges();
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
