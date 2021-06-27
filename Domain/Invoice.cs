using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Invoice
    {
        [Key]
        public int invoiceID { get; set; }
        [Required]
        public Client Client { get; set; }
        [Required]
        public string invoicecode { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public double total { get; set; }
        [Required]
        public Boolean status { get; set; }
    }
}
