using System.Collections.Generic;
using Service;
using Domain;
using System.Web.Http;
using System.Web.Http.Results;
using APIFactura.Models;
using APIFactura.Repository;

namespace APIFactura.Controllers
{
    public class ProductController : ApiController
    {
        ProductService Service;
        public ProductController()
        {
            Service = new ProductService();
        }

        // GET: Product
        [HttpGet]
        public JsonResult<List<ProductModel>> GetAllProducts()
        {
            EntityMapper<Product, ProductModel> mapObj = new EntityMapper<Product, ProductModel>();
            List<Product> prodList = Service.Get();
            List<ProductModel> Products = new List<ProductModel>();
            foreach (var item in prodList)
            {
                Products.Add(mapObj.Translate(item));
            }
            return Json<List<ProductModel>>(Products);
        }

        [HttpGet]
        public JsonResult<ProductModel> GetProduct(int id)
        {
            EntityMapper<Product, ProductModel> mapObj = new EntityMapper<Product, ProductModel>();
            Product oneProduct = Service.GetById(id);
            ProductModel Products = new ProductModel();
            Products = mapObj.Translate(oneProduct);
            return Json<ProductModel>(Products);
        }
    }
}