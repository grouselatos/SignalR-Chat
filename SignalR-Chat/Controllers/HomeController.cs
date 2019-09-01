using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using SignalR_Chat.Models;
using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;

namespace SignalR_Chat.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var users = db.Users.Where(x => x.UserName != User.Identity.Name).ToList();
            ViewBag.Users = new SelectList(users, "UserName", "UserName");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //Get reference to our Hub
            var hub = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            //Call broadcast of every user
            hub.Clients.All.broadcast("Someone visited About!");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}