using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProduitsController : Controller
    {
        public ActionResult GetViewProducts(int? prixmin, int? prixmax, string marque)
        {
            Entities3 model;
            model = new Entities3();
            List<Produit> res;
            if (prixmax != null && prixmin != null)
            {
                res = model.PRODUIT.Where(o => o.Prix > prixmin && o.Prix < prixmax && (marque == "all" || o.FOURNISSEUR.Nom.Contains(marque))).Join(model.FOURNISSEUR, o => o.FournisseurID, f => f.FournisseurID, (o, f) => new Produit()
                {
                    ProduitID = o.ProduitID,
                    Nom = o.Nom,
                    Prix = o.Prix,
                    fournisseur = f.Nom
                }).ToList();
            }
            else
            {
                res = model.PRODUIT.Where(o=> (marque == "all" || o.FOURNISSEUR.Nom.Contains(marque))).Join(model.FOURNISSEUR, o => o.FournisseurID, f => f.FournisseurID, (o, f) => new Produit()
                {
                    ProduitID = o.ProduitID,
                    Nom = o.Nom,
                    Prix = o.Prix,
                    fournisseur = f.Nom
                }).ToList();
            }
            ViewProductsViewModel vm;
            vm = new ViewProductsViewModel();
            vm.Produits = res;
            return View("ViewProducts",vm);
        }

        public ActionResult GetPartialViewProduct(int catID,int? prixmin,int? prixmax,string marque)
        {
            Entities3 model;
            model = new Entities3();
            List<Produit> res;
            if (prixmax != null && prixmin != null)
            {
                res = model.PRODUIT.Where(o => o.CategorieID == catID && o.Prix > prixmin && o.Prix < prixmax &&  (marque=="all" || o.FOURNISSEUR.Nom.Contains(marque))  ).Join(model.FOURNISSEUR, o => o.FournisseurID, f => f.FournisseurID, (o, f) => new Produit()
                {
                    ProduitID = o.ProduitID,
                    Nom = o.Nom,
                    Prix = o.Prix,
                    fournisseur = f.Nom
                }).ToList();  
            }
            else
            {
                res = model.PRODUIT.Where(o => o.CategorieID == catID && (marque == "all" || o.FOURNISSEUR.Nom.Contains(marque))).Join(model.FOURNISSEUR, o => o.FournisseurID, f => f.FournisseurID, (o, f) => new Produit()
                {
                    ProduitID = o.ProduitID,
                    Nom = o.Nom,
                    Prix = o.Prix,
                    fournisseur = f.Nom
                }).ToList();
            }
            ViewProductsViewModel vm;
            vm = new ViewProductsViewModel();
            vm.Produits = res;
            return View("PartialViewProducts", vm);
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
    
        public ActionResult Recherche()
            {
                return View("Recherche");
            }
        public ActionResult SearchProducts(string search)
        {
            Entities3 model;
            model = new Entities3();
            List<Produit> res;
            
                res= model.PRODUIT.Join(model.FOURNISSEUR, o => o.FournisseurID, f => f.FournisseurID, (o, f) => new Produit()
                {
                    ProduitID = o.ProduitID,
                    Nom = o.Nom,
                    Prix = o.Prix,
                    fournisseur = f.Nom
                }).Where(o =>  (o.Nom.Contains(search)) || (o.fournisseur.Contains(search))).ToList();
                ViewProductsViewModel vm;
                vm = new ViewProductsViewModel();
                vm.Produits = res;
                return View("Recherche", vm);
        }

        public ActionResult DetailsProduct(int prodID)
        {
            Entities3 model;
            model = new Entities3();
            List<Produit> res;
            res = model.PRODUIT.Where(o => o.ProduitID == prodID).Select(o => new Produit()
            {
                ProduitID = o.ProduitID,
                Nom = o.Nom,
                Prix = o.Prix,
                fournisseur = o.FOURNISSEUR.Nom,
                Description = o.Description
            }).ToList();
            ViewProductsViewModel vm;
            vm = new ViewProductsViewModel();
            vm.Produits = res;
            return View("DetailsProduct", vm);
           
        }
        public ActionResult AddtoPanier(int productID,int quantite)
        {
            List<int> product;
            product = (List<int>)Session["PanierP"];
            product.Add(productID);
            List<int> quantity;
            quantity = (List<int>)Session["PanierQ"];
            quantity.Add(quantite);
            return View("Addition");
        }
        public ActionResult RemoveFromCart(int productID,int quantite)
        {
            List<int> product;
            product = (List<int>)Session["PanierP"];
            List<int> quantity;
            quantity = (List<int>)Session["PanierQ"];
            var details = product.Zip(quantity, (p, q) => new { product = p, quantity = q });
            foreach (var d in details)
            {
                if((d.product==productID) & (d.quantity==quantite))
                {
                    product.Remove(d.product);
                    quantity.Remove(d.quantity);
                    break;
                }
            }
            Session["PanierP"] = product;
            Session["PanierQ"] = quantity;
            return View("Addition");
            }
        public ActionResult DetailsPanier()
        {

            List<int> product;
            product = (List<int>)Session["PanierP"];
            List<int> quantity;
            quantity = (List<int>)Session["PanierQ"];

            List<Item> list;
                list = new List<Item>();
                Entities3 model;
                model = new Entities3();
                int total = 0;
                int nbritem = 0;
                var details = product.Zip(quantity, (p, q) => new { product = p, quantity = q });
                foreach (var d in details )
                {
                    PRODUIT p;
                    p = model.PRODUIT.FirstOrDefault(o => o.ProduitID == d.product);
                    Item res = new Item();
                    res.ProduitID = p.ProduitID;
                    res.Nom = p.Nom;
                    res.Prix = p.Prix.Value;
                    res.fournisseur = p.FOURNISSEUR.Nom;
                    res.TotalItem = p.Prix.Value * d.quantity;
                    res.quantite = d.quantity;
                    list.Add(res);
                    total = total + res.TotalItem;
                    nbritem = nbritem + d.quantity;
                }

                PanierViewModel vm;
                vm = new PanierViewModel();
                vm.Items = list;
                vm.Total = total;
                vm.nbrItem = nbritem;
                return View("DetailsPanier", vm);
           
        }
        public ActionResult Addcommande(int clientID)
        {
            List<int> product;
            product = (List<int>)Session["PanierP"];
            List<int> quantity;
            quantity = (List<int>)Session["PanierQ"];

            List<Item> list;
            list = new List<Item>();
            Entities3 model;
            model = new Entities3();
            
            var details = product.Zip(quantity, (p, q) => new { product = p, quantity = q });
            foreach (var d in details)
            {
                PRODUIT p;
                p = model.PRODUIT.FirstOrDefault(o => o.ProduitID == d.product);
                COMMANDE v = new COMMANDE();
                
                v.clientID = clientID;
                v.produitID = p.ProduitID;
                v.quantite = d.quantity;
                v.total= p.Prix.Value * d.quantity;
                using (Entities3 db = new Entities3())
                    {
                        db.COMMANDE.Add(v);
                        db.SaveChanges();

                    }
            }
            return View("finCommande");
        }
    }
}