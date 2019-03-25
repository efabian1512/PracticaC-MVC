using FormAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormAjax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            using (AplicacionDbContext db = new AplicacionDbContext())
            {
                var personas = new List<Persona>()
                {
                    new Persona() {Nombre="Edwin",Edad=29 },
                    new Persona() {Nombre="Omar",Edad=6 },
                    new Persona() {Nombre="Franco",Edad=21 },
                    new Persona() {Nombre="Pachi",Edad=25 },
                    new Persona() {Nombre="Rossi",Edad=28 }
                };

               // db.Personas.AddRange(personas);
                db.SaveChanges();
                var Persona1 = db.Personas.Where(x => x.IdPersona == 1).FirstOrDefault();
                var Persona2 = db.Personas.Where(x => x.IdPersona == 2).FirstOrDefault();
                var Persona3 = db.Personas.Where(x => x.IdPersona == 2).FirstOrDefault();
                var Persona4 = db.Personas.Where(x => x.IdPersona == 4).FirstOrDefault();
                var Persona5 = db.Personas.Where(x => x.IdPersona == 5).FirstOrDefault();


                var detalles = new List<DetallePersona>()
                {
                    new DetallePersona() {IdDetalle=1, Peso=166,Altura=5.10,Sexo="Masculino"},
                    new DetallePersona() {IdDetalle=2,Peso=167,Altura=5.11,Sexo="Masculino"},
                    new DetallePersona() {IdDetalle=3,Peso=168,Altura=5.12,Sexo="Masculino"},
                    new DetallePersona() {IdDetalle=4,Peso=169,Altura=5.13,Sexo="Masculino"},
                    new DetallePersona() {IdDetalle=5,Peso=170,Altura=5.14,Sexo="Femenino"}

                };
           var detalles2=db.DetallesPersonas.AddRange(detalles);
                db.SaveChanges();
                var personass = db.Personas.ToList();
                var detalless = db.DetallesPersonas.ToList();
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