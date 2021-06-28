using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFactura.Models
{
    public class InvoiceDetailModel
    {
        public int invoicedetailID { get; set; }
        public InvoiceModel Invoice { get; set; }
        public ProductModel Product { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
    }
}