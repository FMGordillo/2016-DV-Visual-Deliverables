using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP_FINAL_FMGordillo.Models;

namespace TP_FINAL_FMGordillo.Controllers
{
    public class FacturaDetallesController : Controller
    {
        private TPFINAL_DBEntities db = new TPFINAL_DBEntities();

        // GET: FacturaDetalles
        public ActionResult Index()
        {
            var facturaDetalles = db.FacturaDetalles.Include(f => f.Articulo).Include(f => f.Factura);
            return View(facturaDetalles.ToList());
        }

        // GET: FacturaDetalles/Details/5
        public ActionResult Details(int? iddetalle, int? idfactura)
        {
            if (iddetalle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalle facturaDetalle = db.FacturaDetalles.Find(iddetalle, idfactura);
            if (facturaDetalle == null)
            {
                return HttpNotFound();
            }
            return View(facturaDetalle);
        }

        // GET: FacturaDetalles/Create
        public ActionResult Create()
        {
            ViewBag.idarticulo = new SelectList(db.Articuloes, "idarticulo", "detalle");
            ViewBag.idfactura = new SelectList(db.Facturas, "idfactura", "idfactura");
            return View();
        }

        // POST: FacturaDetalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iddetalle,idfactura,idarticulo,precio,cantidad,total")] FacturaDetalle facturaDetalle)
        {
            if (ModelState.IsValid)
            {
                db.FacturaDetalles.Add(facturaDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idarticulo = new SelectList(db.Articuloes, "idarticulo", "detalle", facturaDetalle.idarticulo);
            ViewBag.idfactura = new SelectList(db.Facturas, "idfactura", "fecha", facturaDetalle.idfactura);
            return View(facturaDetalle);
        }

        // GET: FacturaDetalles/Edit/5
        public ActionResult Edit(int? iddetalle, int? idfactura)
        {
            if (iddetalle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalle facturaDetalle = db.FacturaDetalles.Find(iddetalle, idfactura);
            if (facturaDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.idarticulo = new SelectList(db.Articuloes, "idarticulo", "detalle", facturaDetalle.idarticulo);
            ViewBag.idfactura = new SelectList(db.Facturas, "idfactura", "idfactura", facturaDetalle.idfactura);
            return View(facturaDetalle);
        }

        // POST: FacturaDetalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iddetalle,idfactura,idarticulo,precio,cantidad,total")] FacturaDetalle facturaDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturaDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idarticulo = new SelectList(db.Articuloes, "idarticulo", "detalle", facturaDetalle.idarticulo);
            ViewBag.idfactura = new SelectList(db.Facturas, "idfactura", "idfactura", facturaDetalle.idfactura);
            return View(facturaDetalle);
        }

        // GET: FacturaDetalles/Delete/5
        public ActionResult Delete(int? iddetalle, int? idfactura)
        {
            if (iddetalle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalle facturaDetalle = db.FacturaDetalles.Find(iddetalle, idfactura);
            if (facturaDetalle == null)
            {
                return HttpNotFound();
            }
            return View(facturaDetalle);
        }

        // POST: FacturaDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int iddetalle, int idfactura)
        {
            FacturaDetalle facturaDetalle = db.FacturaDetalles.Find(iddetalle, idfactura);
            db.FacturaDetalles.Remove(facturaDetalle);
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
