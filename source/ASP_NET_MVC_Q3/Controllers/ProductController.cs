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
        public static int num;
        public static int result;

        List<Product> source = Product.Data;
        List<SelectListItem> items = new List<SelectListItem>()
                {
                    new SelectListItem()
                    {
                        Text = "Unite State",
                        Value = "US"
                    },
                    new SelectListItem()
                    {
                        Text = "Germany",
                        Value = "DE"
                    },
                    new SelectListItem()
                    {
                        Text = "Canada",
                        Value = "CA"
                    },
                    new SelectListItem()
                    {
                        Text = "Spain",
                        Value = "ES"
                    },
                    new SelectListItem()
                    {
                        Text = "France",
                        Value = "FR"
                    },
                    new SelectListItem()
                    {
                        Text = "Japan",
                        Value = "JP"
                    }

                };


        public ActionResult Index()
        {

            return View();
        }

        public ActionResult List(Product product)
        {

            return View(source);
        }


        public ActionResult Create()
        {

            ViewData["items"] = items;
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {

            num = result + 1;
            compare(num);

            Product model = new Product();
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.Name = product.Name;
                model.Locale = product.Locale;

                if (product.Name == null)
                { ModelState.AddModelError("Name", "please enter"); }
                if (string.IsNullOrEmpty(model.Locale))
                { ModelState.AddModelError("Locale", "please enter"); }

                else
                {
                    if (num==result) { source.Add(new Product() { Id = result, Name = model.Name, CreateDate = model.CreateDate, Locale = model.Locale }); }
                    else { source.Add(new Product() { Id = result + 1, Name = model.Name, CreateDate = model.CreateDate, Locale = model.Locale }); }
                }
                return RedirectToAction("List", "Product");

            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            Product model = new Product();
            if (ModelState.IsValid)
            {
                for (int i = 0; i < source.Count; i++)
                {
                    if (source[i].Id == id)
                    {
                        model.Id = source[i].Id;
                        model.Locale = source[i].Locale;
                        model.Name = source[i].Name;
                        ViewData["items"] = items;

                        return View(model);

                    }
                }
            }
            return View();

        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            ProductViewModel viewModel = new ProductViewModel();
            if (ModelState.IsValid)
            {
                Product model = new Product();
                model.Name = product.Name;
                model.Locale = product.Locale;
                model.UpdateDate = DateTime.Now;



                source.RemoveAll(m => m.Id == product.Id);
                source.Add(new Product() { Id = product.Id, Name = product.Name, UpdateDate = model.UpdateDate, CreateDate = product.CreateDate, Locale = model.Locale });
                source.Sort((x, y) => { return x.Id.CompareTo(y.Id); });
            }
            return RedirectToAction("List", "Product");
        }


        public ActionResult Delete(Product product)
        {
            Product model = new Product();
            model.Name = product.Name;
            model.Locale = product.Locale;
            model.CreateDate = product.CreateDate;
            model.UpdateDate = product.UpdateDate;


            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            compare(id);
            source.RemoveAll(model => model.Id == id);

            return RedirectToAction("List", "Product");
        }


        public int compare(int num)
        {

            if (result == 0)
            {
                result = source[source.Count - 1].Id;
                return result;
            }

            else
            {
                if (num < result)
                {
                    return result;
                }
                else
                {
                    result = num;
                    return result;
                }
            }
            
        }

    }
}