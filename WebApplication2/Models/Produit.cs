﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Produit
    {
        public int ProduitID { get; set; }
        public string Nom { get; set; }
        public int? Prix { get; set; }

        public string Description { get; set; }
        public string fournisseur { get; set; }
    }
}