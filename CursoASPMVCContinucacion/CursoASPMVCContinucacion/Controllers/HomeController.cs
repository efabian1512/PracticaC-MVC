using CursoASPMVCContinucacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CursoASPMVCContinucacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? edad,int pagina =1)

        {

            var cantidadRegistrosPorPagina = 2; //parametro
            using(var db = new ApplicationDbContext())
            {
                Func<Persona, bool> predicado = x => !edad.HasValue || edad.Value == x.Edad;
                var personas = db.Personas.OrderBy(x => x.Id)
                    .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                    .Take(cantidadRegistrosPorPagina).ToList();
                var totalDeRegistros = db.Personas.Count();

                var modelo = new IndexViewModels();
                modelo.Personas = personas;
                modelo.PaginaActual = pagina;
                modelo.TotalDeRegistros = totalDeRegistros;
                modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;
                modelo.ValoresQueryString = new RouteValueDictionary();
                modelo.ValoresQueryString["edad"] = edad;
                return View(modelo);
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