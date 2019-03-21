using CSRF1.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSRF1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        List<Cuenta> CuentasUsuario = new List<Cuenta>();
        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var Idusuario = User.Identity.GetUserId();
           // var usuario = db.Users.Where(x => x.Id == Idusuario);


            CuentasUsuario = db.Cuentas.Where(x => x.IdUsuario == Idusuario).ToList();
            // Cuentas = db.Cuentas.

            return View(CuentasUsuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int monto)
        {
            var prueba = monto;

            var usuarioId = User.Identity.GetUserId();

            var cuenta = db.Cuentas.Add(new Cuenta() { Monto = monto, IdUsuario = usuarioId });
            //var cuenta2 = db.Cuentas.Add(new Cuenta() { Monto = 300, IdUsuario = "123456789" });
            db.SaveChanges();
            CuentasUsuario = db.Cuentas.Where(x => x.IdUsuario == usuarioId).ToList();

            return View(CuentasUsuario);
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
