using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookManagement.Models;

namespace BookManagement.Controllers
{
    public class BooksController : Controller
    {
        private BookManagementDBContext db = new BookManagementDBContext();

        // GET: Books
        public ActionResult Index()
        {
            var book = db.Book.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher).Include(b => b.Shelf);
            return View(book.OrderBy(x => x.Title).ToList());
        }

        // GET: Books/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Author, "ID", "Name");
            ViewBag.CategoryID = new SelectList(db.Category, "ID", "Name");
            ViewBag.PublisherID = new SelectList(db.Publisher, "ID", "Name");
            ViewBag.ShelfID = new SelectList(db.Shelf, "ID", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,Title,ISBN,PublicationYear,Stock,AuthorID,PublisherID,CategoryID,ShelfID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Book.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Author, "ID", "Name", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Category, "ID", "Name", book.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publisher, "ID", "Name", book.PublisherID);
            ViewBag.ShelfID = new SelectList(db.Shelf, "ID", "Name", book.ShelfID);
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Author, "ID", "Name", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Category, "ID", "Name", book.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publisher, "ID", "Name", book.PublisherID);
            ViewBag.ShelfID = new SelectList(db.Shelf, "ID", "Name", book.ShelfID);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,Title,ISBN,PublicationYear,Stock,AuthorID,PublisherID,CategoryID,ShelfID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Author, "ID", "Name", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Category, "ID", "Name", book.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publisher, "ID", "Name", book.PublisherID);
            ViewBag.ShelfID = new SelectList(db.Shelf, "ID", "Name", book.ShelfID);
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Book.Find(id);
            db.Book.Remove(book);
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
    }
}
