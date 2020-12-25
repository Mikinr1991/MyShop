using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {

        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productcategories = new List<ProductCategory>();
        public ProductCategoryRepository()
        {
            productcategories = cache["ProductCategories"] as List<ProductCategory>;
            if (productcategories == null)
            {
                productcategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["ProductCategories"] = productcategories;
        }
        public void Insert(ProductCategory p)
        {
            productcategories.Add(p);
        }

        public void Update(ProductCategory productcategory)
        {
            ProductCategory productcategoryToUpdate = productcategories.Find(p => p.Id == productcategory.Id);
            if (productcategoryToUpdate != null)
            {
                productcategoryToUpdate = productcategory;
            }
            else
            {
                throw new System.Exception("Product Category no  found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productcategories.AsQueryable();
        }

        public void Delete(string Id)
        {

            ProductCategory productToDelete = productcategories.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                productcategories.Remove(productToDelete);
            }
            else
            {
                throw new System.Exception("Product Category no  found to Delete");
            }

        }

        public ProductCategory Find(string Id)
        {

            ProductCategory productcategoryTofind = productcategories.Find(p => p.Id == Id);
            if (productcategoryTofind != null)
            {
                return productcategoryTofind;
            }
            else
            {
                throw new System.Exception("Product Category  no  found");
            }

        }
    }
}
