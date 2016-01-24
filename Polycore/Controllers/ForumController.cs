using Microsoft.AspNet.Identity;
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

        // GET: Platforms
        public ActionResult Platforms()
        {
            return View(db.Platforms.ToList());
        }

        // GET: Games
        public ActionResult Games(string platform, int id = 0)
        {
            ViewBag.Platform = platform;
            return View(db.Games.Where(g => g.Platform != null && g.Platform.PlatformID == id));
        }

        // GET: Subjects
        public ActionResult Subjects(string platform, string game, int id = 0)
        {
            ViewBag.Platform = platform;
            ViewBag.Game = game;
            return View(db.Subjects.Where(s => s.Game != null && s.Game.GameID == id));
        }

        // GET: Forum
        public ActionResult Forum(string platform, string game, string subject, int id = 0)
        {
            SubjectModel subjects = db.Subjects.Find(id);
            PostModel posts = db.Posts.SingleOrDefault(p => p.Subject.SubjectID == id);
            
            if (id == 0 && posts == null)
            {
                return HttpNotFound();
            }

            var result = new ForumViewModel()
            {
                // Set the model id's.
                PostID = posts.PostID,
                PlatformID = subjects.Game.Platform.PlatformID,
                GameID = subjects.Game.GameID,

                // Set names for posts titles.
                PlatformName = subjects.Game.Platform.Name,
                GameName = subjects.Game.Name,
                SubjectName = subjects.Name,

                // Set the posts content items.
                PostTitle = posts.Title,
                PostContent = posts.Content,
                PostLikes = posts.Likes,
                PostDislikes = posts.Dislikes,
                PostDate = posts.Posted,
                PostUserName = posts.User.UserName,
                         
                // Set games in a list to get the available platforms of that game.
                Games = db.Games.Where(g => g.Name == subjects.Game.Name).ToList(),    

                // Set list of comments for under the posts.
                Comments = posts.Comments,
            };
                       
            return View(result);
        }

        // POST: Comments
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(ForumViewModel model, int id = 0)
        {
            // Get the current logged in user id.
            string currentUserId = User.Identity.GetUserId();
            var account = db.Users.FirstOrDefault(a => a.Id == currentUserId);

            if (ModelState.IsValid && account != null)
            {
                CommentModel comment = new CommentModel();
                comment.Content = model.CommentContent;
                comment.Commented = DateTime.Now;
                //comment.User.Id = account.Id;
                //comment.Post.PostID = Post_PostID;

                db.Comments.Add(comment);
                db.SaveChanges();

                return RedirectToAction("Forum", new { id = id });
            }

            return View(model);
        }
    }
}