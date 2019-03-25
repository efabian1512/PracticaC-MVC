using Ajaxx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ajaxx.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AplicacionDbContext db = new AplicacionDbContext();
            ////var persona1 = new Persona() { Nombre = "Edwin", Edad = 29 };
            ////var persona2 = new Persona() { Nombre = "Omar", Edad = 26 };
            //var persona3 = new Persona() { Nombre = "Frankely", Edad = 21 };
            //var persona4 = new Persona() { Nombre = "Rossi", Edad = 28 };
            //var persona6 = new Persona() {Id=6, Nombre = "Deivi", Edad = 29 };
            ////var persona2 = db.Personas.Where(x => x.Id == 2).FirstOrDefault();
            //db.Personas.Add(persona3);
            //db.Personas.Add(persona4);
            //db.Personas.Add(persona5);
            //db.SaveChanges();

            //var detalle6 = new DetallePersona() { Peso = 150, Altura = 5.8,Sexo="Femenino",Persona=persona6};
            ////var detalle4 = new DetallePersona() { Peso = 160, Altura = 5.8,Sexo="Masculino", Persona = persona4 };
            ////var detalle5 = new DetallePersona() { Peso = 170, Altura = 5.11, Sexo = "Masculino", Persona = persona5 };
            ////db.DetallePersonas.Add(detalle3);
            ////db.DetallePersonas.Add(detalle4);
            //db.DetallePersonas.Add(detalle6);
            //db.SaveChanges();
            //var personas = db.Personas.Include("Detalle").ToList();
            return View();
        }
        public ActionResult AjaxForm()
        {
            return View();
        }
        public PartialViewResult CargarSeccion()
        {
            AplicacionDbContext db = new AplicacionDbContext();

            var personas = db.Personas.Include("Detalle").ToList();
            return PartialView("_Prueba", personas);

        }
        public ActionResult Autocomplete()
        {
            return View();
        }
        public JsonResult BuscaPersonas(string term)
        {
            AplicacionDbContext db = new AplicacionDbContext();
            var resultado = db.Personas.Where(x => x.Nombre.Contains(term)).ToList();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult DetallePersona(int PersonaId)
        {
            AplicacionDbContext db = new AplicacionDbContext();
            var PersonaDetalles = db.DetallePersonas.Where(x=>x.PersonaId==PersonaId).FirstOrDefault();
            return PartialView("_DetallePersona", PersonaDetalles);
            //return PartialView();
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