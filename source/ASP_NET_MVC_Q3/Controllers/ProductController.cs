using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.Infrastructure;
using ASP_NET_MVC_Q3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q3.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        public ProductController()
        {
            this.productRepository = new ProductRepository();
        }

        public static int Num;
        List<Product> source = Product.Data;
        List<SelectListItem> items = new List<SelectListItem>()
                {
                    new SelectListItem(){Text = "Unite State", Value = "US"},
                    new SelectListItem(){Text = "Germany",Value = "DE"},
                    new SelectListItem(){Text = "Canada",Value = "CA"},
                    new SelectListItem(){Text = "Spain",Value = "ES"},
                    new SelectListItem(){Text = "France",Value = "FR"},
                    new SelectListItem(){Text = "Japan",Value = "JP"}
                };
        
        
        public ActionResult Index()
        {

            if (source.Count != 0)
            {
                Num = source[source.Count - 1].Id;
                var model = productRepository.GetIndex(Num);         
            }

            return View();
        }

        public ActionResult List(Product product)
        {
            return View(source);
        }


        public ActionResult Create()
        {

            ProductViewModel viewModel = new ProductViewModel()
            {
                LocaleListItem = items
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                var model = productRepository.Create(product);         
                return RedirectToAction("List", "Product");
            }

            return View("List");
        }

        public ActionResult Update(int id)
        {

            if (ModelState.IsValid)
            {
                var model = productRepository.Get(id);    
                return View(model);
            }

            return View("List");
        }

        [HttpPost]
        public ActionResult Update(ProductViewModel productViewModel)
        {

            if (ModelState.IsValid)
            {
                var model = productRepository.Update(productViewModel);
            }
            return RedirectToAction("List", "Product");
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {

            if (ModelState.IsValid)
            {
                var model = productRepository.Delete(id);
            }

            return RedirectToAction("List", "Product");
        }


    }
}