using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Roles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roles.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var usuarioactual = User.Identity.GetUserId();
                using(ApplicationDbContext db = new ApplicationDbContext())
                {
                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                    var resultado = roleManager.Create(new IdentityRole("ApruebaPrestamos"));

                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                    userManager.Create(new ApplicationUser());

                   resultado = userManager.AddToRole(usuarioactual, "ApruebaPrestamos");

                    var usuarioenrol1 = userManager.IsInRole(usuarioactual, "ApruebaPrestamos");
                    var usuarioenrol2 = userManager.IsInRole(usuarioactual, "Contabiliada");
                    var roles = userManager.GetRoles(usuarioactual);


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