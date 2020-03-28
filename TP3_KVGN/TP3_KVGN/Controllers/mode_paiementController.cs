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
    public class mode_paiementController : Controller
    {
        private BD_CatalogueEntities db = new BD_CatalogueEntities();

        // GET: mode_paiement
        public ActionResult Index()
        {
            return View(db.mode_paiement.ToList());
        }

        // GET: mode_paiement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mode_paiement mode_paiement = db.mode_paiement.Find(id);
            if (mode_paiement == null)
            {
                return HttpNotFound();
            }
            return View(mode_paiement);
        }

        // GET: mode_paiement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mode_paiement/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_mode_paiement,nom")] mode_paiement mode_paiement)
        {
            if (ModelState.IsValid)
            {
                db.mode_paiement.Add(mode_paiement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mode_paiement);
        }

        // GET: mode_paiement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mode_paiement mode_paiement = db.mode_paiement.Find(id);
            if (mode_paiement == null)
            {
                return HttpNotFound();
            }
            return View(mode_paiement);
        }

        // POST: mode_paiement/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_mode_paiement,nom")] mode_paiement mode_paiement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mode_paiement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mode_paiement);
        }

        // GET: mode_paiement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mode_paiement mode_paiement = db.mode_paiement.Find(id);
            if (mode_paiement == null)
            {
                return HttpNotFound();
            }
            return View(mode_paiement);
        }

        // POST: mode_paiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mode_paiement mode_paiement = db.mode_paiement.Find(id);
            db.mode_paiement.Remove(mode_paiement);
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
