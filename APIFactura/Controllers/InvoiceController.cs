using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using APIFactura.Models;
using APIFactura.Repository;
using Domain;
using Service;

namespace APIFactura.Controllers
{
    public class InvoiceController : ApiController
    {
        InvoiceService InvoiceService;
        // GET: Invoice
        public InvoiceController()
        {
            InvoiceService = new InvoiceService();
        }
        [HttpGet]
        public JsonResult<List<Models.InvoiceModel>> GetAllInvoices()
        {
            EntityMapper<Invoice, InvoiceModel> mapObj = new EntityMapper<Invoice, InvoiceModel>();
            List<Invoice> invoiceList = InvoiceService.Get();
            List<InvoiceModel> Invoices = new List<InvoiceModel>();
            
            foreach(var invoice in invoiceList)
            {
                Invoices.Add(mapObj.Translate(invoice));
            }

            return Json<List<InvoiceModel>>(Invoices);
        }

       

        [HttpPost]
        [Route("search")]
        public JsonResult<List<Models.InvoiceModel>> SearchBy_invoiceCode(Models.SearchInvoiceModel searchInvoice)
        {
            EntityMapper<Invoice, InvoiceModel> mapObj = new EntityMapper<Invoice, InvoiceModel>();
            EntityMapper<SearchInvoiceModel, SearchInvoiceDomain > mapObj2 = 
                new EntityMapper<SearchInvoiceModel, SearchInvoiceDomain >();
            SearchInvoiceDomain search = new SearchInvoiceDomain();
            search = mapObj2.Translate(searchInvoice);

            List<Invoice> invoiceList = InvoiceService.GetSearch(search);
            List<InvoiceModel> Invoices = new List<InvoiceModel>();
            foreach(var invoice in invoiceList)
            {
                Invoices.Add(mapObj.Translate(invoice));

            }

            return Json<List<InvoiceModel>>(Invoices);

        }

        [HttpPost]
        public bool InsertInvoice(InvoiceModel invoiceModel)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                EntityMapper<InvoiceModel, Invoice> mapearObjeto = new EntityMapper<InvoiceModel, Invoice>();
                Invoice InvoiceObjeto = new Invoice();
                InvoiceObjeto = mapearObjeto.Translate(invoiceModel);
                InvoiceService.Insert(InvoiceObjeto);
                status = true;
            }
            return status;

        }


    }


}