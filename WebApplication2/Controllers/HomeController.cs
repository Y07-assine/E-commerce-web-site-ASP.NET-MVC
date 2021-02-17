using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Home()
        {
            return View("Home");
        }
        public ActionResult Categorie(int cat)
        {
            Entities3 model;
            model = new Entities3();
            List<Produit> res;
            res = model.PRODUIT.Where(o => o.CategorieID == cat).Join(model.FOURNISSEUR, o => o.FournisseurID, f => f.FournisseurID, (o, f) => new Produit()
            {
                ProduitID = o.ProduitID,
                Nom = o.Nom,
                Prix = o.Prix,
                fournisseur = f.Nom
            }).ToList();
            ViewProductsViewModel vm;
            vm = new ViewProductsViewModel();
            vm.Produits = res;
            return View("categorie", vm);

        }
        

        public ActionResult Login()
        {
            return View("Login");
        }
        public ActionResult Paiement()
        {
            return View("Paiement");
        }
    }
}
