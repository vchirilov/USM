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

        public ViewResult List(int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                }
            };

            return View(model);
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

    }
}