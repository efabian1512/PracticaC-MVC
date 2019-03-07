using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoASPNETMVC4.Controllers
{
    public class nombre_edad
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            

            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var personas =db.Database.SqlQuery<nombre_edad>("sp_Personas_Por_Edad @Edad", new SqlParameter("@Edad", 29)).ToList();
                db.Database.ExecuteSqlCommand(RecursosSQL.sp_Borra_Personas_Menores_Nombre);
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}