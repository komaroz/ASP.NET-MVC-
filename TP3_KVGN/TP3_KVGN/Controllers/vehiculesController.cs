using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP3_KVGN.Models;

namespace TP3_KVGN.Controllers
{
    public class vehiculesController : Controller
    {
        private BD_CatalogueEntities db = new BD_CatalogueEntities();

        // GET: vehicules
        public ActionResult Index()
        {
            var vehicules = db.vehicules.Include(v => v.carburant).Include(v => v.couleur).Include(v => v.etat).Include(v => v.modele).Include(v => v.type);
            return View(vehicules.ToList());
        }

        public ActionResult ReturnToHomePage()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: vehicules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicule vehicule = db.vehicules.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        // GET: vehicules/Create
        public ActionResult Create()
        {
            ViewBag.id_carburant = new SelectList(db.carburants, "id_carburant", "nom");
            ViewBag.id_couleur = new SelectList(db.couleurs, "id_couleur", "nom");
            ViewBag.id_etat = new SelectList(db.etats, "id_etat", "nom");
            ViewBag.id_modele = new SelectList(db.modeles, "id_modele", "nom");
            ViewBag.id_type = new SelectList(db.types, "id_type", "nom");
            return View();
        }

        // POST: vehicules/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_vehicule,immatriculation,prix,kilometrage,date_construction,date_mise_vente,est_vendu,id_type,id_modele,id_couleur,id_carburant,id_etat,image,description")] vehicule vehicule, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                //MemoryStream target = new MemoryStream();
                //HttpPostedFileBase file = null;
                //file.InputStream.CopyTo(target);
                //byte[] data = target.ToArray();
                //vehicule.image = data;
                if (file != null)
                {
                    var images = new vehicule()
                    {
                        image = new byte[file.ContentLength]
                    };

                    file.InputStream.Read(images.image, 0, file.ContentLength);
                }


                db.vehicules.Add(vehicule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_carburant = new SelectList(db.carburants, "id_carburant", "nom", vehicule.id_carburant);
            ViewBag.id_couleur = new SelectList(db.couleurs, "id_couleur", "nom", vehicule.id_couleur);
            ViewBag.id_etat = new SelectList(db.etats, "id_etat", "nom", vehicule.id_etat);
            ViewBag.id_modele = new SelectList(db.modeles, "id_modele", "nom", vehicule.id_modele);
            ViewBag.id_type = new SelectList(db.types, "id_type", "nom", vehicule.id_type);
            return View(vehicule);
        }

        // GET: vehicules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicule vehicule = db.vehicules.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_carburant = new SelectList(db.carburants, "id_carburant", "nom", vehicule.id_carburant);
            ViewBag.id_couleur = new SelectList(db.couleurs, "id_couleur", "nom", vehicule.id_couleur);
            ViewBag.id_etat = new SelectList(db.etats, "id_etat", "nom", vehicule.id_etat);
            ViewBag.id_modele = new SelectList(db.modeles, "id_modele", "nom", vehicule.id_modele);
            ViewBag.id_type = new SelectList(db.types, "id_type", "nom", vehicule.id_type);
            return View(vehicule);
        }

        // POST: vehicules/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_vehicule,immatriculation,prix,kilometrage,date_construction,date_mise_vente,est_vendu,id_type,id_modele,id_couleur,id_carburant,id_etat,image,description")] vehicule vehicule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_carburant = new SelectList(db.carburants, "id_carburant", "nom", vehicule.id_carburant);
            ViewBag.id_couleur = new SelectList(db.couleurs, "id_couleur", "nom", vehicule.id_couleur);
            ViewBag.id_etat = new SelectList(db.etats, "id_etat", "nom", vehicule.id_etat);
            ViewBag.id_modele = new SelectList(db.modeles, "id_modele", "nom", vehicule.id_modele);
            ViewBag.id_type = new SelectList(db.types, "id_type", "nom", vehicule.id_type);
            return View(vehicule);
        }

        // GET: vehicules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicule vehicule = db.vehicules.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        // POST: vehicules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicule vehicule = db.vehicules.Find(id);
            db.vehicules.Remove(vehicule);
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

        //public FileContentResult GetImage(byte[] imagefile)
        //{
        //    var image = db.vehicules.FirstOrDefault(p => p.image.Equals(imagefile));

        //    if (image != null)
        //    {
        //        return File(image.image);
        //    }
        //    else
        //        return null;
        //}
    }
}
