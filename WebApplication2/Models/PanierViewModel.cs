using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class PanierViewModel
    {
        public List<Item> Items { get; set; }
        public int Total { get; set; }

        public int nbrItem { get; set; }
    }
}