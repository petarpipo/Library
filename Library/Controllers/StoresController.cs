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
    public class StoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stores
        public ActionResult Index()
        {
            return View(db.Stores.ToList());
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreModel storeModel = db.Stores.Find(id);
            if (storeModel == null)
            {
                return HttpNotFound();
            }
            return View(storeModel);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,City,PhotoUrl")] StoreModel storeModel)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(storeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storeModel);
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreModel storeModel = db.Stores.Find(id);
            if (storeModel == null)
            {
                return HttpNotFound();
            }
            return View(storeModel);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,City,PhotoUrl")] StoreModel storeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storeModel);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreModel storeModel = db.Stores.Find(id);
            if (storeModel == null)
            {
                return HttpNotFound();
            }
            return View(storeModel);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoreModel storeModel = db.Stores.Find(id);
            db.Stores.Remove(storeModel);
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
        public ActionResult AddBook(int? id)
        {
            AddBookToStore model = new AddBookToStore();
            model.Books = db.Books.ToList();
            model.StoreId = id ?? 0;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddBook(AddBookToStore model)
        {
            var book = db.Books.Find(model.BookId);
            var store = db.Stores.Find(model.StoreId);
            store.Books.Add(book);
            db.SaveChanges();
            return View("Index",db.Stores.ToList());
        }
    }
}
