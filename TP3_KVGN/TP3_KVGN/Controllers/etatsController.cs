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
    public class etatsController : Controller
    {
        private BD_CatalogueEntities db = new BD_CatalogueEntities();

        // GET: etats
        public ActionResult Index()
        {
            return View(db.etats.ToList());
        }

        // GET: etats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etat etat = db.etats.Find(id);
            if (etat == null)
            {
                return HttpNotFound();
            }
            return View(etat);
        }

        // GET: etats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: etats/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_etat,nom")] etat etat)
        {
            if (ModelState.IsValid)
            {
                db.etats.Add(etat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etat);
        }

        // GET: etats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etat etat = db.etats.Find(id);
            if (etat == null)
            {
                return HttpNotFound();
            }
            return View(etat);
        }

        // POST: etats/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_etat,nom")] etat etat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etat);
        }

        // GET: etats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            etat etat = db.etats.Find(id);
            if (etat == null)
            {
                return HttpNotFound();
            }
            return View(etat);
        }

        // POST: etats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            etat etat = db.etats.Find(id);
            db.etats.Remove(etat);
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
