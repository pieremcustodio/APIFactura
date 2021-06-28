using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFactura.Models
{
    public class InvoiceModel
    {
        public int invoiceID { get; set; }
        public ClientModel Client { get; set; }

        public string invoicecode { get; set; }
        public DateTime date { get; set; }
        public double total { get; set; }
        public Boolean status { get; set; }
    }
}