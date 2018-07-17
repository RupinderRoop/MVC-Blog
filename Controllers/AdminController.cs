using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext context;

        public AdminController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Admin
        public ActionResult Index()
        {
            var data = context.Posts.ToList();
            return View(data);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            Post post;
            post = context.Posts.Where(x => x.ID == id).FirstOrDefault();
            return View(post);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Post post)
        {
            try
            {
                context.Posts.Add(post);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            Post post;
            post = context.Posts.Where(x => x.ID == id).FirstOrDefault();
            return View(post);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(post).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            Post post;
            post = context.Posts.Where(x => x.ID == id).FirstOrDefault();
            return View(post);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                context.Posts.Remove(context.Posts.Find(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
