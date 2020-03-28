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
    public class bon_commandeController : Controller
    {
        private BD_CatalogueEntities db = new BD_CatalogueEntities();

        // GET: bon_commande
        public ActionResult Index()
        {
            var bon_commande = db.bon_commande.Include(b => b.vehicule).Include(b => b.commande);
            return View(bon_commande.ToList());
        }

        // GET: bon_commande/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bon_commande bon_commande = db.bon_commande.Find(id);
            if (bon_commande == null)
            {
                return HttpNotFound();
            }
            return View(bon_commande);
        }

        // GET: bon_commande/Create
        public ActionResult Create()
        {
            ViewBag.id_vehicule = new SelectList(db.vehicules, "id_vehicule", "immatriculation");
            ViewBag.id_commande = new SelectList(db.commandes, "id_commande", "id_commande");
            return View();
        }

        // POST: bon_commande/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_bon_commande,id_vehicule,id_commande")] bon_commande bon_commande)
        {
            if (ModelState.IsValid)
            {
                db.bon_commande.Add(bon_commande);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_vehicule = new SelectList(db.vehicules, "id_vehicule", "immatriculation", bon_commande.id_vehicule);
            ViewBag.id_commande = new SelectList(db.commandes, "id_commande", "id_commande", bon_commande.id_commande);
            return View(bon_commande);
        }

        // GET: bon_commande/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bon_commande bon_commande = db.bon_commande.Find(id);
            if (bon_commande == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_vehicule = new SelectList(db.vehicules, "id_vehicule", "immatriculation", bon_commande.id_vehicule);
            ViewBag.id_commande = new SelectList(db.commandes, "id_commande", "id_commande", bon_commande.id_commande);
            return View(bon_commande);
        }

        // POST: bon_commande/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_bon_commande,id_vehicule,id_commande")] bon_commande bon_commande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bon_commande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_vehicule = new SelectList(db.vehicules, "id_vehicule", "immatriculation", bon_commande.id_vehicule);
            ViewBag.id_commande = new SelectList(db.commandes, "id_commande", "id_commande", bon_commande.id_commande);
            return View(bon_commande);
        }

        // GET: bon_commande/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bon_commande bon_commande = db.bon_commande.Find(id);
            if (bon_commande == null)
            {
                return HttpNotFound();
            }
            return View(bon_commande);
        }

        // POST: bon_commande/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bon_commande bon_commande = db.bon_commande.Find(id);
            db.bon_commande.Remove(bon_commande);
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
