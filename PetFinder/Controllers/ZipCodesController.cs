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
    public class ZipCodesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ZipCodes
        public ActionResult Index()
        {
            return View(db.ZipCode.ToList());
        }

        // GET: ZipCodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZipCode zipCode = db.ZipCode.Find(id);
            if (zipCode == null)
            {
                return HttpNotFound();
            }
            return View(zipCode);
        }

        // GET: ZipCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZipCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZipCodeID,Zip")] ZipCode zipCode)
        {
            if (ModelState.IsValid)
            {
                db.ZipCode.Add(zipCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zipCode);
        }

        // GET: ZipCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZipCode zipCode = db.ZipCode.Find(id);
            if (zipCode == null)
            {
                return HttpNotFound();
            }
            return View(zipCode);
        }

        // POST: ZipCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZipCodeID,Zip")] ZipCode zipCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zipCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zipCode);
        }

        // GET: ZipCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZipCode zipCode = db.ZipCode.Find(id);
            if (zipCode == null)
            {
                return HttpNotFound();
            }
            return View(zipCode);
        }

        // POST: ZipCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZipCode zipCode = db.ZipCode.Find(id);
            db.ZipCode.Remove(zipCode);
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
