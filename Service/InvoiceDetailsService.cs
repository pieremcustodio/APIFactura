using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infraestructure;

namespace Service
{
    public class InvoiceDetailsService
    {
        public List<InvoiceDetail> Get()
        {
            List<InvoiceDetail> invoicedetails = null;
            using (var context = new InvoiceContext())
            {
                invoicedetails = context.InvoiceDetail.ToList();
            }
            return invoicedetails;
        }

        public InvoiceDetail GetById(int ID)
        {
            InvoiceDetail invoicedetail = null;
            using (var context = new InvoiceContext())
            {
                invoicedetail = context.InvoiceDetail.Find(ID);
            }
            return invoicedetail;
        }

        public List<InvoiceDetail> GetByProductName(string productname)
        {
            List<InvoiceDetail> invoicedetail = null;
            using (var context = new InvoiceContext())
            {
                invoicedetail = context.InvoiceDetail.Include("Invoice").Include("Product").Where(e => e.Product.name == productname).ToList();
            }
            return invoicedetail;
        }
        public void Insert(InvoiceDetail invoicedetail)
        {
            using (var context = new InvoiceContext())
            {
                context.InvoiceDetail.Add(invoicedetail);
                context.SaveChanges();
            }
        }
    }
}
