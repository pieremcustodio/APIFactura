using System;
using System.Collections.Generic;
using System.Globalization;
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
                invoices = context.Invoice.Include("Client").ToList();
            }
            return invoices;
        }

        public List<Invoice> GetSearch(SearchInvoiceDomain searchInvoice)
        {
            List<Invoice> invoices = null;
            using (var context = new InvoiceContext())
            {

                if (searchInvoice.client == null && searchInvoice.invoicecode == null)
                {
                    invoices = context.Invoice.
                        Where(x =>  x.date >= searchInvoice.date_first && x.date <= searchInvoice.date_last
                        ).ToList();
                 }

                else
                {
                    if(searchInvoice.invoicecode != null && searchInvoice.client == null)
                    {
                        invoices = context.Invoice.Include("Client")
                       .Where(x => searchInvoice.invoicecode == x.invoicecode).ToList();

                    }
                    else if (searchInvoice.invoicecode == null && searchInvoice.client != null)
                    {
                        invoices = context.Invoice.Include("Client").Where(x => x.Client.name == searchInvoice.client)
                       .ToList();

                    }
                    else
                    {
                        invoices = context.Invoice.Include("Client").Where(x => x.Client.name == searchInvoice.client)
                       .Where(x => searchInvoice.invoicecode == x.invoicecode).ToList();
                    }

                }
               
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
