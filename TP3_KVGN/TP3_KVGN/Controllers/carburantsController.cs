using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP3_KVGN.Models;

namespace TP3_KVGN.Controllers
{
    public class carburantsController : Controller
    {
        private BD_CatalogueEntities db = new BD_CatalogueEntities();

        // GET: carburants
        public ActionResult Index()
        {
            return View(db.carburants.ToList());
        }

        // GET: carburants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carburant carburant = db.carburants.Find(id);
            if (carburant == null)
            {
                return HttpNotFound();
            }
            return View(carburant);
        }

        // GET: carburants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: carburants/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_carburant,nom")] carburant carburant)
        {
            if (ModelState.IsValid)
            {
                db.carburants.Add(carburant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carburant);
        }

        // GET: carburants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carburant carburant = db.carburants.Find(id);
            if (carburant == null)
            {
                return HttpNotFound();
            }
            return View(carburant);
        }

        // POST: carburants/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_carburant,nom")] carburant carburant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carburant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carburant);
        }

        // GET: carburants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carburant carburant = db.carburants.Find(id);
            if (carburant == null)
            {
                return HttpNotFound();
            }
            return View(carburant);
        }

        // POST: carburants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carburant carburant = db.carburants.Find(id);
            db.carburants.Remove(carburant);
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
