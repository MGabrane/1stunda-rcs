using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeowDating.Controllers
{
    using MeowDating.Models;
    using System.IO;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity;

    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            using (var blogDb = new CatDb())
            {
                //Iegūt datubāzes listu
                var BlogListFromDb = blogDb.BlogThings.ToList();
                //izveidot skatu tam iekšā padodot bloga listam
                return View(BlogListFromDb);
            }
        }

        public ActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]


        public ActionResult CreateBlog(BlogThings userCreatedBlog)
        {
            
                if (ModelState.IsValid == false)
                {
                    return View(userCreatedBlog);
                }

            userCreatedBlog.BlogCreated = DateTime.Now;
            userCreatedBlog.BlogModifield = DateTime.Now;

            //Priekš ID iegūšanas
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                userCreatedBlog.UserId = userId;

            }
            //Kā atrast lietotāju datubāzē pēc id
            using (var usersDb = new ApplicationDbContext())
            {
                var user = usersDb.Users.First(record => record.Id == userCreatedBlog.UserId);
                //user.Email;
            }

            using (var blogDb = new CatDb())
            {
                //Pievienojam blogu tabulā
                blogDb.BlogThings.Add(userCreatedBlog);
                //saglabājam izmaiņas datubazē
                blogDb.SaveChanges();
            }

                    return RedirectToAction("Index");
        }

        public ActionResult EditBlog(int editableBlogId)
        {
            using(var db = new CatDb())
            {
                var blog = db.BlogThings.First(rec => rec.BlogId == editableBlogId);
                return View(blog);
            }
        }
    

        [HttpPost]
        public ActionResult EditBlog(BlogThings model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            model.BlogCreated = DateTime.Now;
            model.BlogModifield = DateTime.Now;

            

            using (var blogDb = new CatDb())
            {
                blogDb.Entry(model).State = EntityState.Modified;
                blogDb.SaveChanges();
                //SendEmail(model.Emai)
            }
            return RedirectToAction("Index");
 
        }
   

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult DeleteBlog(int deletableBlogId)
        {
            using (var blogDb = new CatDb())
            {
                var deletableBlog = blogDb.BlogThings.First(rece => rece.BlogId == deletableBlogId);

                blogDb.BlogThings.Remove(deletableBlog);

                blogDb.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
