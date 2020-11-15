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
    public class ShelvesController : Controller
    {
        private BookManagementDBContext db = new BookManagementDBContext();

        // GET: Shelves
        public ActionResult Index()
        {
            return View(db.Shelf.OrderBy(x => x.Name).ToList());
        }

        // GET: Shelves/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shelf shelf = db.Shelf.Find(id);
            if (shelf == null)
            {
                return HttpNotFound();
            }
            return View(shelf);
        }

        // GET: Shelves/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shelves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,Name")] Shelf shelf)
        {
            if (ModelState.IsValid)
            {
                db.Shelf.Add(shelf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shelf);
        }

        // GET: Shelves/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shelf shelf = db.Shelf.Find(id);
            if (shelf == null)
            {
                return HttpNotFound();
            }
            return View(shelf);
        }

        // POST: Shelves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,Name")] Shelf shelf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shelf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shelf);
        }

        // GET: Shelves/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shelf shelf = db.Shelf.Find(id);
            if (shelf == null)
            {
                return HttpNotFound();
            }
            return View(shelf);
        }

        // POST: Shelves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Shelf shelf = db.Shelf.Find(id);
            db.Shelf.Remove(shelf);
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
