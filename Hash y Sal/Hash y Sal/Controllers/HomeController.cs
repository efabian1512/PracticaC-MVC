﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Configuration;

namespace Hash_y_Sal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var sinSal1 = Crypto.Hash("hola");
            //var sinSal2 = Crypto.Hash("hola");
            //var sinSal3 = Crypto.Hash("Hola");
            //var iguales = sinSal1 == sinSal2;

            //var conSal1 = Crypto.HashPassword("hola");
            //var conSal2 = Crypto.HashPassword("hola");
            //var iguales2 = conSal1 == conSal2;

            var dato1 = ConfigurationManager.AppSettings["Dato1"];
            var dato2 = ConfigurationManager.AppSettings["Dato2"];


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