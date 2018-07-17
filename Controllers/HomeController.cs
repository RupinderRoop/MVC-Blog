using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = context.Posts.ToList();
            ViewBag.Title = "";
            return View(data);
        }

        public ActionResult ShowPost(int id, string name)
        {
            Post post;
            post = context.Posts.Where(x => x.ID == id).FirstOrDefault();
            return View(post);
        }
    }
}