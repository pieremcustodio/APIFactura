using System.Collections.Generic;
using Service;
using Domain;
using System.Web.Http;
using System.Web.Http.Results;
using APIFactura.Models;
using APIFactura.Repository;

namespace APIFactura.Controllers
{
    public class InvoiceDetailController : ApiController
    {
        InvoiceDetailsService Service;
        public InvoiceDetailController()
        {
            Service = new InvoiceDetailsService();
        }
        // GET: Details
        [HttpGet]
        public JsonResult<List<InvoiceDetailModel>> GetAllDetails()
        {
            EntityMapper<InvoiceDetail, InvoiceDetailModel> mapObj = new EntityMapper<InvoiceDetail, InvoiceDetailModel>();
            List<InvoiceDetail> invDetList = Service.Get();
            List<InvoiceDetailModel> InvoiceDetails = new List<InvoiceDetailModel>();
            foreach (var item in invDetList)
            {
                InvoiceDetails.Add(mapObj.Translate(item));
            }
            return Json<List<InvoiceDetailModel>>(InvoiceDetails);
        }

        [HttpGet]
        public JsonResult<InvoiceDetailModel> GetDetail(int id)
        {
            EntityMapper<InvoiceDetail, InvoiceDetailModel> mapObj = new EntityMapper<InvoiceDetail, InvoiceDetailModel>();
            InvoiceDetail oneDetail = Service.GetById(id);
            InvoiceDetailModel InvoiceDetails = new InvoiceDetailModel();
            InvoiceDetails = mapObj.Translate(oneDetail);
            return Json<InvoiceDetailModel>(InvoiceDetails);
        }

        [HttpPost]
        public bool InsertInvoiceDetail(InvoiceDetailModel InvoiceDetail)
        {
            bool status = false;
            if(ModelState.IsValid)
            {
                EntityMapper<InvoiceDetailModel, InvoiceDetail> mapObj = new EntityMapper<InvoiceDetailModel, InvoiceDetail>();
                InvoiceDetail InvoiceDetailObj = new InvoiceDetail();
                InvoiceDetailObj = mapObj.Translate(InvoiceDetail);
                Service.Insert(InvoiceDetailObj);
                status = true;
            }
            return status;
        }
        
    }
}