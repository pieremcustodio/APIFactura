using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infraestructure;

namespace Service
{
    public class ProductService
    {
        public List<Product> Get()
        {
            List<Product> products = null;
            using( var context= new InvoiceContext())
            {
                products = context.Product.ToList();
            }
            return products;
        }

        public Product GetById(int ID)
        {
            Product product = null;
            using (var context = new InvoiceContext())
            {
                product = context.Product.Find(ID);
            }
            return product;
        }
                
    }
}
