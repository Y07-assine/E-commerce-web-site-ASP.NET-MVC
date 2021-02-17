using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class GestionFournisseurController : Controller
    {
        // GET: GestionFournisseur
        public ActionResult Index()
        {
            using (Entities3 db = new Entities3())
            {
                return View(db.FOURNISSEUR.ToList());
            }
        }

        // GET: GestionFournisseur/Details/5
        public ActionResult Details(int id)
        {
            using (Entities3 db = new Entities3())
            {
                return View(db.FOURNISSEUR.Where(p => p.FournisseurID == id).FirstOrDefault());
            }
        }

        // GET: GestionFournisseur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GestionFournisseur/Create
        [HttpPost]
        public ActionResult Create(FOURNISSEUR fr)
        {
            try
            {
                using (Entities3 db = new Entities3())
                {
                    db.FOURNISSEUR.Add(fr);
                    db.SaveChanges();

                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GestionFournisseur/Edit/5
        public ActionResult Edit(int id)
        {
            using (Entities3 db = new Entities3())
            {
                return View(db.FOURNISSEUR.Where(p => p.FournisseurID == id).FirstOrDefault());
            }
        }

        // POST: GestionFournisseur/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FOURNISSEUR fr)
        {
            try
            {
                    using (Entities3 db = new Entities3())
                {
                    db.Entry(fr).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GestionFournisseur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GestionFournisseur/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FOURNISSEUR fr)
        {
            try
            {
                using (Entities3 db = new Entities3())
                {
                    FOURNISSEUR ctg = db.FOURNISSEUR.Where(p => p.FournisseurID == id).FirstOrDefault();
                    db.FOURNISSEUR.Remove(ctg);
                    db.SaveChanges();
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
