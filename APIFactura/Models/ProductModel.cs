using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFactura.Models
{
    public class ProductModel
    {
        public int productID { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int stock { get; set; }
    }
}