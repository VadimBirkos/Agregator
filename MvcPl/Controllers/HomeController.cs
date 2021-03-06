﻿using System.Collections.Generic;
using System.Web.Mvc;
using Bll.Implementation.Clients;
using Bll.Implementation.Parsers;
using CommonInterface;

namespace Agregator.Controllers
{
    public class HomeController : Controller
    {
     
        private RelaxClient a;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}