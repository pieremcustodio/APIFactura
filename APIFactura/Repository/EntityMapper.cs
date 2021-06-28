using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Domain;

namespace APIFactura.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapper()
        {
            Mapper.CreateMap<Models.InvoiceModel, Invoice>();
            Mapper.CreateMap<Invoice, Models.InvoiceModel>();
            
            Mapper.CreateMap<Models.ProductModel, Product>();
            Mapper.CreateMap<Models.ClientModel, Client>();
            Mapper.CreateMap<Client, Models.ClientModel>();

            Mapper.CreateMap<Models.InvoiceModel, Invoice>();
            Mapper.CreateMap<Invoice, Models.InvoiceModel>();

            Mapper.CreateMap<Models.SearchInvoiceModel, SearchInvoiceDomain>();
            Mapper.CreateMap<SearchInvoiceDomain, Models.SearchInvoiceModel > ();


        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}