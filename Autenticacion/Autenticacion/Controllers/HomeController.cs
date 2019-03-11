using Autenticacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Autenticacion.Controllers
{
   // [Authorize(Roles ="Administrador,Vendedor")]
    public class HomeController : Controller
    {
       // [AllowAnonymous]
        public ActionResult Index()
        {
            var autenticado = User.Identity.IsAuthenticated;
            if (autenticado) {
                var nombre = User.Identity.Name;
                var id = User.Identity.GetUserId();
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var usuario =db.Users.FirstOrDefault(x=>x.Id==id);
                    var email = usuario.Email;
                    var confimacion =usuario.EmailConfirmed;

                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                   //var usuario2= userManager.FindById(id);
                    var user = new ApplicationUser();
                    user.UserName = "edwinfabian";
                    user.Email = "efabian1989@gmail.com";

                    //crear usuario

                    var resultado = userManager.Create(user, "MiPasswordSecreto");
               
            }
            }
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