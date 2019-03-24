using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJAX.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OtraVista()
        {
            return View();
        }
        public ActionResult OtraMas()
        {
            return View();
        }

        public ActionResult Duplicar(int cantidad)
        {
            var duplica = cantidad * 2;
            return Content(duplica.ToString());

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Duplicador(int cantidad)
        {
            var resultado = cantidad * 2;
            return Json(resultado);

        }
        public ActionResult CrearPersona(Persona persona)
        {
            var resultado = new BaseRespuesta();
            try
            {
               if(persona.Edad < 18)
                {
                    throw new ApplicationException("La persona no puede ser menor de edad.");
                }

                resultado.Mensaje = "Persona creada correctamente";
                resultado.Ok = true;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Mensaje = ex.Message;
            }
            return Json(resultado);
        }
        public ActionResult Otra()
        {
            return View();
        }
        public PartialViewResult SeccionPrueba()
        {
            var personas = new List<Persona>() {
            new Persona() {Nombre="Edwin" , Edad=29 },
            new Persona() {Nombre="Rossi",Edad=28 },
            new Persona() {Nombre="Omar",Edad=26 },
            new Persona() {Nombre="Deivi",Edad=29 },
            new Persona() {Nombre="Frankely",Edad=21 },

            };

            return PartialView("_Prueba", personas);
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
    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
    public class BaseRespuesta{

        public string Mensaje { get; set; }
        public bool Ok { get; set; }
    }
}