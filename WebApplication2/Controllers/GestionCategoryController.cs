using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class GestionCategoryController : Controller
    {
        // GET: GestionCategory
        public ActionResult Index()
        {
            using (Entities3 db = new Entities3())
            {
                return View(db.CATEGORIE.ToList());
            }
        }

        // GET: GestionCategory/Details/5
        public ActionResult Details(int id)
        {
            using (Entities3 db = new Entities3())
            {
                return View(db.CATEGORIE.Where(p => p.CategorieID == id).FirstOrDefault());
            }
        }

        // GET: GestionCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GestionCategory/Create
        [HttpPost]
        public ActionResult Create(CATEGORIE cat)
        {
            try
            {
                using (Entities3 db = new Entities3())
                {
                    db.CATEGORIE.Add(cat);
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

        // GET: GestionCategory/Edit/5
        public ActionResult Edit(int id)
        {
            using (Entities3 db = new Entities3())
            {
                return View(db.CATEGORIE.Where(p => p.CategorieID == id).FirstOrDefault());
            }
        }

        // POST: GestionCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CATEGORIE cat)
        {
            try
            {
                using (Entities3 db = new Entities3())
                {
                    db.Entry(cat).State = System.Data.Entity.EntityState.Modified;
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

        // GET: GestionCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GestionCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CATEGORIE cat)
        {
            try
            {
                using (Entities3 db = new Entities3())
                {
                    CATEGORIE ctg = db.CATEGORIE.Where(p => p.CategorieID == id).FirstOrDefault();
                    db.CATEGORIE.Remove(ctg);
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
