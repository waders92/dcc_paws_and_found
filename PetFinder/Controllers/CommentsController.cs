using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetFinder.Models;
using System.Net.Mail;

namespace PetFinder.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                return View(db.Comment.Include(c => c.Post).Where(x=> x.PostID == id).ToList());
            }
            var comments = db.Comment.Include(c => c.Post);
            return View(comments.ToList());
        }

        public PartialViewResult _Details_Partial(int? id)
        {
            if (id != null)
            {
                return PartialView(db.Comment.Include(c => c.Post).Where(x => x.PostID == id).ToList());
            }
            var comments = db.Comment.Include(c => c.Post);
            return PartialView(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create(int? id)
        {
            ViewBag.PostID = new SelectList(db.Post, "PostID", "Title");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Create([Bind(Include = "CommentID,Message,CommentDate,UserID,PostID")] Comment comment, int? id)
        {
            if (ModelState.IsValid)
            {
                comment.PostID = (int)id; 
                db.Comment.Add(comment);
                db.SaveChanges();

                var post = from x in db.Post
                           where x.PostID == comment.PostID
                           select x.UserID;

                // we have the user ID 

                // user id is the non queryable version of post because we used .first
                var userID = post.FirstOrDefault();

                // 
                var email = (from x in db.Users
                             where x.Id == userID
                             select x).FirstOrDefault().Email;

                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(email));  // replace with valid value 
                message.From = new MailAddress("pawsandfound1234@gmail.com");  // replace with valid value
                message.Subject = "Comment from Paws and Found!";
                message.Body = string.Format("You have a new comment about a post you have made at Paws and Found!");
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "pawsandfound1234@gmail.com",  // replace with valid value
                        Password = "cjlw2468@"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                }
                TempData["Message"] = "Your comment has been saved and an email has been sent to the post creator.";
                return RedirectToAction("Confirmation");
            }

            ViewBag.PostID = new SelectList(db.Post, "PostID", "Title", comment.PostID);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostID = new SelectList(db.Post, "PostID", "Title", comment.PostID);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,Message,CommentDate,UserID,PostID")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostID = new SelectList(db.Post, "PostID", "Title", comment.PostID);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comment.Find(id);
            db.Comment.Remove(comment);
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


        public ActionResult Confirmation()
        {
            return View();
        }
    }
}
