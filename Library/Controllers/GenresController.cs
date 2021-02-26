using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    [Authorize]
    public class GenresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Genres
        public ActionResult Index()
        {
            return View(db.Genres.ToList());
        }

        // GET: Genres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreModel genreModel = db.Genres.Find(id);
            if (genreModel == null)
            {
                return HttpNotFound();
            }
            return View(genreModel);
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,PhotoUrl")] GenreModel genreModel)
        {
            if (ModelState.IsValid)
            {
                db.Genres.Add(genreModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genreModel);
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreModel genreModel = db.Genres.Find(id);
            if (genreModel == null)
            {
                return HttpNotFound();
            }
            return View(genreModel);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,PhotoUrl")] GenreModel genreModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genreModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genreModel);
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreModel genreModel = db.Genres.Find(id);
            if (genreModel == null)
            {
                return HttpNotFound();
            }
            return View(genreModel);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GenreModel genreModel = db.Genres.Find(id);
            db.Genres.Remove(genreModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult AddToGenre(int? id)
        {
            AddToGenreModel model = new AddToGenreModel();
            model.Books = db.Books.ToList();
            model.GenreId = id ?? 0;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddToGenre(AddToGenreModel model)
        {
            var genre = db.Genres.Find(model.GenreId);
            var book = db.Books.Find(model.BookId);
            genre.Books.Add(book);
            db.SaveChanges();
            return View("Index", db.Genres.ToList());
        }
    }
}
