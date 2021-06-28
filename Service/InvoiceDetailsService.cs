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

        public InvoiceDetail GetByProductName(string productname)
        {
            InvoiceDetail invoicedetail = null;
            using (var context = new InvoiceContext())
            {
                invoicedetail = (InvoiceDetail)context.InvoiceDetail.Where(e => e.Product.name == productname);
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
