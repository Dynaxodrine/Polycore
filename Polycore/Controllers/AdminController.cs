﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Polycore.Models;

namespace Polycore.Controllers
{
    public class AdminController : Controller
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
        public ActionResult Posts()
        {
            return View(db.NewsArticles.ToList());
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

            // Remove user.
            UserManager.Delete(account);

            return RedirectToAction("Users");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult User(string id)
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

                return RedirectToAction("User", new { id = account.Id });
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

            // Remove role from user.
            UserManager.RemoveFromRole(account.Id, rolename);

            return RedirectToAction("User", new { id = account.Id });
        }
    }
}