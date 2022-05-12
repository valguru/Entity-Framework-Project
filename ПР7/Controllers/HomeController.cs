using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ПР7.Models;

namespace ПР7.Controllers
{
    public class HomeController : Controller
    {
        // переменная для взаимодействия с бд
        private SongDBContext db;
        public HomeController(SongDBContext context)
        {
            db = context;
        }

        
        // методы, которые будут добавлять новый объект в базу данных и выводить из нее все объекты
        public IActionResult Index()
        {
            // Готовим данные для представления
            ViewData["Title"] = "Песни";
            var songs = db.Songs.Include(a => a.Author).ToList();
            // Передаем управление "Представлению"
            return View(songs);
        }

        public IActionResult listAuthor()
        {
            // Готовим данные для представления
            ViewData["Title"] = "Авторы";
            var auth = db.Authors.ToList();
            // Передаем управление "Представлению"
            return View(auth);
        }

        // ************* Добавить/Создать песню **************
        [HttpGet]
        public IActionResult createSong()
        {
            ViewBag.Compans = new SelectList(db.Authors, "Id", "Name");
            Song song = new Song();
            return View(song);
        }
        [HttpPost]
        public IActionResult createSong(Song song)
        {
            db.Songs.Add(song);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ************* Добавить/Создать автора **************
        [HttpGet]
        public IActionResult createAuthor()
        {
            //ViewBag.Compans = new SelectList(db.Authors, "Id", "Name");
            Author auth = new Author();
            return View(auth);
        }
        [HttpPost]
        public IActionResult createAuthor(Author auth)
        {
            db.Authors.Add(auth);
            db.SaveChanges();
            return RedirectToAction("listAuthor");
        }

        // ************* Редактировать данные песни **************
        [HttpGet]
        public IActionResult editSong(int Id)
        {
            var song = db.Songs.FirstOrDefault(p => p.Id == Id);
            ViewBag.Compans = new SelectList(db.Authors, "Id", "Name");
            return View(song);
        }

        [HttpPost]
        public IActionResult editSong(Song song)
        {
            db.Songs.Update(song);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ************* Удалить песню **************
        public IActionResult deleteSong(Song song)
        {
            db.Songs.Attach(song);
            db.Songs.Remove(song);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ************* Удалить автора **************
        public IActionResult deleteAuthor(Author auth)
        {
            db.Authors.Attach(auth);
            db.Authors.Remove(auth);
            db.SaveChanges();
            return RedirectToAction("listAuthor");
        }

        // ************* Информация об авторе **************
        public IActionResult infoAuthor(int id)
        {
            var instr = db.Authors.FirstOrDefault(b => b.Id == id);
            var mus = db.Songs.Where(x => x.AuthorId == id);
            ViewData["Songs"] = mus;
            return View(instr);
        }

        // ************* Редактировать данные автора **************
        [HttpGet]
        public IActionResult editAuthor(int Id)
        {
            var brand = db.Authors.FirstOrDefault(p => p.Id == Id);
            ViewBag.Compans = new SelectList(db.Authors, "Id", "Name");
            return View(brand);
        }

        [HttpPost]
        public IActionResult editAuthor(Author author)
        {
            db.Authors.Update(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}