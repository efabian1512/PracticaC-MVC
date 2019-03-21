using Microsoft.AspNet.Identity;
using OverPosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OverPosting.Controllers
{
    [Authorize]
    public class OverPostingController : Controller
    {
        ApplicationDbContext db;
        public OverPostingController()
        {
            db = new ApplicationDbContext();
        }
        List<Comentario> _comentarios = new List<Comentario>();
        // GET: OverPosting
        public ActionResult Index()
        {
            var comente =db.Comentarios.ToList();
                
                _comentarios = db.Comentarios.Where(x => x.Aprobado).ToList();
            return View(_comentarios);
            
        }

       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult CrearComentario(Comentario  comentario)
        {
            var usuarioId = User.Identity.GetUserId();
            var usuario = db.Users.Where(x => x.Id == usuarioId).FirstOrDefault();
            var NombreUsuario = usuario.UserName;
            //Comentario comment = new Comentario();
            //comment.Contenido = comentario;
            comentario.Creado = DateTime.Now;
            comentario.Usuario = NombreUsuario;

            db.Comentarios.Add(comentario);
            db.SaveChanges();

            //var encontrar = db.Comentarios.Where(x => x.Contenido == "edin fabi").FirstOrDefault();
            //encontrar.Aprobado = true;
            //db.SaveChanges();
            //var ver = db.Comentarios.ToList();
            return RedirectToAction("Index");

        }

        // GET: OverPosting/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OverPosting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OverPosting/Create
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

        // GET: OverPosting/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OverPosting/Edit/5
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

        // GET: OverPosting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OverPosting/Delete/5
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
