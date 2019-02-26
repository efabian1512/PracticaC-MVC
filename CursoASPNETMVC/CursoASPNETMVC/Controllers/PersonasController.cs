﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CursoASPNETMVC.Models;

namespace CursoASPNETMVC.Controllers
{
    public class PersonasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personas
        public ActionResult Index()
        {
            return View(db.Personas.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Nacimiento,Edad")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                var personas = new List<Persona>() { new Persona() { Nombre = "Edwin Fabian", Nacimiento = new DateTime(1989, 12, 15), Edad = 29 },
                    new Persona() { Nombre="Ramon Fabian",Nacimiento = new DateTime (1993,2,4),Edad=26 },
               new Persona() { Nombre="Frankely Fabian",Nacimiento = new DateTime (1997,11,25),Edad=21 } };
                personas.Add(persona);
                db.Personas.AddRange(personas);
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }

            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Nacimiento,Edad")] Persona persona)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(persona).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //Metodo 1
            var editarPersona1 = db.Personas.FirstOrDefault(x => x.Id == 2);
            editarPersona1.Nombre = "Editado Metodo 1";
            editarPersona1.Edad = editarPersona1.Edad + 1;
            db.SaveChanges();

            //Metodo 2
            var editarPersona2 = new Persona();
            editarPersona2.Id = 3;
            editarPersona2.Nombre = "Editado Metodo 2";
            editarPersona2.Edad = 54;
            db.Personas.Attach(editarPersona2);
            db.Entry(editarPersona2).Property(x => x.Nombre).IsModified = true;
            db.SaveChanges();

            var editarPersona3 = db.Entry(persona).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            //return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Personas.Find(id);
            db.Personas.Remove(persona);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
