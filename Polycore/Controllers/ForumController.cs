using Polycore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Polycore.Controllers
{
    public class ForumController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Forum
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Platforms()
        {
            return View(db.Platforms.ToList());
        }

        public ActionResult Games(string platform, int id = 0)
        {
            return View(db.Games.Where(g => g.Platform != null && g.Platform.PlatformID == id));
        }

        public ActionResult Subjects(string game, int id = 0)
        {
            return View(db.Subjects.Where(s => s.Game != null && s.Game.GameID == id));
        }

        public ActionResult Forum(string subject, int id = 0)
        {
            SubjectModel subjects = db.Subjects.Find(id);
            PostModel posts = db.Posts.SingleOrDefault(p => p.Subject.SubjectID == id);

            if (posts == null)
            {
                return HttpNotFound();
            }

            var result = new ForumViewModel()
            {
                // Set the id of the models.
                PostID = posts.PostID,
                PlatformID = subjects.Game.Platform.PlatformID,
                GameID = subjects.Game.GameID,

                // Set menu names in the title.
                PlatformName = subjects.Game.Platform.Name,
                GameName = subjects.Game.Name,
                SubjectName = subject,
                
                // Set the posts models.
                PostTitle = posts.Title,
                PostContent = posts.Content,
                PostLikes = posts.Likes,
                PostDislikes = posts.Dislikes,
                PostDate = posts.Posted,
                PostUserName = posts.User.UserName,
                
                // Set list of comments.
                Comments = posts.Comments,
            };

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