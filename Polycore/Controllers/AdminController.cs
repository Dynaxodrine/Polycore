using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Polycore.Models;
using System.Data.Entity;

namespace Polycore.Controllers
{
    public class AdminController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult NewsArticles()
        {
            return View(db.NewsArticles.ToList());
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AddNewsArticle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddNewsArticle(NewsArticleModel model)
        {
            string userID = User.Identity.GetUserId();
            ApplicationUser account = db.Users.FirstOrDefault(a => a.Id == userID);
            if (ModelState.IsValid)
            {
                model.User = account;
                model.Published = DateTime.Now;
                model.Title = HttpUtility.HtmlEncode(model.Title);
                model.Content = HttpUtility.HtmlEncode(model.Content);

                db.NewsArticles.Add(model);
                db.SaveChanges();

                return RedirectToAction("NewsArticles");
            }

            ViewBag.Controller = "AddArticle";
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult EditNewsArticle(int id = 0)
        {
            Session["NewsArticleID"] = id;
            NewsArticleModel newsarticle = db.NewsArticles.FirstOrDefault(m => m.NewsArticleID == id);
            if (newsarticle == null)
            {
                return HttpNotFound();
            }
            return View(newsarticle);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditNewsArticle(NewsArticleModel model)
        {
            model.NewsArticleID = (int)Session["NewsArticleID"];
            if (ModelState.IsValid)
            {
                model.Published = DateTime.Now;
                model.Title = HttpUtility.HtmlEncode(model.Title);
                model.Content = HttpUtility.HtmlEncode(model.Content);

                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("NewsArticles");
            }

            ViewBag.Controller = "EditArticle";
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteNewsArticle(int id = 0)
        {
            NewsArticleModel newsarticle = db.NewsArticles.Find(id);
            if (newsarticle != null)
            {
                db.NewsArticles.Remove(newsarticle);
                db.SaveChanges();

                return RedirectToAction("NewsArticles");
            }
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Users()
        {
            return View(UserManager.Users.ToList());
        }

        // POST: Manage/DeleteUser/1
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteUser(string id)
        {
            var account = UserManager.FindById(id);
            if (account != null)
            {
                // Remove user.
                UserManager.Delete(account);

                return RedirectToAction("Users");
            }
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Roles(string id)
        {
            var account = UserManager.FindById(id);
            var userroles = UserManager.GetRoles(id);
            var roles = new UserRoleViewModel
            {
                UserId = account.Id,
                UserName = account.UserName,
                RoleList = userroles.ToList()
            };

            return View(roles);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AddRoleToUser(string id)
        {
            var account = UserManager.FindById(id);
            var roles = new AddUserRoleViewModel
            {
                UserId = account.Id,
                UserName = account.UserName,
                RoleList = db.Roles,
            };

            return View(roles);
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddRoleToUser(string rolename, string id)
        {
            var account = UserManager.FindById(id);
            if (rolename != "")
            {
                // Add role to user.
                UserManager.AddToRole(account.Id, rolename);

                return RedirectToAction("Roles", new { id = account.Id });
            }

            ModelState.AddModelError("", "You did not select a role.");

            var roles = new AddUserRoleViewModel
            {
                UserId = account.Id,
                UserName = account.UserName,
                RoleList = db.Roles,
            };

            ViewBag.Controller = "AddRoleToUser";
            return View(roles);
        }
        
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteRoleFromUser(string id, string rolename)
        {
            var account = UserManager.FindById(id);
            if (account != null && rolename != "")
            {
                // Remove role from user.
                UserManager.RemoveFromRole(account.Id, rolename);

                return RedirectToAction("Roles", new { id = account.Id });
            }
            return View();
        }

        // Dispose the dbcontext.
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}