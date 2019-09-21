using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliverEat.Models;

namespace DeliverEat.Controllers
{
    public class DomiciliosController : Controller
    {
        private DeliverEatContext db = new DeliverEatContext();

        // GET: Domicilios
        public ActionResult Index()
        {
            return View(db.Domicilios.ToList());
        }

        // GET: Domicilios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Domicilio domicilio = db.Domicilios.Find(id);
            if (domicilio == null)
            {
                return HttpNotFound();
            }
            return View(domicilio);
        }

        // GET: Domicilios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Domicilios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ciudad,Calle,Numero,Descripcion")] Domicilio domicilio)
        {
            if (ModelState.IsValid)
            {
                db.Domicilios.Add(domicilio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(domicilio);
        }

        // GET: Domicilios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Domicilio domicilio = db.Domicilios.Find(id);
            if (domicilio == null)
            {
                return HttpNotFound();
            }
            return View(domicilio);
        }

        // POST: Domicilios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ciudad,Calle,Numero,Descripcion")] Domicilio domicilio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(domicilio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(domicilio);
        }

        // GET: Domicilios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Domicilio domicilio = db.Domicilios.Find(id);
            if (domicilio == null)
            {
                return HttpNotFound();
            }
            return View(domicilio);
        }

        // POST: Domicilios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Domicilio domicilio = db.Domicilios.Find(id);
            db.Domicilios.Remove(domicilio);
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
