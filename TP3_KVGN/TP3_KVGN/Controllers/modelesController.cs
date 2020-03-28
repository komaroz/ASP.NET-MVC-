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
    public class modelesController : Controller
    {
        private BD_CatalogueEntities db = new BD_CatalogueEntities();

        // GET: modeles
        public ActionResult Index()
        {
            var modeles = db.modeles.Include(m => m.marque);
            return View(modeles.ToList());
        }

        // GET: modeles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modele modele = db.modeles.Find(id);
            if (modele == null)
            {
                return HttpNotFound();
            }
            return View(modele);
        }

        // GET: modeles/Create
        public ActionResult Create()
        {
            ViewBag.id_marque = new SelectList(db.marques, "id_marque", "nom");
            return View();
        }

        // POST: modeles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_modele,nom,id_marque")] modele modele)
        {
            if (ModelState.IsValid)
            {
                db.modeles.Add(modele);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_marque = new SelectList(db.marques, "id_marque", "nom", modele.id_marque);
            return View(modele);
        }

        // GET: modeles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modele modele = db.modeles.Find(id);
            if (modele == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_marque = new SelectList(db.marques, "id_marque", "nom", modele.id_marque);
            return View(modele);
        }

        // POST: modeles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_modele,nom,id_marque")] modele modele)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modele).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_marque = new SelectList(db.marques, "id_marque", "nom", modele.id_marque);
            return View(modele);
        }

        // GET: modeles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modele modele = db.modeles.Find(id);
            if (modele == null)
            {
                return HttpNotFound();
            }
            return View(modele);
        }

        // POST: modeles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modele modele = db.modeles.Find(id);
            db.modeles.Remove(modele);
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
