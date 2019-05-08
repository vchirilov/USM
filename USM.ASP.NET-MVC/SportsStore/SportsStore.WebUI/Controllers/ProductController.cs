using SportsStore.Models;
using SportsStore.Models.Abstract;
using SportsStore.Models.Entities;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public int PageSize = 4;

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel viewModel = new ProductsListViewModel
            {
                Products = repository.Products
            .Where(p => category == null || p.Category == category)
            .OrderBy(p => p.ProductID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Where(p => category == null || p.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(viewModel);
        }


        // GET: Create/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                using (var context = new SportsStoreContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null && prod.ImageData != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

    }
}