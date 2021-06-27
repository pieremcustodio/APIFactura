using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infraestructure;

namespace Service
{
    public class InvoiceService
    {
        public List<Invoice> Get()
        {
            List<Invoice> invoices = null;
            using (var context = new InvoiceContext())
            {
                invoices = context.Invoice.ToList();
            }
            return invoices;
        }

        public Invoice GetById(int ID)
        {
            Invoice invoice = null;
            using(var context = new InvoiceContext())
            {
                invoice = context.Invoice.Find(ID);
            }
            return invoice;
        }

        public void Insert(Invoice invoice)
        {
            using(var context= new InvoiceContext())
            {
                context.Invoice.Add(invoice);
                context.SaveChanges();
            }
        }
    }
}
