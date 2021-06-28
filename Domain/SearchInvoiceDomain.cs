using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SearchInvoiceDomain
    {
        public string client { get; set; }
        public string invoicecode { get; set; }
        public DateTime date_first { get; set; }
        public DateTime date_last { get; set; }
    }
}
