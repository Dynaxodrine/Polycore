using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Polycore.API;
using Polycore.API.Core.TGDB;
using Polycore.API.Core.TGDB.PlatformGames;
using Polycore.API.Core.TGDB.Platforms;
using Polycore.Models;
using Polycore.Models.Forum;
using Polycore.Models.Views;

namespace Polycore.Controllers
{
    public class HomeController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var platforms = TGDB.GetPlatformList();
            var games = new Dictionary<int, TGDBGame>();
            var gameSummaries = new Dictionary<string, List<PlatformSummary>>();
            /*
            foreach(var platform in platforms)
                foreach(var gs in TGDB.GetPlatformGamesList(platform.Id))
                    if(!gameSummaries.ContainsKey(gs.Title))
                        gameSummaries.Add(gs.Title, new List<PlatformSummary>() {platform});
                    else
                        gameSummaries[gs.Title].Add(platform);
                        
            foreach(var gsps in gameSummaries)    
                if(gsps.Value.Count > 1)
                    Console.WriteLine($"MORE DEN ONE: {gsps.Key} - {gsps.Value.Count}");
            */

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
            return View(db.Platforms.ToList());
        }

        public ActionResult Games(int id = 0)
        {
            return View(db.GameSubjects.ToList().Where(g => g.Platform.PlatformId == id));
        }

        public ActionResult Subjects(int id = 0)
        {
            return View(db.Subjects.Where(s => s.Game != null && s.Game.GameID == id));
        }

        public ActionResult Titles(int id = 0)
        {
            return View(db.Posts.ToList().Where(p => p.Subject.SubjectID == id));
        }

        public ActionResult Forum(int id = 0)
        {
            Post post = db.Posts.SingleOrDefault(p => p.PostID == id);


            if (post == null)
            {
                return HttpNotFound();
            }

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

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(ForumViewModel model, int id = 0)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment();
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