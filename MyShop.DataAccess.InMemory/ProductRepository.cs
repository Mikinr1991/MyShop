using MyShop.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace MyShop.DataAccess.InMemory
{
   public  class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products = new List<Product>();
        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }

        public void Commit()
        {
            cache["products"] = products;
        }
        public void Insert(Product p)
        {
            products.Add(p);
            //cache["products"] = products;
        }

        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate = product;
            }else
            {
                throw new System.Exception("Product no  found");
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string Id) {

            Product productToDelete = products.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new System.Exception("Product no  found to Delete");
            }

        }

        public Product Find(string Id)
        {

            Product productTofind = products.Find(p => p.Id == Id);
            if (productTofind != null)
            {
                return productTofind;
            }
            else
            {
                throw new System.Exception("Product no  found");
            }

        }
    }
}
