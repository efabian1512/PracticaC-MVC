using Sqlinjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sqlinjection.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<Persona> personas = new List<Persona>();
            using(ApplicationDbContext db = new ApplicationDbContext()) {
                personas = db.Personas.ToList();
                   

            return View(personas);
            }
        }
        [HttpPost]
        public ActionResult Index(string nombre)
        {
            
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //    //db.Personas.Add(new Persona { Nombre = "Edwin Fabian", Direccion = "Calle Respaldo San Antonio #22." });
                //    //db.Personas.Add(new Persona { Nombre = "Frankely Fabian", Direccion = "Sant Ignace, Michigan" });
                //    //db.Personas.Add(new Persona { Nombre = "Omar Fabian", Direccion = "San Isidro" });
                //    //db.Personas.Add(new Persona { Nombre = "Edwin Liriano", Direccion = "Calle Respaldo San Antonio #23." });
                //    //db.Personas.Add(new Persona { Nombre = "Frankely Mosquea", Direccion = "Detroit, Michigan" });
                //    //db.Personas.Add(new Persona { Nombre = "Omar Reinoso", Direccion = "San Bernardo" });
                //    //db.Personas.Add(new Persona { Nombre = "Edin Fabian", Direccion = "Calle Respaldo San Antonio #22." });
                //    //db.Personas.Add(new Persona { Nombre = "Franco Fabian", Direccion = "Sant Ignace, Michigan" });
                //    //db.Personas.Add(new Persona { Nombre = "Omar Perez", Direccion = "San Isidro" });
                //    var personas = db.Personas.ToList();
                //    //db.SaveChanges();

                List<Persona> personas = new List<Persona>();
                var query = @"SELECT * FROM Personas where nombre='" + nombre + "'";
                personas = db.Database.SqlQuery<Persona>(query).ToList();
                return View(personas);
            }
            
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