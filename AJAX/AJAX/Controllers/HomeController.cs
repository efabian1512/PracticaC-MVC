using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJAX.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OtraVista()
        {
            return View();
        }
        public ActionResult Duplicar(int cantidad)
        {
            var duplica = cantidad * 2;
            return Content(duplica.ToString());

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Duplicador(int cantidad)
        {
            var resultado = cantidad * 2;
            return Json(resultado);

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