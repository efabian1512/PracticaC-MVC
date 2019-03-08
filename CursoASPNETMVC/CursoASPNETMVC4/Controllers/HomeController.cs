using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace CursoASPNETMVC4.Controllers
{
<<<<<<< HEAD
    public class nombre_edad
    {
        public string Nombre { get; set; }
=======
    public class Persona_Edad
    {
        public string Nombre  { get; set; }
>>>>>>> ed4616c1bf0b3b00814ebf78486dcc57a83716c0
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
<<<<<<< HEAD
            

            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var personas =db.Database.SqlQuery<nombre_edad>("sp_Personas_Por_Edad @Edad", new SqlParameter("@Edad", 29)).ToList();
                db.Database.ExecuteSqlCommand(RecursosSQL.sp_Borra_Personas_Menores_Nombre);
=======
            using (ApplicationDbContext1 db = new ApplicationDbContext1())
            {
                var Personas =db.Database.SqlQuery<Persona_Edad>("sp_Personas_Por_Edad @Edad",new SqlParameter("@Edad",29)).ToList();
                //db.Database.ExecuteSqlCommand(RecursosSQL.sp_Borrar_Personas_Nombre);
>>>>>>> ed4616c1bf0b3b00814ebf78486dcc57a83716c0
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