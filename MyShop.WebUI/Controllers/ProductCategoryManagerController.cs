using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        IRepository<ProductCategory> context;


        public ProductCategoryManagerController(IRepository<ProductCategory> productCategoryContext)
        {
            context = productCategoryContext;  //new InMemoryRepository<ProductCategory>();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            //I dont know how it get from collection
            List<ProductCategory> productCategory = context.Collection().ToList();
            return View(productCategory);
        }

        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                context.Insert(productCategory);
                context.Commit();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = context.Find(Id);

            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id)
        {
            ProductCategory productCategoryToEdit = context.Find(Id);

            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }
                productCategoryToEdit.Category = productCategory.Category;
               // productCategoryToEdit.Description = productCategory.Description;
               // productCategoryToEdit.Image = productCategory.Image;
               // productCategoryToEdit.Name = productCategory.Name;
               // productCategoryToEdit.Price = productCategory.Price;
                
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCategory productcategoryToDelete = context.Find(Id);

            if (productcategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productcategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(String Id)
        {
            ProductCategory productToDelete = context.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}