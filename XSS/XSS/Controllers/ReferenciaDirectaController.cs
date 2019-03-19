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
                //var id = User.Identity.GetUserId();
                //var usuario = db.Users.Where(x => x.Id == id).FirstOrDefault();
                //var cuenta = usuario.NumeroDeCuenta;
               //ViewBag.Cuenta = cuenta;
                return View();

            }
            
        }

        // GET: ReferenciaDirecta
        [Authorize]
        public ActionResult InformacionDelaCuenta(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var cuenta = db.Users.Where(x => x.NumeroDeCuenta == id);
                return View(cuenta);

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
