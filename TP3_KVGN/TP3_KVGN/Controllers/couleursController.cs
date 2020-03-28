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
    public class couleursController : Controller
    {
        private BD_CatalogueEntities db = new BD_CatalogueEntities();

        // GET: couleurs
        public ActionResult Index()
        {
            return View(db.couleurs.ToList());
        }

        // GET: couleurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            couleur couleur = db.couleurs.Find(id);
            if (couleur == null)
            {
                return HttpNotFound();
            }
            return View(couleur);
        }

        // GET: couleurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: couleurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_couleur,nom")] couleur couleur)
        {
            if (ModelState.IsValid)
            {
                db.couleurs.Add(couleur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(couleur);
        }

        // GET: couleurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            couleur couleur = db.couleurs.Find(id);
            if (couleur == null)
            {
                return HttpNotFound();
            }
            return View(couleur);
        }

        // POST: couleurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_couleur,nom")] couleur couleur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(couleur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(couleur);
        }

        // GET: couleurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            couleur couleur = db.couleurs.Find(id);
            if (couleur == null)
            {
                return HttpNotFound();
            }
            return View(couleur);
        }

        // POST: couleurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            couleur couleur = db.couleurs.Find(id);
            db.couleurs.Remove(couleur);
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
