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
    public class commandesController : Controller
    {
        private BD_CatalogueEntities db = new BD_CatalogueEntities();

        // GET: commandes
        public ActionResult Index()
        {
            var commandes = db.commandes.Include(c => c.user).Include(c => c.status).Include(c => c.mode_paiement);
            return View(commandes.ToList());
        }

        // GET: commandes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            commande commande = db.commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // GET: commandes/Create
        public ActionResult Create()
        {
            ViewBag.id_user = new SelectList(db.users, "id_user", "login");
            ViewBag.id_status = new SelectList(db.status, "id_status", "nom");
            ViewBag.id_mode_paiement = new SelectList(db.mode_paiement, "id_mode_paiement", "nom");
            return View();
        }

        // POST: commandes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_commande,date_rdv,id_user,id_status,id_mode_paiement")] commande commande)
        {
            if (ModelState.IsValid)
            {
                db.commandes.Add(commande);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_user = new SelectList(db.users, "id_user", "login", commande.id_user);
            ViewBag.id_status = new SelectList(db.status, "id_status", "nom", commande.id_status);
            ViewBag.id_mode_paiement = new SelectList(db.mode_paiement, "id_mode_paiement", "nom", commande.id_mode_paiement);
            return View(commande);
        }

        // GET: commandes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            commande commande = db.commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_user = new SelectList(db.users, "id_user", "login", commande.id_user);
            ViewBag.id_status = new SelectList(db.status, "id_status", "nom", commande.id_status);
            ViewBag.id_mode_paiement = new SelectList(db.mode_paiement, "id_mode_paiement", "nom", commande.id_mode_paiement);
            return View(commande);
        }

        // POST: commandes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_commande,date_rdv,id_user,id_status,id_mode_paiement")] commande commande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_user = new SelectList(db.users, "id_user", "login", commande.id_user);
            ViewBag.id_status = new SelectList(db.status, "id_status", "nom", commande.id_status);
            ViewBag.id_mode_paiement = new SelectList(db.mode_paiement, "id_mode_paiement", "nom", commande.id_mode_paiement);
            return View(commande);
        }

        // GET: commandes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            commande commande = db.commandes.Find(id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // POST: commandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            commande commande = db.commandes.Find(id);
            db.commandes.Remove(commande);
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
