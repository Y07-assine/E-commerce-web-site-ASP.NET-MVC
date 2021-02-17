using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class GestionProductsController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using(Entities3 db=new Entities3())
            {
                return View(db.PRODUIT.ToList());
            }
            
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            using(Entities3 db=new Entities3())
            {
                return View(db.PRODUIT.Where(p => p.ProduitID == id).FirstOrDefault());
            }
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(PRODUIT produit)
        {
            try
            {
                using(Entities3 db=new Entities3())
                {
                    db.PRODUIT.Add(produit);
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            using (Entities3 db = new Entities3())
            {
                return View(db.PRODUIT.Where(p => p.ProduitID == id).FirstOrDefault());
            }
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PRODUIT produit)
        {
            try
            {
                using(Entities3 db=new Entities3())
                {
                    db.Entry(produit).State = System.Data.Entity.EntityState.Modified;
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            using (Entities3 db = new Entities3())
            {
                return View(db.PRODUIT.Where(p => p.ProduitID == id).FirstOrDefault());
            }
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PRODUIT produit)
        {
            try
            {
                using(Entities3 db= new Entities3())
                {
                    PRODUIT prod = db.PRODUIT.Where(p => p.ProduitID == id).FirstOrDefault();
                    db.PRODUIT.Remove(prod);
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
