using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XSS.Models;

namespace XSS.Controllers
{
    public class ReferenciaDirectaController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var modelo = new RegisterViewModel();
                var id = User.Identity.GetUserId();
                var usuario = db.Users.Where(x => x.Id == id).FirstOrDefault();
                var cuenta = usuario.NumeroDeCuenta;
                modelo.NumeroDeCuenta = cuenta;
               // ViewBag.Cuenta = cuenta;
                return View(modelo);

            }
            
        }

        // GET: ReferenciaDirecta
        [Authorize]

        public ActionResult InformacionDelaCuenta(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var Id = id;
                var modelo = new RegisterViewModel();
                var usuario = db.Users.Where(x => x.NumeroDeCuenta == id).FirstOrDefault();
                 var cuenta = usuario.NumeroDeCuenta;
                modelo.NumeroDeCuenta = cuenta;
                if(modelo.NumeroDeCuenta != null)
                {
                    modelo.MontoDisponible = usuario.MontoDisponible;
                    var Idlogueado = User.Identity.GetUserId();
                    var usuariologueado = db.Users.Where(x => x.Id == Idlogueado).FirstOrDefault();
                    var CuentaLogueado = usuariologueado.NumeroDeCuenta;
                    if(CuentaLogueado == id)
                    {
                        return View(modelo);

                    }else
                    {
                        return RedirectToAction("Login", "Account");
                    }

                   
                }else
                {
                    return RedirectToAction("Index");

                }



                

            }

           
            


           // return View();
        }
        
       
        // GET: ReferenciaDirecta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReferenciaDirecta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferenciaDirecta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReferenciaDirecta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReferenciaDirecta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReferenciaDirecta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReferenciaDirecta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
