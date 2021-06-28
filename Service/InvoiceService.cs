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

        public List<Invoice> GetSearch(string client, string invoicecode, DateTime date_first,
            DateTime date_last)
        {
            List<Invoice> invoices = null;
            using(var context = new InvoiceContext())
            {
                if(client == null)
                {
                    invoices = context.Invoice.Where(x => x.invoicecode == invoicecode)
                        .Where(x=> date_first<= x.date && date_last>=x.date).ToList();
                    return invoices;
                }
                else if(invoicecode == null)
                {
                    invoices = context.Invoice.Where(x => x.Client.name == client)
                        .Where(x => date_first <= x.date && date_last >= x.date).ToList();
                    return invoices;

                }
                else
                {
                    invoices = context.Invoice
                        .Where(x => date_first <= x.date && date_last >= x.date).ToList();
                    return invoices;
                }
            }
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
