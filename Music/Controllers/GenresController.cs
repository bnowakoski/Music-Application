using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Music.Models;

namespace Music.Controllers
{
    public class GenresController : Controller
    {
        private MusicContext db = new MusicContext();
        // GET: Genre
        public ActionResult Index()
        {
            var something = db.Genres.ToList();
            return View(something);
        }
        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreID, Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genre);
        }











        [HttpGet]
        public ActionResult SortByGenre(int? id)
        {


           

            if (id != null)
            {

                var genre = db.Genres.Where(a => a.GenreID == id);
                ViewBag.header = genre.First().Name;
                var albums = db.Albums
                    .Include(a => a.Artist)
                    .Include(a => a.Genre)
                    .Where(a => a.GenreID == id);
                return View("GenreSort", albums.ToList());
            }
            else
            {
                return View();
            }
        }

        
        







    }
    }

