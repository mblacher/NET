using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Facturacion.Models;

namespace Facturacion.Controllers
{
    public class ArticuloController : Controller
    {
        private Contexto c = new Contexto();

        public ActionResult Index()
        {
            return View("Listar", c.Articulos.ToList());
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "Id, Codigo, Descripcion, Precio")] Articulo Articulo)
        {
            if (ModelState.IsValid)
            {
                c.Articulos.Add(Articulo);

                if (c.SaveChanges() == 1)
                {
                    ViewBag.mensaje = "Articulo creado correctamente";
                }
                else
                {
                    ViewBag.mensaje = "Hay un error =(";
                }

                return View("Crear");
            }

            ViewBag.mensaje = "Te faltan datos capo.";

            return View("Crear");
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulos = c.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id, Codigo, Descripcion, Precio")] Articulo Articulo)
        {
            if (ModelState.IsValid)
            {
                c.Entry(Articulo).State = EntityState.Modified;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Articulo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                c.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
