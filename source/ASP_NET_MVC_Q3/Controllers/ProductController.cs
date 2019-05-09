using ASP_NET_MVC_Q3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC_Q3.ViewModel;

namespace ASP_NET_MVC_Q3.Controllers
{
    public class ProductController : Controller
    {
        public static int index;

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
            index = source[source.Count - 1].Id;
            return View();
        }

        public ActionResult List(Product product)
        {

            return View(source);
        }


        public ActionResult Create()
        {

            if (source == Product.Data && source.Count != 0)
            {
                index = source[source.Count - 1].Id;
            }

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
                CreateMethod(product);
                return RedirectToAction("List", "Product");

            }

            return View("List");
        }

        public ActionResult Edit(int id)
        {

            if (ModelState.IsValid)
            {
                return View(ReadMethod(id));
            }

            return View("List");

        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel)
        {

            if (ModelState.IsValid)
            {
                EditMethod(productViewModel);

            }
            return RedirectToAction("List", "Product");
        }


        //public ActionResult Delete(int? id)
        //{
        //    Product model = new Product();
        //    if (ModelState.IsValid)
        //    {
        //        for (int i = 0; i < source.Count; i++)
        //        {
        //            if (source[i].Id == id)
        //            {

        //                model.Locale = source[i].Locale;
        //                model.Name = source[i].Name;
        //                model.CreateDate = source[i].CreateDate;
        //                model.UpdateDate = source[i].UpdateDate;


        //                return View(model);


        //            }
        //        }
        //    }

        //    return View("List");
        //}

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                DeleteMethod(id);
            }

            return RedirectToAction("List", "Product");
        }




        public Product CreateMethod(Product product)
        {
            index++;

            ProductViewModel viewModel = new ProductViewModel();
            viewModel.Name = product.Name;
            viewModel.Locale = product.Locale;
            viewModel.CreateDate = DateTime.Now;

            source.Add(new Product() { Id = index, Name = viewModel.Name, CreateDate = viewModel.CreateDate, Locale = viewModel.Locale });

            return product;
        }

        public ProductViewModel ReadMethod(int id)
        {
            ProductViewModel viewModel = new ProductViewModel();
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i].Id == id)
                {
                    viewModel.Locale = source[i].Locale;
                    viewModel.Name = source[i].Name;
                    viewModel.LocaleListItem = items;

                    return viewModel;
                }
            }
            return viewModel;
        }

        public ProductViewModel EditMethod(ProductViewModel productViewModel)
        {
            var newValue = source.Where(m => m.Id == productViewModel.Id).FirstOrDefault();
            if (newValue != null)
            {
                newValue.Name = productViewModel.Name;
                newValue.Locale = productViewModel.Locale;
                newValue.UpdateDate = DateTime.Now;

            }
            return productViewModel;

        }

        public int DeleteMethod(int id)
        {
            source.RemoveAll(model => model.Id == id);
            return id;
        }

    }
}