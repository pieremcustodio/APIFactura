using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFactura.Models
{
    public class SearchInvoiceModel
    {

        public string client { get; set; }
        public string invoicecode { get; set; }
        public DateTime date_first { get; set; }
        public DateTime date_last { get; set; }
    }
}