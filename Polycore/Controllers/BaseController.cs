using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Polycore.Models;

namespace Polycore.Controllers
{
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            if (Request.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                ViewBag.Member = new ApplicationDbContext().Users.SingleOrDefault(p => p.Id == userId);
            }
            return base.BeginExecuteCore(callback, state);
        }
    }
}