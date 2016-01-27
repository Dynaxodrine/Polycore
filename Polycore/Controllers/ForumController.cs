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
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Forum/Platforms
        public ActionResult Platforms()
        {
            return View(db.Platforms.ToList());
        }

        // GET: /Forum/Games/2?platform=PC
        public ActionResult Games(int id = 0)
        {
            PlatformModel platform = db.Platforms.FirstOrDefault(p => p.PlatformID == id);
            if (platform == null)
            {
                return HttpNotFound();
            }

            var result = new BrowseForumViewModel
            {
                PlatformName = platform.Name,
                Games = platform.Games.Where(g => g.Platform != null && g.Platform.PlatformID == id).ToList(),
            };

            return View(result);
        }

        // GET: /Forum/Subjects/1?platform=PC&game=Starcraft 2 Legacy of the Void
        public ActionResult Subjects(int id = 0)
        {
            GameModel game = db.Games.FirstOrDefault(g => g.GameID == id);
            if (game == null)
            {
                return HttpNotFound();
            }

            var result = new BrowseForumViewModel
            {
                PlatformID = game.Platform.PlatformID,
                GameID = game.GameID,
                PlatformName = game.Platform.Name, 
                GameName = game.Name,           
                Subjects = game.Subjects.Where(s => s.Game != null && s.Game.GameID == id).ToList(),
            };

            return View(result);
        }

        // GET: /Forum/Forum/1?platform=PC&game=Starcraft 2 Legacy of the Void&subject=test
        public ActionResult Forum(int id = 0)
        {
            SubjectModel subjects = db.Subjects.FirstOrDefault(s => s.SubjectID == id);
            PostModel posts = db.Posts.FirstOrDefault(p => p.Subject.SubjectID == id);
            if (subjects == null || posts == null)
            {
                return HttpNotFound();
            }
            
            var result = new ForumIndexViewModel()
            {
                // Get Set the model id's.                
                PlatformID = subjects.Game.Platform.PlatformID,
                GameID = subjects.Game.GameID,
                SubjectID = subjects.SubjectID,
                PostID = posts.PostID,

                // Get Set names for posts titles.
                PlatformName = subjects.Game.Platform.Name,
                GameName = subjects.Game.Name,
                SubjectName = subjects.Name,

                // Get Set the posts content items.
                PostTitle = posts.Title,
                PostContent = posts.Content,
                PostLikes = posts.Likes,
                PostDislikes = posts.Dislikes,
                PostDate = posts.Posted,
                PostUserName = posts.User.UserName,

                // Get Set games in a list to get the available platforms of that game.
                Games = db.Games.Where(g => g.Name == subjects.Game.Name).ToList(),    

                // Get Set list of comments for under the posts.
                Comments = posts.Comments,
            };
            
            ViewBag.Controller = "Forum";
            ModelState.AddModelError("", (string)Session["Message"]);
            return View(result);
        }

        // POST: /Forum/Forum/1?platform=PC&game=Starcraft 2 Legacy of the Void&subject=test
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(ForumIndexViewModel model, int subjectID = 0, int postID = 0)
        {
            // Get the post of the post id and the current logged in user id.
            string userID = User.Identity.GetUserId();
            ApplicationUser account = db.Users.FirstOrDefault(a => a.Id == userID);
            PostModel post = db.Posts.FirstOrDefault(p => p.PostID == postID);
            
            if (ModelState.IsValid)
            {
                CommentModel comment = new CommentModel();
                comment.Content = HttpUtility.HtmlEncode(model.CommentContent);
                comment.Commented = DateTime.Now;
                comment.User = account;
                comment.Post = post;

                db.Comments.Add(comment);
                db.SaveChanges();

                Session["Message"] = "Comment added.";
                return RedirectToAction("Forum", new { id = subjectID });
            }

            Session["Message"] = "Comment required.";
            return RedirectToAction("Forum", new { id = subjectID });
        }

        // Dispose the dbcontext.
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}