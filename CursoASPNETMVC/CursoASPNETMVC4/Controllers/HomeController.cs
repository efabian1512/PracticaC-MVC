using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace CursoASPNETMVC4.Controllers
{
    public class Persona_Edad
    {
        public string Nombre  { get; set; }
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
            using (ApplicationDbContext1 db = new ApplicationDbContext1())
            {
                var Personas =db.Database.SqlQuery<Persona_Edad>("sp_Personas_Por_Edad @Edad",new SqlParameter("@Edad",29)).ToList();
                //db.Database.ExecuteSqlCommand(RecursosSQL.sp_Borrar_Personas_Nombre);
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