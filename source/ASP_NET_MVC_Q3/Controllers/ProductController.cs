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
        private IProductRepository _productRepository;
        public ProductController()
        {
            this._productRepository = new ProductRepository();
        }


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

            return View();
        }

        public ActionResult List()
        {
            var list = _productRepository.GetAll();
            return View(list);
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
                _productRepository.Create(product);
                return RedirectToAction("List", "Product");
            }

            return View("List");
        }

        public ActionResult Update(int id)
        {
            ProductViewModel viewModel = new ProductViewModel();

            if (ModelState.IsValid)
            {
                var product = _productRepository.GetDetail(id);

                viewModel.Name =product.Name;
                viewModel.Locale = product.Locale;
                viewModel.LocaleListItem = items;
                return View(viewModel);
            }

            return View("List");
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {

            if (ModelState.IsValid)
            {
                _productRepository.Update(product);
            }
            return RedirectToAction("List", "Product");
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {

            if (ModelState.IsValid)
            {
                _productRepository.Delete(id);
            }

            return RedirectToAction("List", "Product");
        }


    }
}