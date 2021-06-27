using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class InvoiceDetail
    {
        [Key]
        public int invoicedetailID { get; set; }
        [Required]
        public Invoice Invoice { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public double price { get; set; }
    }
}
