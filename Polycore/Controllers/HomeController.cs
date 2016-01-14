using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Polycore.Models;

namespace Polycore.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Consoles()
        {
            return View(db.Consoles.ToList());
        }

        public ActionResult Games(int id = 0)
        {
            return View(db.Games.ToList().Where(g => g.Console.ConsoleID == id));
        }

        public ActionResult Subjects(int id = 0)
        {
            return View(db.Subjects.ToList().Where(s => s.Game.GameID == id));
        }

        public ActionResult Titles(int id = 0)
        {
            return View(db.Posts.ToList().Where(p => p.Subject.SubjectID == id));
        }

        public ActionResult Forum(int id = 0)
        {
            PostModel post = db.Posts.Find(id);

            var result = new ForumViewModel()
            {
                PostID = post.PostID,
                PostTitle = post.Title,
                PostContent = post.Content,
                PostLikes = post.Likes,
                PostDislikes = post.Dislikes,
                PostDate = post.Posted,
                PostUserName = post.User.UserName,
                Comments = post.Comments,
            };

            if (post == null)
            {
                return HttpNotFound();
            }

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(ForumViewModel model, int id = 0)
        {
            if (ModelState.IsValid)
            {
                CommentModel comment = new CommentModel();
                comment.Content = model.CommentContent;
                comment.Commented = DateTime.Now;

                db.Comments.Add(comment);
                db.SaveChanges();

                return RedirectToAction("Forum", new { id = id });
            }

            return View(model);
        }
    }
}