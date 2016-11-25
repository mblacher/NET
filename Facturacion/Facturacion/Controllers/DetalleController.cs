using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Facturacion.Models;
using System.Data.SqlClient;

namespace Facturacion.Controllers
{
    public class DetalleController : Controller
    {
        private Contexto c = new Contexto();

        public ActionResult Index()
        {
            return View(c.Detalles.Include(f => f.Articulos).Include(f => f.Factura).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Detalle d = c.Detalles.Find(id);
            if (d == null)
            {
                return HttpNotFound();
            }
            return View(d);
        }

        public ActionResult Crear()
        {
            ViewBag.ArticuloId = new SelectList(c.Articulos, "Id", "Codigo");
            ViewBag.FacturaId = c.Database.ExecuteSqlCommand("SELECT TOP 1 Id FROM Factura ORDER BY Id DESC") + 1;
            return View();
        }


        // POST: FacturaDetalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "Id, FacturaId, ArticuloId, Cantidad, Precio")] Detalle d)
        {
            if (ModelState.IsValid)
            {
                c.Detalles.Add(d);
                c.SaveChanges();
                return RedirectToAction("Crear");
            }

            return RedirectToAction("Crear");
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
