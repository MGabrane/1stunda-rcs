﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeowDating.Controllers
{
    using System.Net;

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();

               
        }
       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.MADARA";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Blogs()
        {
            ViewBag.Message = "Kaķu blogs.";

            return View();
        }

    }

}