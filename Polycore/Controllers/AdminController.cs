using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Polycore.Models;

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
            var lists = new DashboardViewModel
            {
                users = db.Users.Select(u => u.UserName).ToList(),
                posts = db.Posts.Select(p => p.Title).ToList(),
            };

            return View(lists);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Posts()
        {
            return View(db.Posts.ToList());
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AddPosts()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        //public ActionResult AddPosts()
        //{
        //    ViewBag.Controller = "AddPosts";
        //    return View();
        //}

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeletePosts(int id = 0)
        {
            PostModel posts = db.Posts.Find(id);

            if (posts != null)
            {
                db.Posts.Remove(posts);
                db.SaveChanges();

                return RedirectToAction("Posts");
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
        public ActionResult AddRoleToUser(ApplicationDbContext model, string id)
        {
            var account = UserManager.FindById(id);

            var roles = new AddUserRoleViewModel
            {
                UserId = account.Id,
                UserName = account.UserName,
                RoleList = model.Roles,
            };

            return View(roles);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddRoleToUser(ApplicationDbContext model, string rolename, string id)
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
                RoleList = model.Roles,
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
    }
}