using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetFinder.Models;

namespace PetFinder.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            var post = db.Post.Include(p => p.AnimalType).Include(p => p.Color).Include(p => p.Location);
            return View(post.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post
                .Include(c => c.AnimalType)
                .Include(c => c.Color)
                .Include(c => c.Location)
                .SingleOrDefault(x => x.PostID == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.AnimalTypeID = new SelectList(db.AnimalType, "AnimalTypeID", "Species");
            ViewBag.ColorID = new SelectList(db.Color, "ColorID", "Hue");
            ViewBag.LocationID = new SelectList(db.Location, "LocationID", "ZipCode");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,PostDate,Title,Message,Image,isReunited,isPetUser,isPetFinder,UserID,LocationID,AnimalTypeID,ColorID")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Post.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalTypeID = new SelectList(db.AnimalType, "AnimalTypeID", "Species", post.AnimalTypeID);
            ViewBag.ColorID = new SelectList(db.Color, "ColorID", "Hue", post.ColorID);
            ViewBag.LocationID = new SelectList(db.Location, "LocationID", "ZipCode", post.LocationID);
            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalTypeID = new SelectList(db.AnimalType, "AnimalTypeID", "Species", post.AnimalTypeID);
            ViewBag.ColorID = new SelectList(db.Color, "ColorID", "Hue", post.ColorID);
            ViewBag.LocationID = new SelectList(db.Location, "LocationID", "ZipCode", post.LocationID);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,PostDate,Title,Message,Image,isReunited,isPetUser,isPetFinder,UserID,LocationID,AnimalTypeID,ColorID")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalTypeID = new SelectList(db.AnimalType, "AnimalTypeID", "Species", post.AnimalTypeID);
            ViewBag.ColorID = new SelectList(db.Color, "ColorID", "Hue", post.ColorID);
            ViewBag.LocationID = new SelectList(db.Location, "LocationID", "ZipCode", post.LocationID);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Post.Find(id);
            db.Post.Remove(post);
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
