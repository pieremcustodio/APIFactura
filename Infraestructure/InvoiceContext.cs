using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain;

namespace Infraestructure
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext() : base("name = MyContextDB")
        {

        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
    }
}
