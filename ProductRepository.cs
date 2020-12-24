using System.Collections.Generic;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products = new List<Product>();
        public ProductRepository() {
            products = cache["products"] as List<ProductRepository>;
            if (products == null) {
                products = new List<Product>();
            }
        }

        public void Commit() {
            cache["products"] = products;
        }
        public void Insert(Product p)
        {
            cache["products"] = products;
        }
    }
}
