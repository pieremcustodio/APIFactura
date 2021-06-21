using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Client
    {
        [Key]
        public int clientID { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int dni { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string country { get; set; }
    }
}
